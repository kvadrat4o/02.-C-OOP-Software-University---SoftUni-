﻿using BashSoft.Exceptions;
using SimpleJudge;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BashSoft.IO.Commands
{
    class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager):
            base(input, data, judge, repository, inputOutputManager)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
                
            }
            var fileName = this.Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}
