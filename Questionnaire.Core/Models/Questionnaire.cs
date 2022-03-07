using Questionnaire.Core.Enums;

namespace Questionnaire.Core.Models;

public class Questionnaire
{
    public string Name { get; set; }
    public List<Question> Questions { get; set; }

    private void PrintQuestion(Question question)
    {
        Console.WriteLine($"Вопрос № {question.Number}: {question.Text}");
        if (question.Type == QuestionType.Closed || question.Type == QuestionType.Mixed)
        {
            Console.WriteLine("Варианты ответов: ");
            foreach (var answer in question.AnswerVariants)
            {
                Console.WriteLine(answer);
            }
        }
        else
        {
            Console.WriteLine("Данный вопрос является открытым.");
        }
    }

    private string GetAnswer(Question question)
    {
        lableStart:
        Console.Write("Введите ваш ответ: ");
        string answer = Console.ReadLine();
        
        if (question.Type == QuestionType.Closed || question.Type == QuestionType.Mixed)
        {
            try
            {
                int selectedAnswerNumber = int.Parse(answer);

                if (!question.AnswerVariants.Any(a => a.Number == selectedAnswerNumber))
                {
                    throw new Exception();
                }
            }
            catch 
            {
                Console.WriteLine("Выбран неверный вариант ответа, попробуйте снова.");
                goto lableStart;
            }
        }
        
        return answer;
    }

    public void Start()
    {
        Console.WriteLine(Name);
        Questions = Questions
            .OrderBy(question => question.Number)
            .ToList();
        
        foreach (var question in Questions)
        {
            PrintQuestion(question);
        }
    }
}