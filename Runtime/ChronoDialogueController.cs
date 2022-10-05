using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GraphSystem;

public class ChronoDialogueController : AbstractTriggeredDialogue
{
    public override void Suspend(bool status)
    {
        Debug.Log("Suspended: " + status.ToString());
    }

    public override bool IsComplete()
    {
        //terminate if we reach the end of the main story tree
        return GetCurrentDialogue().type == NodeType.End;
    }
    /*public override NodeData AdvanceDialogue(int responseIndex)
    {
        BaseNode newNode = DialogueGraphParser.GetNextNode((uint)responseIndex);
        currentNodeData = newNode.GetNodeValue();

        return GetCurrentDialogue();
    }
    public override NodeData GetCurrentDialogue()
    {
        return currentNodeData;
    }
    public override NodeData Initiate()
    {
        BaseNode newNode = DialogueGraphParser.GetStartNode();

        currentNodeData = newNode.GetNodeValue();

        Debug.Log(currentNodeData.NodeID);

        return GetCurrentDialogue();
    }*/
}
