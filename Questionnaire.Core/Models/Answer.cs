namespace Questionnaire.Core.Models;

public class Answer
{
    public int Number { get; set; }
    public string Text { get; set; }
    public Question ExtraQuestion { get; set; }

    public override string ToString()
    {
        return $"{Number}: {Text}";
    }
}