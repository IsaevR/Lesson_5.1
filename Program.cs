using System;

namespace parser3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\n\t\t\tПрограмма Parser приветствует Вас!");         
            Console.WriteLine("\n\n\t\tПоддерживаемые операции: +, -, *, /, !(факториал)");
            Console.WriteLine("\t\t  Для начала работы введите числовые выражения.\n\n\n");

            char ch = 'y';
            do
            {
                var str = Console.ReadLine();
                Parser parser = new Parser(str);
                Console.Write("\b = {0}", parser.Parse(str));

                Console.Write("\n\t\t\t Продолжить работу программы ? y/n: \b");
                ch = char.Parse(Console.ReadLine());
                int end = 3;    // количество попыток при котором программа завершит работу
                int count = 0;  // хранения количества попыток пользователя ввести необходимый символ

                // Цыкл предназначен для обработки введенных пользователем
                while (ch != 'y' && ch != 'n')
                {
                    Console.Beep();
                    Console.Beep();
                    Console.Write("\n\n\t\t\t\tВведите \"y\" или \"n\":  \b");
                    ch = char.Parse(Console.ReadLine());
                    count++;
                    if (count >= end)
                    {
                        Console.WriteLine("\n\n\t\t\t\tИзвините! Вы не подтвердили действия."+
                            "\n\n\t\t\t\t Программа завершена.");
                        break;
                    }
                }
 
            }
            while (ch == 'y');
        }   
        
    }
}
