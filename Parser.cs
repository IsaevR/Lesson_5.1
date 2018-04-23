using System;
using System.Collections.Generic;
using System.Text;

namespace parser3
{
    class Parser
    {
        protected string line;
        private int index;
        
        
        public Parser(string line)
        {
            this.line = line;
            index = 0;
        }

        /// virtual используется для изменения объявлений методов,
        /// свойств, индексаторов и событий, и разрешения их переопределения
        /// в производном классе.
        public virtual int Parse(string line)
        {
            this.line = line;
            index = 0;
            return SumSub();
        }
        /// <summary>
        /// метод SumSub выполняет сложение и вычитание
        /// Если он находит фриф-е действие приоритет, которого
        /// больше, то передает управление методу MultDivd
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private int SumSub()
        {
            int num = MultDivd();
            while (index < line.Length)
            {
                if (line[index] == '+')
                {
                    index++;
                    int b = MultDivd();
                    num += b;
                }
                else if (line[index] == '-')
                {
                    index++;
                    int b = MultDivd();
                    num -= b;
                }
                else
                {
                    Console.WriteLine("Error");
                    return 0;
                }
            }

            return num;
        }
        /// <summary>
        /// Метод MultDiv выполняет умножение и деление.
        /// И возвращает "num" - значение с ответом выполненного действия, 
        /// но в случае нахождения знака факториала передает управление 
        /// в метод Factoral 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private int MultDivd()
        {
            int num = Factorial();
            while (index < line.Length)
            {
                if (line[index] == '*')
                {
                    index++;
                    int b = Factorial();
                    num *= b;
                }
                else if (line[index] =='/')
                {
                    index++;
                    int b = Factorial();
                    num /= b;
                }
                else
                {
                    return num;
                }
            }

            return num;
        }
        /// <summary>
        /// метод "Factor" вычисляет факториал. Например 5!  a=1*2*3*4*5
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private int Factorial()
        {
            int num = Num();
            while (index < line.Length)
            {
                if (line[index] == '!')
                {
                    int result = 1;
                    for (int i = 1; i <= num; i++)
                        result *= i;
                    num = result;
                }
                else
                {
                    return num;
                }
                index++;
            }
            return num;
        }
        /// <summary>
        /// метод Num определяет цыфровые символы в строке 
        /// до знака действия и возвращает переменную с числовым
        /// значением в метод "Parse" в качестве аргумента
        /// </summary>
        private int Num()
        {
            string buff = "0";
            for (; index < line.Length && char.IsDigit(line[index]); index++)
            {
                buff += line[index];
            }

            return int.Parse(buff);
        }

    }
}
