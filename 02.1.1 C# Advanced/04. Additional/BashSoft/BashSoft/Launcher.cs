using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    class Launcher
    {
        static void Main(string[] args)
        {
            //IOManager.ChangeCurrectDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(20);
            //StudentsRepository.InitializeData();
            //StudentsRepository.GetAllStudentsFromCourse("Unity");

            //Tester.CompareContent(@"E:\Coding\SoftUni\C# Advanced\Exercises\BashSoft\BashSoft\BashSoft\test3.txt", @"E:\Coding\SoftUni\C# Advanced\Exercises\BashSoft\BashSoft\BashSoft\test2.txt");
            InputReader.StartReadingCommands();
        }
    }
}