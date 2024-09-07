using UnityEngine;

//Factory for creating dialogue trees
[CreateAssetMenu(fileName = "DialogueTree", menuName = "Dialogue/DialogueTree")]
public class DialogueTree : ScriptableObject
{
    public DialogueNode startNode;

    public static DialogueTree CreateTree(DialogueNode rootNode)
    {
        DialogueTree tree = ScriptableObject.CreateInstance<DialogueTree>();
        tree.startNode = rootNode;
        return tree;
    }
}