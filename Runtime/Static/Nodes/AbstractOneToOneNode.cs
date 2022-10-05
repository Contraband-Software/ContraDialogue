using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace GraphSystem
{
    public abstract class AbstractOneToOneNode : BaseNode
    {
        [Input]
        public GraphConnections.ConnectionLink previous;

        [Output(connectionType = ConnectionType.Override)]
        public GraphConnections.ConnectionLink next;
    }
}