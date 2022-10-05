using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace GraphSystem
{
	public class TerminatorNode : BaseNode
	{
        [Input]
        public GraphConnections.ConnectionLink previous;

        public override NodeData GetNodeValue()
        {
            NodeData baseData;
            baseData.type = NodeType.End;
            baseData.data = null;
            baseData.NodeID = "TerminatorNode_" + this.position;
            return baseData;
        }
    }
}