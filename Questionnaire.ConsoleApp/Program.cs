// See https://aka.ms/new-console-template for more information

using Questionnaire.ConsoleApp;
using Questionnaire.Core.Enums;
using Questionnaire.Core.Models;

Person person = Scanner.GetPerson();
Form form = new Form()
{
    Person = person
    
};