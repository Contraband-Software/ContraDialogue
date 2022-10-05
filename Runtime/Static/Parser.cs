using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using XNode;

namespace GraphSystem
{
    using XNode;
    public class Parser
    {
        private NodeGraph graph;
        private RootNode root;
        private BaseNode currentNode;

        public Parser(NodeGraph chronoGraph)
        {
            graph = chronoGraph;
            root = GetRootNode(chronoGraph);
            currentNode = root.GetStartNode();

#if UNITY_EDITOR
            if (root == null)
            {
                Debug.LogException(new System.Exception("GraphSystem: NO ROOT NODE IN THIS GRAPH:" + graph.name));
            }
#endif
        }

        private RootNode GetRootNode(NodeGraph graph)
        {
            foreach (BaseNode node in graph.nodes)
            {
                if (node is RootNode)
                {
                    return (RootNode)node;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns the node **after** the root node, the first game node.
        /// </summary>
        /// <returns></returns>
        public BaseNode GetStartNode()
        {
            return currentNode;
        }

        public BaseNode GetNextNode(uint responseIndex)
        {
            NodeType currentNodeType = currentNode.GetNodeValue().type;

            switch (currentNodeType)
            {
                case NodeType.Dialogue:
                    currentNode = (BaseNode)currentNode.GetOutputPort(GraphGlobals.LinkNextNodeFieldName).Connection.node;
                    return currentNode;
                    break;
                case NodeType.DialogueRespond:
                    if (responseIndex < currentNode.DynamicOutputs.Count())
                    {
                        currentNode = (BaseNode)currentNode.DynamicOutputs.ToList<NodePort>()[(int)responseIndex].Connection.node;
                        return currentNode;
                    }
                    else {
                        Debug.LogException(new System.Exception("Graph System: Response index out of range!"));
                        return null;
                    }
                    break;

                //Link-only nodes
                case NodeType.SetInterrupt:
                case NodeType.HaltFlagged:
                case NodeType.Action:
                case NodeType.Wait:
                    NodePort node = currentNode.GetOutputPort(GraphGlobals.LinkNextNodeFieldName);
                    NodePort endNode = node.Connection;
                    currentNode = (BaseNode)endNode.node;
                    return currentNode;
                    break;

                case NodeType.End:
                    return null;
                    break;
            }

            return null;
        }
    }
}