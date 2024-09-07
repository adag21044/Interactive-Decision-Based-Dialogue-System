// Strategy interface for handling dialogue choices
public interface IChoiceStrategy 
{
    void ExecuteChoice(DialogueManager manager, int choiceIndex);
}
