using Logger.Contracts;
using System;
using System.IO;
using System.Linq;

namespace Logger.Models
{
    public class LogFile : ILogFile
    {
        const string DEFAULT_PATH = "./data/";

        public LogFile(string fileName)
        {
            this.Path = DEFAULT_PATH + fileName;
            this.Size = 0;
            InitializeFile();
            
        }
        
        public int Size { get; private set; }

        public string Path { get; }

        public void WriteToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog + Environment.NewLine);

            int addedSize = 0;
            for (int i = 0; i < errorLog.Length; i++)
            {
                if ((errorLog[i] >= 97 && errorLog[i] <= 122) || (errorLog[i] >= 65 && errorLog[i] <= 90))
                {
                    addedSize += errorLog[i];
                }
            }

            this.Size += addedSize;
        }

        private void InitializeFile()
        {
            Directory.CreateDirectory(DEFAULT_PATH);
            File.AppendAllText(this.Path, "");
        }
    }
}
