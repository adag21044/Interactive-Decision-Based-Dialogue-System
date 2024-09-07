/// <summary>
/// Interface for strategy to handle dialogue choices.
/// </summary>
public interface IChoiceStrategy 
{
    void ExecuteChoice(DialogueManager manager, int choiceIndex);
}
