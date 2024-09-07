using UnityEngine;
public class MakeChoiceCommand : ICommand
{
    private DialogueManager _manager;
    private int _choiceIndex;

    public MakeChoiceCommand(DialogueManager manager, int choiceIndex)
    {
        _manager = manager;
        _choiceIndex = choiceIndex;
    }

    public void Execute()
    {
        // Null kontrolleri ekleyin
        if (_manager.CurrentNode == null)
        {
            Debug.LogError("CurrentNode is null");
            return;
        }

        if (_choiceIndex < 0 || _choiceIndex >= _manager.CurrentNode.choices.Length)
        {
            Debug.LogError("Invalid choice index");
            return;
        }

        // Seçilen düğüme geçiş yapma
        DialogueNode nextNode = _manager.CurrentNode.choices[_choiceIndex].nextNode;

        if (nextNode == null)
        {
            Debug.LogError("NextNode is null");
            return;
        }

        _manager.SetCurrentNode(nextNode);
    }
}
