using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace GraphSystem
{
    public class HaltForFlagNode : AbstractOneToOneNode
    {
        public struct HaltData
        {
            public string flag;
        }

        [SerializeField] private string flag;

        private HaltData haltData;

        protected override void Init()
        {
            base.Init();

            haltData = new HaltData();
            haltData.flag = flag;
        }

        public override NodeData GetNodeValue()
        {
            NodeData baseData;
            baseData.type = NodeType.HaltFlagged;
            baseData.data = haltData;
            baseData.NodeID = "HaltForFlagNode_" + flag + "_" + this.position;
            return baseData;
        }
    }
}