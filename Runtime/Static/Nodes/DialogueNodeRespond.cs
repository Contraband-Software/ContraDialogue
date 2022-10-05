using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace GraphSystem
{
    public class DialogueNodeRespond : DialogueBaseNode
    {
        public class DialogueRespondData : BaseDialogueData
        {
            public List<GraphConnections.ResponseConnectionData> responses;
        }

        private DialogueRespondData dialogueData;

        [Output(dynamicPortList = true, connectionType = ConnectionType.Override)]
        public List<GraphConnections.ResponseConnectionData> responses;

        protected override void Init()
        {
            base.Init();

            dialogueData = new DialogueRespondData();
            dialogueData.name = speakerName;
            dialogueData.dialog = dialogue;
            dialogueData.hostilityEffect = hostilityEffect;
            dialogueData.responses = responses;
            dialogueData.timeOut = timeOut;
            dialogueData.clip = audioClip;
            dialogueData.voiced = isVoiced;
        }

        public override NodeData GetNodeValue()
        {
            NodeData baseData;
            baseData.type = NodeType.DialogueRespond;
            baseData.data = dialogueData;
            baseData.NodeID = "Dialig_" + speakerName + "_" + this.position;
            return baseData;
        }
    }
}