using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using XNode;
using UnityEngine.Events;
using static GraphSystem.WaitNode;
using System.ComponentModel;

namespace GraphSystem
{
	public class ActionNode : AbstractOneToOneNode
    {
        public struct ActionData
        {
            public string gameObject;
        }

        [SerializeField] string gameObject;

        private ActionData actionData;

        protected override void Init()
        {
            base.Init();

            actionData = new ActionData();
            actionData.gameObject = gameObject;
        }

        public override NodeData GetNodeValue()
		{
            NodeData baseData;
            baseData.type = NodeType.Action;
            baseData.data = actionData;
            baseData.NodeID = "ActionNode_" + gameObject + "_" + this.position;
            return baseData;
        }
	}
}