using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace GraphSystem
{
    public class DialogueNode : DialogueBaseNode
    {
        public class DialogueData : BaseDialogueData
        {
            public GraphConnections.ConnectionLink next;
        }

        private DialogueData dialogueData;

        [Output(connectionType = ConnectionType.Override)]
        public GraphConnections.ConnectionLink next;

        protected override void Init()
        {
            base.Init();

            dialogueData = new DialogueData();
            dialogueData.name = speakerName;
            dialogueData.dialog = dialogue;
            dialogueData.hostilityEffect = hostilityEffect;
            dialogueData.next = next;
            dialogueData.timeOut = timeOut;
            dialogueData.clip = audioClip;
            dialogueData.voiced = isVoiced;
        }

        public override NodeData GetNodeValue()
        {
            NodeData baseData;
            baseData.type = NodeType.Dialogue;
            baseData.data = dialogueData;
            baseData.NodeID = "Dialig_" + speakerName + "_" + this.position;
            return baseData;
        }
    }
}