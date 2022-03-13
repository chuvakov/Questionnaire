namespace Questionnaire.Core.Models;

public class Answer
{
    public int Number { get; set; }
    public string Text { get; set; }
    public Question ExtraQuestion { get; set; }

    public Answer()
    {}
    
    public Answer(string text)
    {
        Text = text;
    }

    public Answer(int number, string text) : this(text)
    {
        Number = number;
    }

    public bool IsExistExtraQuestion() => ExtraQuestion != null;

    public override string ToString()
    {
        return $"{Number}: {Text}";
    }
}