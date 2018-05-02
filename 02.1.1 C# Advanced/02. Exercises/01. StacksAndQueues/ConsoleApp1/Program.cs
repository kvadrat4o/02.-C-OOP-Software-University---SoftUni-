using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[15];
            int[] newArr = new int[5];
            arr = newArr;
            arr[0] = 5;
            Console.WriteLine(arr.Length);
            Console.WriteLine(arr[0]);
        }
    }
}
