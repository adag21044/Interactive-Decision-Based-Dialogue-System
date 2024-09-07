using UnityEngine;

/// <summary>
/// Represents a node in the dialogue tree with its text and choices.
/// </summary>
[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    [TextArea] public string dialogueText; // The text of the dialogue node
    public Choice[] choices; // Choices available at this node

    [System.Serializable]
    public class Choice
    {
        public string choiceText; // The text for the choice
        public DialogueNode nextNode; // The next node to transition to if this choice is selected
        public IChoiceStrategy choiceStrategy; // The strategy to execute when this choice is selected
    }
}
