using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Manages the dialogue system, including displaying dialogue and handling player choices.
/// </summary>
public class DialogueManager : MonoBehaviour
{
    public DialogueTree dialogueTree; // The root dialogue tree
    public DialogueNode CurrentNode { get; private set; } // Current node in the dialogue tree

    public TextMeshProUGUI dialogueText; // Text component for displaying dialogue
    public Button[] choiceButtons; // Array of buttons for player choices
    public float choiceTextFontSize = 20f; // Default font size for choices

    private void Start()
    {
        StartDialogue();
    }

    /// <summary>
    /// Starts the dialogue by setting the initial node and displaying it.
    /// </summary>
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

    /// <summary>
    /// Sets the current dialogue node and updates the display.
    /// </summary>
    /// <param name="node">The new dialogue node to set.</param>
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

    /// <summary>
    /// Displays the current dialogue and updates choice buttons based on the current node.
    /// </summary>
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
                var buttonText = choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    buttonText.text = CurrentNode.choices[i].choiceText;
                    buttonText.fontSize = choiceTextFontSize;
                }
                else
                {
                    Debug.LogError("TextMeshProUGUI component not found on button " + i);
                }

                int index = i; // Local copy for lambda expression
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => MakeChoice(index));
            }
            else
            {
                Debug.LogError("Not enough buttons assigned for the choices.");
            }
        }
    }

    /// <summary>
    /// Executes a choice based on the index provided.
    /// </summary>
    /// <param name="choiceIndex">The index of the choice to execute.</param>
    public void MakeChoice(int choiceIndex)
    {
        ICommand command = new MakeChoiceCommand(this, choiceIndex);
        command.Execute();
    }
}
