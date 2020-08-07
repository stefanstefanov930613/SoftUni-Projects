using System;
using System.Security.Cryptography;
using System.Threading;

namespace WordLearner
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[] { "Отделение", "Предложение, Оферта",
                "Обява, обявление", "Легло, креват", "Книга", "Диван", "Жител, обитател", "Приземен етаж, партер", "Колело", "Цвят",
            "Фотоапарат", "Пари", "Разговор, беседа", "Стъкло", "Големина, размер", "Половина", "Столица", "Домакинство",
            "Каса", "Козметика", "Кухня", "Хладилник", "Клиент", "Милион", "Мебел", "Бележка, съобщение", "Цена, стойност," +
            "Процент", "Квадратен км", "Рафт", "Шкаф, гардероб", "Кресло, фотьойл", "Стоки с голямо намаление", "Прахосмукачка",
            "Етаж, под на жилище", "Стол", "Час, учебен час", "Част", "Килим", "Маса, трапеза", "Тенджера, гърне", "Продавач",
            "Четвърт, четвъртинка", "Валута", "Пералня", "Реклама", "Списание", "Вестник", "Състояние, положение"};

            Random rand = new Random();
             
            while (true)
            {
               
                Console.Clear();
                var nextWord = rand.Next(0, words.Length - 1);
                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.Enter)
                {
                    Console.Write(words[nextWord]);

                    Console.ReadKey();
                }
                  
            }


        }
    }
}
