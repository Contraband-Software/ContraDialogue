# Easy Dialogue

A flexible, robust package for game dialogue and dialogue-related events built on top of xNode.

## Quick start

This system is similar to setting up a custom shader in URP/HDRP. You create a dialogue graph using the nodes, you create a script to wrap and implement that graph, then you plug that script into a dialogue controller.

### Controllers+backend

Implement a UI controller for your game by inheriting from `GraphSystem.AbstractUIController` (implement the abstract methods). This will allow the dialogue controller to display dialogue.

Create a controller GameObject, then put a `GraphSystem.DialogueSequenceController` component on it, plug in the reference to your new UI controller (the system to pipe the current dialogue to the UI is now set up).

#### UI controllers

The system will not move forward unless the UI controller tells it to do so. For the system to function, the UI controller must communicate *back* to the DialogueSequenceController.

When the DrawNode function is called, it should use all of the information it is given to decide when to call `DialogueSequenceController.PostResponse(index)` (for example, it should play the audio clip, wait for the provided time out time + the clip length before posting a response). Note that the index parameter is not always applicable, for example if the current dialogue node has no possible responses (indicated by the response list being empty) - in this case, it doesn't matter what value you pass, the dialogue sequence controller will handle it.

### Your first dialogue tree

Right click in the Assets/file view area and click `Create -> Chrono Dialogue Graph`. Name it something sensible, then build your own dialogue tree. The tree **MUST** start from **ONE** root node and **ALWAYS** eventually terminate at a terminator node, including all paths.

Create a new script inheriting from `GraphSystem.AbstractTriggeredDialogue`, for the sake of demonstration, copy in this code:

```cs
public override void Suspend(bool status)
{
    Debug.Log("Suspended: " + status.ToString());
}

public override bool IsComplete()
{
    //end if we reach the terminator node (this function is part of AbstractTriggeredDialogue)
    return EndAtTerminator();
}
```

You could also use the premade version of this script shipped with the package `ChronoDialogueController`.

Now instantiate this script, ideally on the same manager GameObject, now add it as a reference to the DialogueSequenceControllers `Main Dialogue` serialized field.

Ensure "Start Main Sequence" is ticked and you should now be done!

### Event dialogues

To create a piece of dialogue that would interrupt the main dialogue (perhaps due to gameplay), go through the exact same process as above **EXCEPT** do `Create -> Event Graph` when creating it.

On your DialogueSequenceController, add a new triggered dialogue entry to its `Triggered Events` list field, give it a sensible name.

Now, to invoke your dialogue in-game, you call this function on the DialogueSequenceController using the name for your event:

```cs
public bool TryPlaySequence(string name);
```

A note, this function will only play your dialogue if your main node tree is in a section where it *allows* interruptions using `Set Interrupt` nodes, more on this in the next section.

## Nodes Reference

All nodes can only output to **ONE** node, but all nodes can accept input from many nodes.

The root and terminator nodes are pretty self explanatory. If you have multiple roots in your graph (bad), the first one the parser comes across will be used as the root. You may have multiple terminators in your graph, just as long as all paths end at a terminator, otherwise there could be crashes.

### Action Node

This node is best shown with an example.

Create a GameObject with a sensible name in your scene, add the `GraphSystem.ActionComponent` component to it, add another script to it, overwrite the public `System.Action` in the Action component with your own method.

In your node tree, add an Action node, enter in the name of your GameObject with the `GraphSystem.ActionComponent` component on it - now when your node tree reaches that node, your method will fire.

### Wait Node

This node waits for a specific time in seconds, it can also be used to clear the UIController's current display within the node graph.

### Halt for Flag Node

When the dialogue tree reaches this node it will halt until, if it hasn't been already, the specified flag has been posted to the DialogueSequenceController. Flags can be posted with this public method:

```cs
public void PostFlag(string flag);
```

### Set Interrupt Node

This node, when used in alternating pairs, can be used to control which sections of the graph can be interrupted by events and which cannot.

It does not need to be used in pairs, you can have one at the beginning stating the entire graph can be interrupted, etc.

### Dialogue Node

You can have someone say something with this node, the settings are all pretty self-explanatory.

The `Timeout` field specifies how much extra time to hang the dialogue for (if you want to give the user extra time to read it).

Ensure you tick the `Voiced` box if you add a dialogue audio clip.

### Dialogue Respond Node

Same as the dialogue node, but with a list field of possible responses, allowing you to branch off the tree.