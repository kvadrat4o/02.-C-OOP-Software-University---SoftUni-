using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Crypto_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var maxSequence = 0;
            for (int step = 1; step < input.Length; step++)
            {
                for (int index = 0; index < input.Length; index ++)
                {
                    var currentSequence = 1;
                    var currIndex = index;
                    var nextIndex = (index + step ) % input.Length;
                    while (input[currIndex]  < input[nextIndex])
                    {
                        currIndex = nextIndex;
                        nextIndex = (currIndex + step ) % input.Length;
                        currentSequence++;
                    }
                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                    }
                }
            }
            Console.WriteLine(maxSequence);
        }
    }
}
