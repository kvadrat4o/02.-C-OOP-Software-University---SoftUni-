using System;

namespace _03.Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var input = Console.ReadLine().Split(' ');
                var student = new Student(input[1], input[0], input[2]);

                input = Console.ReadLine().Split(' ');
                var salary = Convert.ToDecimal(input[2]);
                var hours = int.Parse(input[3]);
                var employee = new Worker(input[1], input[0], hours, salary);

                Console.WriteLine(student.ToString());
                Console.WriteLine();
                Console.WriteLine(employee.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
