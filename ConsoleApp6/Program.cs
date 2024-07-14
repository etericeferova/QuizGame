using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static UserRepository userRepository = new UserRepository();
    private static QuizRepository quizRepository = new QuizRepository();
    private static User? currentUser;

    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать!");

        while (true)
        {
            ShowMainMenu();
            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;
                case 3:
                    Console.WriteLine("До свидания и до скорой встречи!");
                    return;
            }

            if (currentUser != null)
            {
                ShowUserMenu();
            }
        }
    }

    private static void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Войти");
        Console.WriteLine("2. Зарегистрироваться");
        Console.WriteLine("3. Выйти");
    }

    private static void ShowUserMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Начать новую викторину");
            Console.WriteLine("2. Посмотреть результаты прошлых викторин");
            Console.WriteLine("3. Посмотреть Топ-20 по конкретной категории");
            Console.WriteLine("4. Изменить настройки");
            Console.WriteLine("5. Выйти");

            int menuChoice = GetChoice(1, 5);

            switch (menuChoice)
            {
                case 1:
                    StartNewQuiz();
                    break;
                case 2:
                    ViewPastQuizResults();
                    break;
                case 3:
                    ViewTopQuizResults();
                    break;
                case 4:
                    ChangeSettings();
                    break;
                case 5:
                    Console.WriteLine("Выход из аккаунта.");
                    currentUser = null;
                    return;
            }
        }
    }

    private static void StartNewQuiz()
    {
        Console.Clear();
        List<string> categories = quizRepository.GetQuizCategories();
        Console.WriteLine("Выберите категорию викторины:");

        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i]}");
        }

        int categoryChoice = GetChoice(1, categories.Count) - 1;
        string selectedCategory = categories[categoryChoice];

        List<Quiz> quizzes = quizRepository.GetQuizzesByCategory(selectedCategory);

        int correctAnswers = 0;

        foreach (var quiz in quizzes)
        {
            Console.Clear();
            Console.WriteLine($"Викторина по категории: {quiz.Category}");
            foreach (var question in quiz!.Questions!)
            {
                Console.WriteLine(question.Text);
                for (int i = 0; i < question.Options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Options[i]}");
                }

                Console.Write("Введите номер или же номера правильного(ых) ответа(ов) через запятую: ");
                string answerInput = Console.ReadLine()!;
                var userAnswers = answerInput.Split(',').Select(int.Parse).ToList();

                bool isCorrect = question.CorrectAnswers.All(userAnswers.Contains) && question.CorrectAnswers.Count == userAnswers.Count;

                if (isCorrect)
                {
                    correctAnswers++;
                    Console.WriteLine("И это правильный ответ!");
                }
                else
                {
                    Console.WriteLine("Увы, но это неправильный ответ.");
                }
                Console.ReadLine();
            }
        }

        QuizResult result = new QuizResult
        {
            Username = currentUser!.Username!,
            QuizCategory = selectedCategory,
            CorrectAnswers = correctAnswers,
            DateTaken = DateTime.Now
        };

        userRepository.AddQuizResult(result);
        Console.WriteLine($"Викторина завершена. Ваш результат: {correctAnswers} правильных ответов.");
        Console.ReadLine();
    }

    private static void ViewPastQuizResults()
    {
        Console.Clear();
        List<QuizResult> results = userRepository.GetResultsByUsername(currentUser!.Username!);

        if (results.Count == 0)
        {
            Console.WriteLine("У вас нет прошлых результатов викторин.");
        }
        else
        {
            Console.WriteLine("Ваши прошлые результаты викторин:");
            foreach (var result in results)
            {
                Console.WriteLine($"Категория: {result.QuizCategory}, Правильные ответы: {result.CorrectAnswers}, Дата: {result.DateTaken}");
            }
        }
        Console.ReadLine();
    }

    private static void ViewTopQuizResults()
    {
        Console.Clear();
        List<string> categories = quizRepository.GetQuizCategories();
        Console.WriteLine("Выберите категорию викторины для просмотра Топ-20 результатов:");

        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i]}");
        }

        int categoryChoice = GetChoice(1, categories.Count) - 1;
        string selectedCategory = categories[categoryChoice];

        List<QuizResult> topResults = userRepository.GetTopResultsByCategory(selectedCategory);

        if (topResults.Count == 0)
        {
            Console.WriteLine("Для данной категории результатов нет.");
        }
        else
        {
            Console.WriteLine($"Топ-20 результатов по категории {selectedCategory}:");
            for (int i = 0; i < topResults.Count; i++)
            {
                var result = topResults[i];
                Console.WriteLine($"{i + 1}. {result.Username} - {result.CorrectAnswers} правильных ответов - {result.DateTaken}");
            }
        }
        Console.ReadLine();
    }

    private static void ChangeSettings()
    {
        Console.Clear();
        Console.WriteLine("Изменение настроек:");
        Console.WriteLine("1. Изменить пароль");
        Console.WriteLine("2. Изменить дату рождения");

        int choice = GetChoice(1, 2);

        switch (choice)
        {
            case 1:
                ChangePassword();
                break;
            case 2:
                ChangeDateOfBirth();
                break;
        }

        userRepository.SaveUsers();
        Console.ReadLine();
    }

    private static void ChangePassword()
    {
        Console.Write("Введите новый пароль: ");
        string newPassword = Console.ReadLine()!;
        currentUser!.PasswordHash = newPassword;
        Console.WriteLine("Пароль изменен.");
    }

    private static void ChangeDateOfBirth()
    {
        Console.Write("Введите новую дату рождения (ГГГ-ММ-ДД): ");
        DateTime newDateOfBirth;
        while (!DateTime.TryParse(Console.ReadLine(), out newDateOfBirth))
        {
            Console.Write("Неправильный формат даты. Попробуйте снова (ГГГ-ММ-ДД): ");
        }
        currentUser!.DateOfBirth = newDateOfBirth;
        Console.WriteLine("Дата рождения изменена.");
    }

    static bool IsPasswordStrong(string password)
    {
        if (password.Length < 8)
            return false;

        bool hasUpperCase = false;
        bool hasLowerCase = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c))
                hasUpperCase = true;
            else if (char.IsLower(c))
                hasLowerCase = true;
        }

        if (!hasUpperCase || !hasLowerCase)
            return false;

        return true;
    }


    private static void Login()
    {
        Console.Clear();
        Console.Write("Введите логин: ");
        string username = Console.ReadLine()!;
        Console.Write("Введите пароль: ");
        string password = Console.ReadLine()!;

        currentUser = userRepository.AuthenticateUser(username, password);

        if (currentUser == null)
        {
            Console.WriteLine("Неправильный логин или пароль.");
        }
        else
        {
            Console.WriteLine($"Добро пожаловать, {currentUser.Username}, рады вас приветствовать!");
        }
        Console.ReadLine();
    }

    private static void Register()
    {
        Console.Clear();
        Console.Write("Введите логин: ");
        string username = Console.ReadLine()!;

        if (userRepository.IsUsernameTaken(username))
        {
            Console.WriteLine("Этот логин уже занят, попробуйте другой.");
            return;
        }

        Console.Write("Введите пароль (P.s: он должен состоять из 8 символов, включая хотя бы одну заглавную и одну строчную букву): ");
        string password = Console.ReadLine()!;

        while (!IsPasswordStrong(password!))
        {
            Console.WriteLine("Пароль не соответствует требованиям (должен состоять из 8 символов, включая хотя бы одну заглавную и одну строчную букву)");
            Console.Write("Введите пароль еще раз: ");
            password = Console.ReadLine()!;
        }



        Console.Write("Введите дату рождения по формату (ГГГ-ММ-ДД): ");
        DateTime dateOfBirth;
        while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
        {
            Console.Write("Неправильный формат даты. Попробуйте еще раз (ГГГ-ММ-ДД): ");
        }

        User newUser = new User
        {
            Username = username,
            PasswordHash = password,
            DateOfBirth = dateOfBirth
        };

        userRepository.RegisterUser(newUser);
        Console.WriteLine("Регистрация завершена успешно, удачной вам игры!");
        Console.ReadLine();
    }

    private static int GetChoice(int min, int max)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
        {
            Console.WriteLine($"Введите число от {min} до {max}: ");
        }
        return choice;
    }
}


