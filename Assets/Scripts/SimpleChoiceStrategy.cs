using UnityEngine;

public class SimpleChoiceStrategy : IChoiceStrategy
{
    public void ExecuteChoice(DialogueManager manager, int choiceIndex)
    {
        DialogueNode nextNode = manager.CurrentNode.choices[choiceIndex].nextNode;
        manager.SetCurrentNode(nextNode);
    }
}