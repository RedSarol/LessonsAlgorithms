using System;
using System.Collections.Generic;
using System.Text;

namespace LessonAlgorithms
{
    class Lessons1_1
    {
        public int Lesson1(int _number)
        {
            int d = 0;
            int i = 2;

            while (i < _number)
            {
                if (_number % i == 0)
                {
                    d++;
                }
                i++;

            }
            {
                if (d == 0)
                {
                    Console.WriteLine("Простое");
                    return _number;
                }
                else
                {
                    Console.WriteLine("Не простое");
                    return _number;
                }
            }

        }

    }
}
