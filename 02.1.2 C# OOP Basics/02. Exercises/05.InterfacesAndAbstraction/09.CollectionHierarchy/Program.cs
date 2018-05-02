using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCollection adds = new AddCollection();
            AddRemoveColection addrems = new AddRemoveColection();
            MyList mys = new MyList();
            StringBuilder add = new StringBuilder();
            StringBuilder addRem = new StringBuilder();
            StringBuilder addMy = new StringBuilder();
            StringBuilder remAdd = new StringBuilder();
            StringBuilder remMy = new StringBuilder();
            var input = Console.ReadLine().Split();
            for (int i = 0; i < input.Length; i++)
            {
                add.Append(adds.Add(input[i]) + " ");
                addRem.Append(addrems.Add(input[i]) + " ");
                addMy.Append(mys.Add(input[i]) + " ");
            }
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                remAdd.Append(addrems.Remove() + " ");
                remMy.Append(mys.Remove() + " ");
            }
            Console.WriteLine($"{add.ToString().TrimEnd()}\n{addRem.ToString().TrimEnd()}\n{addMy.ToString().TrimEnd()}\n{remAdd.ToString().TrimEnd()}\n{remMy.ToString().TrimEnd()}");
        }
    }
}
