public class Question
{
    public string Category { get; set; }
    public string Text { get; set; }
    public List<string> Options { get; set; }
    public List<int> CorrectAnswers { get; set; } 

    public Question()
    {
        Options = new List<string>();
        CorrectAnswers = new List<int>();
    }
}

