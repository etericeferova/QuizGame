using System;

public class QuizResult
{
    public required string Username { get; set; }
    public string? QuizCategory { get; set; }
    public int CorrectAnswers { get; set; }
    public DateTime DateTaken { get; set; }
}
