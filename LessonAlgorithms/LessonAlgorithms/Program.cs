using System;

namespace LessonAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n № \t\t Описание " +
                "\n1.1 \t\t Функция согласно блок-схеме " +
                "\n1.2 \t\t Посчитайте сложность функции" +
                "\n");
            Console.Write("Введите номер задания ");

            string command = Console.ReadLine();


            if (command == "1.1")
            {
                Console.Clear();
                Console.WriteLine(command);
                Console.WriteLine("Введите число");

                int b = Convert.ToInt32(Console.ReadLine());
                Lessons1_1 les1 = new Lessons1_1();

                Compound_Or_simple(Convert.ToDecimal(les1.Lesson1(b)));
            }

            if (command == "1.2")
            {
                Console.Clear();
                Console.WriteLine(command);
                Console.WriteLine("Если я правильно понял сложность той функции O(n 2)");
            }

            /*if(command == "2.1")
            {
                Console.Clear();
                Node_lessons_2 NodeA = new Node_lessons_2();
                
            }*/


            Console.ReadLine();

        }

        public static void Compound_Or_simple(decimal number)
        {
            int count = 0;
            decimal a = 0;
            
            for(int i = 1; i < 101; i++)
            {
                a = number / Convert.ToDecimal(i);
                if (number % i == 0)
                    count++;
                if (i < 10)
                {
                    Console.WriteLine($"Результат {i}) {number} / {i} = {a}");
                }
            }
            
            if (count > 2)
                Console.WriteLine($"Число составное");
            else
                Console.WriteLine($"Число простое");
        }
    }
}
