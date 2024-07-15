using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class UserRepository
{
    private const string UsersFilePath = "users.txt";
    private const string ResultsFilePath = "results.txt";
    private const string CategoriesFilePath = "categories.txt";
    private const string QuestionsFilePath = "questions.txt";

    private List<string> quizCategories;
    private List<User> users;
    private List<QuizResult> results;
    private List<Question> questions;

    public UserRepository()
    {
        users = new List<User>();
        results = new List<QuizResult>();
        quizCategories = new List<string>();
        questions = LoadQuestions(); 
        LoadUsers();
        LoadResults();
        LoadQuizCategories();
    }

    // работа с пользователем
    public void RegisterUser(User newUser)
    {
        users.Add(newUser);
        SaveUsers();
    }



    public User AuthenticateUser(string username, string password)
    {
        if (username == null) throw new ArgumentNullException(nameof(username));
        if (password == null) throw new ArgumentNullException(nameof(password));

        return users!.FirstOrDefault(u => u.Username == username && u.PasswordHash == password)!;
    }


    public bool IsUsernameTaken(string username)
    {
        return users.Any(u => u.Username == username);
    }

    // работа с результатами викторины
    public void AddQuizResult(QuizResult result)
    {
        results.Add(result);
        SaveResults();
    }

    public List<QuizResult> GetResultsByUsername(string username)
    {
        return results.Where(r => r.Username == username).ToList();
    }

    public List<QuizResult> GetTopResultsByCategory(string category)
    {
        return results
            .Where(r => r.QuizCategory == category)
            .OrderByDescending(r => r.CorrectAnswers)
            .ThenBy(r => r.DateTaken)
            .Take(20)
            .ToList();
    }

    // работа с категориями викторин
    public List<string> GetQuizCategories()
    {
        if (quizCategories == null)
        {
            LoadQuizCategories(); 
        }
        return quizCategories!;
    }

    private void LoadQuizCategories()
    {
        if (File.Exists(CategoriesFilePath))
        {
            try
            {
                quizCategories = File.ReadAllLines(CategoriesFilePath).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке категорий викторин: {ex.Message}");
                quizCategories = new List<string>(); //  если будет ошибка загрузки то создаем пустой список
            }
        }
        else
        {
            Console.WriteLine("Файл с категориями викторин не найден.");
            quizCategories = new List<string>(); // создаем пустой список если файл не существует
        }
    }

    // работа с вопросами
    public List<Question> LoadQuestions()
    {
        List<Question> questions = new List<Question>();

        try
        {
            string[] lines = File.ReadAllLines(QuestionsFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                string category = parts[0];
                string text = parts[1];
                List<string> options = parts[2].Split(',').ToList();
                List<int> correctAnswers = parts[3].Split(',').Select(int.Parse).ToList();

                Question question = new Question
                {
                    Category = category,
                    Text = text,
                    Options = options,
                    CorrectAnswers = correctAnswers
                };

                questions.Add(question);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при загрузке вопросов: {ex.Message}");
        }

        return questions;
    }

    public void SaveQuestions(List<Question> questions)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(QuestionsFilePath))
            {
                foreach (Question question in questions)
                {
                    string optionsString = string.Join(",", question.Options);
                    string correctAnswersString = string.Join(",", question.CorrectAnswers);
                    writer.WriteLine($"{question.Category}|{question.Text}|{optionsString}|{correctAnswersString}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при сохранении вопросов: {ex.Message}");
        }
    }

    public List<Question> GetQuestionsByCategory(string category)
    {
        return questions.Where(q => q.Category == category).ToList();
    }

    //...
    private void LoadUsers()
    {
        if (File.Exists(UsersFilePath))
        {
            try
            {
                string[] lines = File.ReadAllLines(UsersFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string username = parts[0];
                    string passwordHash = parts[1];
                    DateTime dateOfBirth = DateTime.Parse(parts[2]);

                    users.Add(new User
                    {
                        Username = username,
                        PasswordHash = passwordHash,
                        DateOfBirth = dateOfBirth
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке пользователей: {ex.Message}");
            }
        }
    }

    private void LoadResults()
    {
        if (File.Exists(ResultsFilePath))
        {
            try
            {
                string[] lines = File.ReadAllLines(ResultsFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string username = parts[0];
                    string quizCategory = parts[1];
                    int correctAnswers = int.Parse(parts[2]);
                    DateTime dateTaken = DateTime.Parse(parts[3]);

                    results.Add(new QuizResult
                    {
                        Username = username,
                        QuizCategory = quizCategory,
                        CorrectAnswers = correctAnswers,
                        DateTaken = dateTaken
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при загрузке результатов: {ex.Message}");
            }
        }
    }


    public void SaveUsers()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(UsersFilePath))
            {
                foreach (User user in users)
                {
                    writer.WriteLine($"{user.Username},{user.PasswordHash},{user.DateOfBirth}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при сохранении пользователей: {ex.Message}");
        }
    }

    public void SaveResults()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(ResultsFilePath))
            {
                foreach (QuizResult result in results)
                {
                    writer.WriteLine($"{result.Username},{result.QuizCategory},{result.CorrectAnswers},{result.DateTaken}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при сохранении результатов: {ex.Message}");
        }
    }
}

