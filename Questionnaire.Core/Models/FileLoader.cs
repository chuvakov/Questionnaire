using Newtonsoft.Json;
using Questionnaire.Core.Enums;

namespace Questionnaire.Core.Models;

public static class FileLoader
{
    private const string PATH_TO_FILES = @"C:\Users\a.chuvakov\RiderProjects\Questionnaire\Questionnaire.ConsoleApp\Files";
    
    public static void DownloadCompletedQuestionnaire(Questionnairee questionnairee)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(PATH_TO_FILES, "CompletedQestionnaireas", $"{questionnairee.Name}.txt")))
        {
            sw.WriteLine("Название опроса: " + questionnairee.Name);
            sw.WriteLine("Колличество вопросов: " + questionnairee.Questions.Count);
            sw.WriteLine();
            
            foreach (var question in questionnairee.Questions)
            {
                PrintQuestion(question, sw);

                if (question.SelectedAnswer.IsExistExtraQuestion())
                {
                    PrintQuestion(question.SelectedAnswer.ExtraQuestion, sw, true);
                }
            }
        }
    }

    private static void PrintQuestion(Question question, StreamWriter sw, bool isExtraQuestion = false)
    {
        string prefix = isExtraQuestion ? "Доп.вопрос" : $"{question.Number}. Вопрос";
        
        if (question.Type == QuestionType.Opened)
        {
            sw.WriteLine($"{prefix} (открытый): {question.Text}");
            sw.WriteLine($"Ответ: {question.SelectedAnswer.Text}\n");
            return;
        }
                
        sw.WriteLine($"{prefix}: {question.Text}");
        sw.WriteLine("\nВарианты ответа: ");
                
        foreach (var answer in question.AnswerVariants)
        {
            if (answer == question.SelectedAnswer)
            {
                sw.WriteLine($"{answer.Number}. {answer.Text} (Выбранный)");
            }
            else if (answer.Text == "Ответить самому" && question.SelectedAnswer.Number == 0)
            {
                sw.WriteLine($"{answer.Number}. {answer.Text} (Выбранный)");
                sw.WriteLine("Ответ: " + question.SelectedAnswer.Text);
            }
            else
            {
                sw.WriteLine($"{answer.Number}. {answer.Text}");
            }
        }
                
        sw.WriteLine();
    }

    public static void ExportQuestionnaire(Questionnairee questionnairee)
    {
        using (var sw = new StreamWriter(Path.Combine(PATH_TO_FILES, "Templates", $"{questionnairee.Name}.txt")))
        {
            sw.WriteLine(JsonConvert.SerializeObject(questionnairee));
        }
    }
    
    public static Questionnairee ImportQuestionnaire(string fileName)
    {
        Questionnairee questionnairee = null;
        
        using (var sr = new StreamReader(Path.Combine(PATH_TO_FILES, "Templates", $"{fileName}.txt")))
        {
            questionnairee = JsonConvert.DeserializeObject<Questionnairee>(sr.ReadLine());
        }

        return questionnairee;
    }
}