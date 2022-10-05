using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace GraphSystem
{
    [DefaultExecutionOrder(-20)]
    public abstract class AbstractTriggeredDialogue : MonoBehaviour
    {
        [SerializeField] NodeGraph graph;

        protected Parser DialogueGraphParser;
        protected NodeData currentNodeData;

        private void Awake()
        {
            DialogueGraphParser = new Parser(graph);
        }
        public NodeData AdvanceDialogue(int responseIndex)
        {
            BaseNode newNode = DialogueGraphParser.GetNextNode((uint)responseIndex);
            currentNodeData = newNode.GetNodeValue();

            return GetCurrentDialogue();
        }

        public NodeData GetCurrentDialogue()
        {
            return currentNodeData;
        }

        public NodeData Initiate()
        {
            BaseNode newNode = DialogueGraphParser.GetStartNode();

            currentNodeData = newNode.GetNodeValue();

            Debug.Log(currentNodeData.NodeID);

            return GetCurrentDialogue();
        }

        protected bool EndAtTerminator() { return GetCurrentDialogue().type == NodeType.End; }

        public abstract bool IsComplete();
        public abstract void Suspend(bool status);
    }
}