using CustomLibrary;

namespace Hashtable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int answer = 0;
            Hashtable<string, Emoji> hashtable = new Hashtable<string, Emoji>();
            hashtable = hashtable.Clear(); 

            while (true)
            {
                Console.Write("Данная программа осуществляет действия над хеш-таблицей с парой ключ - значение(string, Emoji). Коллизии разрешаются путем прямой адресации.");
                if (hashtable.Count > 0 )
                {
                    Console.Write($"На данный момент в таблице {hashtable.Count} элементов\n"); 
                }
                else
                {
                    Console.Write($"На данный момент в таблице нет элементов\n");
                }
                Console.WriteLine("Выберите одно из действий над таблицей\n");

                Console.WriteLine("1) Распечатать таблицу");
                Console.WriteLine("2) Заполнить полностью таблицу случайными элементами(прошлые элементы удалятся)");
                Console.WriteLine("3) Найти объект по имени");
                Console.WriteLine("4) Удалить объект по имени");
                Console.WriteLine("5) Добавить случайный объект");

                answer = ChooseAnswer(1, 5);
                switch (answer)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(hashtable.ToString());
                        break;

                    case 2:
                        Console.Clear();
                        hashtable = RandomInit(hashtable);
                        Console.WriteLine("Таблица инициализирована");
                        break;

                    case 3:
                        Console.Clear();
                        if (hashtable.Count > 0)
                        {
                            string? name;
                            Console.WriteLine("Введите имя для поискка: ");
                            name = Console.ReadLine();
                            answer = hashtable.FindItem(name);
                            if (answer > 0)
                            {
                                Console.WriteLine($"Объект с таким именем находится на позиции {answer}");
                            }
                            else
                            {
                                Console.WriteLine("Объекта с таким именем нет");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Таблица пуста");
                        }
                        break;

                    case 4:
                        Console.Clear();
                        if (hashtable.Count > 0)
                        {
                            Console.WriteLine("Введите имя для удаления:");
                            string ans = Console.ReadLine();
                            try
                            {
                                hashtable = hashtable.Delete(ans);
                            }
                            catch(Exception e){ Console.WriteLine(e.Message); }
                        }
                        else
                        {
                            Console.WriteLine("Таблица пуста");
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Emoji emoji = new Emoji();
                        bool ok = true;
                        while (ok)
                        {
                            try
                            {
                                emoji.RandomInit();
                                emoji.Name += "(добавленный)";
                                hashtable = hashtable.AddItem(emoji.Name, emoji);
                                Console.WriteLine("Элемент добавлен");
                                ok = false;
                            }
                            catch (Exception e) { }
                        }
                        break;
                    default: break;

                }
            }
            
            
            
            
        }

        static int ChooseAnswer(int a, int b)   //выбор действия из целых
        {
            int answer = 0;
            bool checkAnswer;
            do
            {
                checkAnswer = int.TryParse(Console.ReadLine(), out answer);
                if ((answer > b || answer < a) || (!checkAnswer))
                {
                    Console.WriteLine("Вы некорректно ввели число, повторите ввод еще раз. Обратите внимание на то, что именно нужно ввести.");
                }
            } while ((answer > b || answer < a) || (!checkAnswer));

            return answer;
        }

        static Hashtable<string, Emoji> RandomInit(Hashtable<string, Emoji> hashtable)
        {
            hashtable.Clear();

            for (int i = 0; i < 7; i++)
            {
                Emoji emoji = new Emoji();
                emoji.RandomInit();
                try
                {
                    hashtable = hashtable.AddItem(emoji.Name, emoji);
                }
                catch { i--;  }
            }
            return hashtable;
        }
    }
}
