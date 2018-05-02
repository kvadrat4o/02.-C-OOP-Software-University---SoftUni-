namespace Logger
{
    using Logger.Contracts;
    using Logger.Factories;
    using Logger.Models;
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            ErrorFactory errorFactory = new ErrorFactory();
            ILogger logger = InitializeLogger();
            Engine engine = new Engine(logger, errorFactory);
            
            engine.Run();
        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);
           
            int appenderCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appenderCount; i++)
            {
                string[] input = Console.ReadLine().Split();

                var appenderType = input[0];
                var layoutType = input[1];
                var errorLevel = "INFO";

                if (input.Length == 3)
                {
                    errorLevel = input[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }

            return new Logger(appenders);
        }
    }
}
