using GraphSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using static GraphSystem.GraphGlobals;

namespace GraphSystem {
    public abstract class BaseNode : Node
    {
        protected override void Init()
        {
            base.Init();
        }

        public abstract NodeData GetNodeValue();

        public override object GetValue(NodePort port)
        {
            return GetOutputPort(port.fieldName);
        }
    }
}