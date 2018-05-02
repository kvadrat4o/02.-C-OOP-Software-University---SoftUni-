using System;
using System.Collections;
using System.Collections.Generic;

namespace _01._ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input);
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }

        }
    }
}
