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
        if(_choiceIndex >= 0 && _choiceIndex < _manager.CurrentNode.choices.Length)
        {
            _manager.CurrentNode.choices[_choiceIndex].choiceStrategy.ExecuteChoice(_manager, _choiceIndex);
        }
        else
        {
            Debug.Log("Invalid choice index: " + _choiceIndex);
        }
    }
}