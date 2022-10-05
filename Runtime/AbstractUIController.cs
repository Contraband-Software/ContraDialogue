using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphSystem
{
    public abstract class AbstractUIController : MonoBehaviour
    {
        public abstract void DrawNode(string incomingText, bool canReply, string speakerName, List<GraphConnections.ResponseConnectionData> dialogueOptions, float timeOut, AudioClip clip, bool voiced);
        public abstract void OnWait(float time, bool clearScreen);
    }
}