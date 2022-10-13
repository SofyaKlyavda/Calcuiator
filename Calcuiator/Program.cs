using System;
namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op) // присвоение числам "double"
        {
            double result = double.NaN; // если введенное значение - "не число",то может выдать ошибку, если использовать операцию значение

            switch (op) // используем оператор свитч для выполнения математических операций (сложение, вычитание, умножение, деление)
            {
                case "a": // условный оператор, если значение вводимых данных равно "а"
                    result = num1 + num2;
                    break; // выполнение завершилось
                case "s": // условный оператор, если значение вводимых данных равно "s"
                    result = num1 - num2;
                    break; // выполнение завершилось
                case "m": // условный оператор, если значение вводимых данных равно "m"
                    result = num1 * num2;
                    break; // выполнение завершилось
                case "d": // условный оператор, если значение вводимых данных равно "d"

                    if (num2 != 0) // запрещен ввод нулевого делителя
                    {
                        result = num1 / num2;
                    }
                    break;
                // возвращаем текст для неверного ввода 
                default:
                    break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Console Calculator in C#\r"); // название нашего калькулятора
            Console.WriteLine("------------------------\n"); // назание указанной строки ниже названия калькулятора
            while (!endApp)
            {

                string numInput1 = ""; // оповещение пустой переменной
                string numInput2 = ""; // оповещение пустой переменной
                double result = 0;

                Console.Write("Type a number, and then press Enter: "); // ввод первого числа
                numInput1 = Console.ReadLine(); // считывание первого числа 
                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                Console.Write("Type another number, and then press Enter: "); // ввод второго числа
                numInput2 = Console.ReadLine(); // считывание второго числа
                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2)) // цикл while
                {
                    Console.Write("This is not valid input. Please enter an integer value: "); // вывод строки "...", ввод корректного значения
                    numInput2 = Console.ReadLine(); // считывание
                }
                // выбор оператора
                Console.WriteLine("Choose an operator from the following list:"); // вывод строки "..."
                Console.WriteLine("\ta - Add"); //сложение 
                Console.WriteLine("\ts - Subtract"); // разность
                Console.WriteLine("\tm - Multiply"); // умножение
                Console.WriteLine("\td - Divide"); // деление 
                Console.Write("Your option? "); // вывод на экран строки "...",ввод нужной операции
                string op = Console.ReadLine(); // считывание введенного значения
                try // блок обработки исключительных ситуаций, возникших при выполнении нашего кода
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result); // форматированный вывод
                }
                catch (Exception e) //блок обработки исключительных ситуаций, возникших при выполнении кода
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
                Console.WriteLine("------------------------\n");
                // ввод  n и нажатие Enter перед закрытием
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true; // конструкция if выполняет блок кода, если заданное условие — истинно- true
                Console.WriteLine("\n");
            }
            return;
        }
    }
}