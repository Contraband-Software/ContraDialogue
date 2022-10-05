using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using XNode;
using static GraphSystem.DialogueNode;
using static GraphSystem.GraphGlobals;

namespace GraphSystem
{
    public class WaitNode : AbstractOneToOneNode
    {
        public struct WaitData
        {
            public float timeInSeconds;
            public bool clearScreen;
        }

        [SerializeField] private float timeInSeconds;
        [SerializeField] private bool clearScreen;

        private WaitData waitData;

        protected override void Init()
        {
            base.Init();

            waitData = new WaitData();
            waitData.timeInSeconds = timeInSeconds;
            waitData.clearScreen = clearScreen;
        }

        public override NodeData GetNodeValue()
        {
            NodeData baseData;
            baseData.type = NodeType.Wait;
            baseData.data = waitData;
            baseData.NodeID = "WaitNode_" + timeInSeconds.ToString() + "_" + this.position;
            return baseData;
        }
    }
}