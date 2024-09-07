using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode" , menuName = "Dialogue/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    [TextArea] public string dialogueText;
    public Choice[] choices;

    [System.Serializable]
    public class Choice
    {
        public string choiceText;
        public DialogueNode nextNode; // The next node to go to if this choice is selected
        public IChoiceStrategy choiceStrategy; // The strategy to execute when this choice is selected
    }
}