using Questionnaire.Core.Enums;

namespace Questionnaire.Core.Models;

public class Question
{
    public int Number { get; set; }
    public string Text { get; set; }
    public QuestionType Type { get; set; }
    public List<Answer> AnswerVariants { get; set; }
    public int SelectedAnswerNumber { get; set; }
}
