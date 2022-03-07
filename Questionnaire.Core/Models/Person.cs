using Questionnaire.Core.Enums;

namespace Questionnaire.Core.Models;

public class Person
{
    public string Name { get; set; }
    public Sex Sex { get; set; }
    public int Age { get; set; }
}