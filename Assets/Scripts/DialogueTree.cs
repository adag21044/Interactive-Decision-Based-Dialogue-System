using UnityEngine;

/// <summary>
/// Factory for creating dialogue trees.
/// </summary>
[CreateAssetMenu(fileName = "DialogueTree", menuName = "Dialogue/DialogueTree")]
public class DialogueTree : ScriptableObject
{
    public DialogueNode startNode; // The starting node of the dialogue tree

    /// <summary>
    /// Creates a new dialogue tree with the specified root node.
    /// </summary>
    /// <param name="rootNode">The root node of the dialogue tree.</param>
    /// <returns>The created DialogueTree.</returns>
    public static DialogueTree CreateTree(DialogueNode rootNode)
    {
        DialogueTree tree = ScriptableObject.CreateInstance<DialogueTree>();
        tree.startNode = rootNode;
        return tree;
    }
}
