using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> nums = new Queue<int>();
            int n = int.Parse(Console.ReadLine());
            nums.Enqueue(n);
            
            for (int i = 0; i < 49 / 3; i++)
            {
                int num2 = n + 1;
                nums.Enqueue(num2);
                nums.Enqueue(2 * num2 + 1);
                nums.Enqueue(num2 + 2);
            }
        }
    }
}
