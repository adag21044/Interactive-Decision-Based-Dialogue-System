using UnityEngine;

/// <summary>
/// Strategy for handling simple choice execution in the dialogue system.
/// </summary>
public class SimpleChoiceStrategy : IChoiceStrategy
{
    public void ExecuteChoice(DialogueManager manager, int choiceIndex)
    {
        if (manager.CurrentNode == null || choiceIndex < 0 || choiceIndex >= manager.CurrentNode.choices.Length)
        {
            Debug.LogError("Invalid choice or CurrentNode is null");
            return;
        }

        DialogueNode nextNode = manager.CurrentNode.choices[choiceIndex].nextNode;
        manager.SetCurrentNode(nextNode);
    }
}
