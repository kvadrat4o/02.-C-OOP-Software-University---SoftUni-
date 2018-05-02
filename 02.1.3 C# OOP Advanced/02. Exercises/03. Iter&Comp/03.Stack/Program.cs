using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> st = new Stack<int>();
            var input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                if (input.Contains("Pop"))
                {
                    st.Pop();
                }
                else if (input.Contains("Push"))
                {
                    var tokens = input.Split(new char[] { ',',' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        st.Push(int.Parse(tokens[i]));
                    }
                }
            }
            foreach (var item in st.data)
            {
                Console.WriteLine(item);
            }
            foreach (var item in st.data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
