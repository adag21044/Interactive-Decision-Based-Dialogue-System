using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public DialogueTree dialogueTree;
    public DialogueNode CurrentNode { get; private set; }

    public TextMeshProUGUI dialogueText;
    public Button[] choiceButtons; // Array of buttons for choices

    void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        if (dialogueTree == null)
        {
            Debug.LogError("DialogueTree is not assigned");
            return;
        }

        CurrentNode = dialogueTree.startNode;
        DisplayCurrentDialogue();
    }

    public void SetCurrentNode(DialogueNode node)
    {
        if (node == null)
        {
            Debug.LogError("Attempted to set CurrentNode to null");
            return;
        }

        CurrentNode = node;
        DisplayCurrentDialogue();
    }

    public void DisplayCurrentDialogue()
    {
        if (CurrentNode == null)
        {
            Debug.LogError("CurrentNode is null");
            return;
        }

        dialogueText.text = CurrentNode.dialogueText;

        // Hide all choice buttons initially
        foreach (var button in choiceButtons)
        {
            button.gameObject.SetActive(false);
        }

        // Display choice buttons based on available choices
        for (int i = 0; i < CurrentNode.choices.Length; i++)
        {
            if (i < choiceButtons.Length)
            {
                choiceButtons[i].gameObject.SetActive(true); // Show button
                choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = CurrentNode.choices[i].choiceText;
                int index = i; // Local copy for lambda expression
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => MakeChoice(index));
            }
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        ICommand command = new MakeChoiceCommand(this, choiceIndex);
        command.Execute();
    }
}
