using System;
using System.Collections.Generic;
using System.Linq;

public class QuizRepository
{
    private List<Question> allQuestions;

    public QuizRepository()
    {
        allQuestions = new List<Question>
        {
           new Question { Category = "Математика", Text = "Сколько будет 2 + 2?", Options = new List<string> { "3", "4", "5" }, CorrectAnswers = new List<int> { 2 } },
           new Question { Category = "Математика", Text = "Сколько будет 5 * 5 - 5?", Options = new List<string> { "20", "15", "25" }, CorrectAnswers = new List<int> { 1 } },
           new Question { Category = "Математика", Text = "Корень из 256?", Options = new List<string> { "12", "14", "16" }, CorrectAnswers = new List<int> { 3 } },
           new Question { Category = "Математика", Text = "Какое число является комплексным?", Options = new List<string> { "3i", "4^10", "5 - i" }, CorrectAnswers = new List<int> { 1, 3 } },
           new Question { Category = "Математика", Text = "Сколько будет корней у уравнения х^2 = 4 ?", Options = new List<string> { "1", "2", "0" }, CorrectAnswers = new List<int> { 2 } },
           new Question { Category = "Математика", Text = "Выберите число Пи:", Options = new List<string> { "3.14", "2.71", "1.62" }, CorrectAnswers = new List<int> { 1 } },
           new Question { Category = "Математика", Text = "Чему равны корни уравнения  'х^2 = -2' ?", Options = new List<string> { "-i, i", "-1, 1", "1" }, CorrectAnswers = new List<int> { 1 } },
           new Question { Category = "Математика", Text = "Чему равен логарифм 100 по основанию 10?", Options = new List<string> { "1", "2", "10" }, CorrectAnswers = new List<int> { 2 } },
           new Question { Category = "Математика", Text = "Сколько будет 9i * i?", Options = new List<string> { "9", "-9", "-9i ^ 2" }, CorrectAnswers = new List<int> { 2 } },
           new Question { Category = "Математика", Text = "Сколько будет 3^3 - 3 / 3?", Options = new List<string> { "8", "2", "3" }, CorrectAnswers = new List<int> { 1 } },
           new Question { Category = "Математика", Text = "Чему равен интеграл от x dx?", Options = new List<string> { "x", "x^2/2", "x^3/3" }, CorrectAnswers = new List<int> { 2 } },
           new Question { Category = "Математика", Text = "Сколько будет 15 - 7?", Options = new List<string> { "6", "7", "8" }, CorrectAnswers = new List<int> { 3 } },
           new Question { Category = "Математика", Text = "Чему равен 7 + 3?", Options = new List<string> { "9", "10", "11" }, CorrectAnswers = new List<int> { 2 } },
           new Question { Category = "Математика", Text = "Сколько будет 12 / 3?", Options = new List<string> { "3", "4", "5" }, CorrectAnswers = new List<int> { 2 } },
           new Question { Category = "Математика", Text = "Чему равен квадратный корень из 25?", Options = new List<string> { "4", "5", "6" }, CorrectAnswers = new List<int> { 2 } },
           new Question { Category = "Математика", Text = "Какие числа простые?", Options = new List<string> { "1", "2", "17" }, CorrectAnswers = new List<int> { 2, 3 } },
           new Question { Category = "Математика", Text = "Сколько будет 3 * 4?", Options = new List<string> { "11", "12", "13" }, CorrectAnswers = new List<int> { 2 } },
           new Question { Category = "Математика", Text = "Сколько будет 20 / 4?", Options = new List<string> { "4", "5", "6" }, CorrectAnswers = new List<int> { 2 } },
           new Question { Category = "Математика", Text = "Чему равен логарифм 16 по основанию 2?", Options = new List<string> { "2", "3", "4" }, CorrectAnswers = new List<int> { 3 } },
           new Question { Category = "Математика", Text = "Сколько будет 4^2?", Options = new List<string> { "14", "15", "16" }, CorrectAnswers = new List<int> { 3 } },


          new Question { Category = "История", Text = "Когда началась Вторая мировая война?", Options = new List<string> { "1914", "1939", "1945" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "История", Text = "Кто был первым президентом США?", Options = new List<string> { "Джордж Вашингтон", "Авраам Линкольн", "Томас Джефферсон" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "История", Text = "В каком году произошла Октябрьская революция в России?", Options = new List<string> { "1917", "1921", "1936" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "История", Text = "Кто был императором Франции в начале 19 века?", Options = new List<string> { "Луи XVI", "Наполеон Бонапарт", "Карл Великий" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "История", Text = "В каком году был подписан Манифест о Восстановлении монархии в Японии?", Options = new List<string> { "1853", "1868", "1895" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "История", Text = "Кто был первым человеком, ступившим на Луну?", Options = new List<string> { "Юрий Гагарин", "Нил Армстронг", "Эдвин Олдрин" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "История", Text = "В каком году была основана Римская империя?", Options = new List<string> { "27 до н.э.", "476 н.э.", "753 до н.э." }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "История", Text = "Когда началась Холодная война?", Options = new List<string> { "1945", "1950", "1960" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "История", Text = "Кто был королем Англии во время Ренессанса?", Options = new List<string> { "Генрих VIII", "Елизавета I", "Карл I" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "История", Text = "В каком году была подписана Великая хартия вольностей?", Options = new List<string> { "1066", "1215", "1492" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "История", Text = "Кто был правителем Древнего Египта в эпоху строительства пирамид?", Options = new List<string> { "Клеопатра", "Рамзес II", "Хуфу" }, CorrectAnswers = new List<int> { 3 } },
            new Question { Category = "История", Text = "Когда произошло падение Западной Римской империи?", Options = new List<string> { "395 н.э.", "410 н.э.", "476 н.э." }, CorrectAnswers = new List<int> { 3 } },
            new Question { Category = "История", Text = "Кто был основателем Монгольской империи?", Options = new List<string> { "Кублай-хан", "Чингисхан", "Тимур" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "История", Text = "Когда был создан Соединённые Штаты Америки?", Options = new List<string> { "1776", "1783", "1800" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "История", Text = "Кто был лидером Советского Союза во время Второй мировой войны?", Options = new List<string> { "Ленин", "Сталин", "Хрущёв" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "История", Text = "Когда был подписан Версальский договор?", Options = new List<string> { "1918", "1919", "1920" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "История", Text = "Кто был канцлером Германии во время Второй мировой войны?", Options = new List<string> { "Адольф Гитлер", "Отто фон Бисмарк", "Вильгельм II" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "История", Text = "Когда началась Великая французская революция?", Options = new List<string> { "1789", "1793", "1799" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "История", Text = "Кто был последним царем Российской империи?", Options = new List<string> { "Александр III", "Николай II", "Михаил Александрович" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "История", Text = "Когда было принято христианство на Руси?", Options = new List<string> { "862", "988", "1054" }, CorrectAnswers = new List<int> { 2 } },


            new Question { Category = "Искусство", Text = "Кто написал 'Мону Лизу'?", Options = new List<string> { "Ван Гог", "Леонардо да Винчи", "Пикассо" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "Искусство", Text = "Какой из этих художников был импрессионистом?", Options = new List<string> { "Моне", "Дали", "Рембрандт" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "Искусство", Text = "Кто написал 'Звездную ночь'?", Options = new List<string> { "Ван Гог", "Моне", "Сезанн" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "Искусство", Text = "Какой стиль живописи использовал Пабло Пикассо?", Options = new List<string> { "Сюрреализм", "Импрессионизм", "Кубизм" }, CorrectAnswers = new List<int> { 3 } },
            new Question { Category = "Искусство", Text = "Кто был основателем поп-арта?", Options = new List<string> { "Энди Уорхол", "Рой Лихтенштейн", "Джексон Поллок" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "Искусство", Text = "Какой художник известен своими картинами с водяными лилиями?", Options = new List<string> { "Моне", "Манэ", "Гоген" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "Искусство", Text = "Кто написал 'Утро в сосновом лесу'?", Options = new List<string> { "Айвазовский", "Шишкин", "Левитан" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "Искусство", Text = "Какой художник известен своими абстрактными картинами?", Options = new List<string> { "Мондриан", "Кандинский", "Ротко" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "Искусство", Text = "Кто написал 'Портрет Дориана Грея'?", Options = new List<string> { "Оскар Уайльд", "Джеймс Джойс", "Эдгар По" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "Искусство", Text = "Какое произведение принадлежит Микеланджело?", Options = new List<string> { "Давид", "Моисей", "Апостолы" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "Искусство", Text = "Кто написал 'Крик'?", Options = new List<string> { "Эдвард Мунк", "Ван Гог", "Гоген" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "Искусство", Text = "Какой художник известен своими картинами с часами?", Options = new List<string> { "Дали", "Миро", "Босх" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "Искусство", Text = "Кто написал 'Сикстинскую мадонну'?", Options = new List<string> { "Рафаэль", "Микеланджело", "Боттичелли" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "Искусство", Text = "Кто написал 'Гернику'?", Options = new List<string> { "Миро", "Пикассо", "Дали" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "Искусство", Text = "Кто написал 'Ночной дозор'?", Options = new List<string> { "Рембрандт", "Вермеер", "Франц Халс" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "Искусство", Text = "Какой художник был сюрреалистом?", Options = new List<string> { "Миро", "Дали", "Магритт" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "Искусство", Text = "Кто написал 'Песнь любви'?", Options = new List<string> { "Джорджио де Кирико", "Эдвард Хоппер", "Сальвадор Дали" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "Искусство", Text = "Какой художник известен своими автопортретами?", Options = new List<string> { "Рембрандт", "Фрида Кало", "Ван Гог" }, CorrectAnswers = new List<int> { 2 } },
            new Question { Category = "Искусство", Text = "Кто написал 'Сад земных наслаждений'?", Options = new List<string> { "Босх", "Рубенс", "Тициан" }, CorrectAnswers = new List<int> { 1 } },
            new Question { Category = "Искусство", Text = "Кто написал 'Последний ужин'?", Options = new List<string> { "Микеланджело", "Леонардо да Винчи", "Рафаэль" }, CorrectAnswers = new List<int> { 2 } }

        };
    }

    public List<Quiz> GetQuizzesByCategory(string category)
    {
        var questions = category == "Случайные"
            ? allQuestions.OrderBy(x => Guid.NewGuid()).Take(20).ToList()
            : allQuestions.Where(q => q.Category == category).Take(20).ToList();

        return new List<Quiz>
        {
            new Quiz
            {
                Category = category,
                Questions = questions
            }
        };
    }

    public List<string> GetQuizCategories()
    {
        return new List<string> { "Математика", "История", "Искусство", "Случайные" };
    }
}
