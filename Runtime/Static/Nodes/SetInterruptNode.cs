using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphSystem
{
    public class SetInterruptNode : AbstractOneToOneNode
    {
        public class SetInterruptData
        {
            public bool isSet;
        }

        private SetInterruptData interruptData;

        [Header("Can this graph be suspended?")]

        [SerializeField] bool Set = false;

        protected override void Init()
        {
            base.Init();

            interruptData = new SetInterruptData();
            interruptData.isSet = Set;
        }

        public override NodeData GetNodeValue()
        {
            NodeData baseData;
            baseData.type = NodeType.SetInterrupt;
            baseData.data = interruptData;
            baseData.NodeID = "SetInterrupt_" + Set.ToString() + "_" + this.position;
            return baseData;
        }
    }
}