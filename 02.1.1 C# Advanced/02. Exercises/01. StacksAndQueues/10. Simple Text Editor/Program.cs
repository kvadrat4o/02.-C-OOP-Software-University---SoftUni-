using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<string[]>();
            var appendStack = new Stack<string>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                       var arg = input[1];
                        sb.Append(arg);
                        stack.Push(input);
                        break;

                    case 2:
                        stack.Push(input);
                        var count = int.Parse(input[1]);
                        if (count > sb.Length)
                        {
                            count = sb.Length;
                        }
                        var subStr = sb.ToString().Substring(sb.Length - count, count);
                        appendStack.Push(subStr);
                        sb.Remove(sb.Length - count, count);
                        break;

                    case 3:
                        var index = int.Parse(input[1]);
                        Console.WriteLine(sb.ToString()[index-1]);
                        break;

                    case 4:
                        var todo = stack.Pop();
                        if (todo[0] == "1")
                        {
                            var toRemove = todo[1];
                            sb.Replace(toRemove, " ");
                            for (int j = 0; j < sb.Length; j++)
                            {
                                if (sb[j] == ' ')
                                {
                                    sb.Remove(j, 1);
                                }
                            }
                        }
                        else
                        {
                            var toAppend = appendStack.Pop();
                            sb.Append(toAppend);
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}