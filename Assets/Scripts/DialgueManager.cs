using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public DialogueTree dialogueTree;
    public DialogueNode CurrentNode{ get; set; }

    void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        CurrentNode = dialogueTree.startNode;
        DisplayCurrentDialogue();
    }

    public void SetCurrentNode(DialogueNode node)
    {
        CurrentNode = node;
        DisplayCurrentDialogue();
    }

    public void DisplayCurrentDialogue()
    {
        Debug.Log("Dialogue: " + CurrentNode.dialogueText);
        
        for(int i = 0; i < CurrentNode.choices.Length; i++)
        {
            Debug.Log("Choice " + i + ": " + CurrentNode.choices[i].choiceText);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        ICommand command = new MakeChoiceCommand(this, choiceIndex);
        command.Execute();
    }
}