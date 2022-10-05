using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GraphSystem
{
    public class GraphConnections
    {
        public class BaseFlowConnection { }

        [Serializable]
        public class ConnectionLink : BaseFlowConnection
        {

        }
        [Serializable]
        public class ResponseConnectionData : BaseFlowConnection
        {
            [TextArea] public string response;
            public bool AutoChoose;
            public AudioClip audioClip;
        }
    }
}