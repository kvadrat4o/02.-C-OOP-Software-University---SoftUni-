using Logger.Contracts;
using Logger.Factories;
using System;

namespace Logger
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var args = line.Split("|");
                string level = args[0];
                string dateTime = args[1];
                string message = args[2];

                IError error = this.errorFactory.CreateError(dateTime, level, message);

                logger.Log(error);
            }

            Console.WriteLine("Logger info");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
