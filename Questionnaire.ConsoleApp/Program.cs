// See https://aka.ms/new-console-template for more information

using Questionnaire.ConsoleApp;
using Questionnaire.Core.Enums;
using Questionnaire.Core.Models;

Person person = Scanner.GetPerson();
Questionnairee questionnaire = new Questionnairee()
{
    Name = "test",
    Questions = new List<Question>()
};

var q1 = new Question()
{
    Text = "Первый вопрос",
    Type = QuestionType.Closed,
    AnswerVariants = new List<Answer>()
    {
        new Answer()
        {
            Number = 1,
            ExtraQuestion = null,
            Text = "Первый вариант ответа"
        },

        new Answer()
        {
            Number = 2,
            ExtraQuestion = new Question()
            {
                Text = "открытый вопрос",
                Type = QuestionType.Opened
            },
            Text = "Ответ с доп вопросом"
        }
    }
};

var q2 = new Question()
{
    Text = "Текст второго вопроса",
    Type = QuestionType.Opened
};

var q3 = new Question()
{
    Text = "Текст третьего вопроса(смешанный)",
    Type = QuestionType.Mixed,
    AnswerVariants = new List<Answer>()
    {
        new Answer()
        {
            Number = 1,
            ExtraQuestion = null,
            Text = "Первый вариант ответа"
        },

        new Answer()
        {
            Number = 2,
            ExtraQuestion = new Question()
            {
                Text = "текст доп вопроса",
                Type = QuestionType.Opened
            },
            Text = "Ответ с доп вопросом"
        }
    }
};        

questionnaire.AddQuestion(q1);
questionnaire.AddQuestion(q2);
questionnaire.AddQuestion(q3);

Questionnairee questionnairee2 = FileLoader.ImportQuestionnaire("test");
FileLoader.ExportQuestionnaire(questionnaire);

questionnaire.Start();
FileLoader.DownloadCompletedQuestionnaire(questionnaire);
    
Form form = new Form()
{
    Person = person
    
};