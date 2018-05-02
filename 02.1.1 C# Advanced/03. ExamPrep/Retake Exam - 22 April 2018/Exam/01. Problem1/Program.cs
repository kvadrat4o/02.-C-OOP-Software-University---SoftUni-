namespace _01._Problem1
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> carsQueue = new Queue<string>();
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            var input = "";
            int secondsLeft = greenLightDuration;
            var charsFromCarPassed = 0;
            int carsSafelyPassedCount = 0;
            int initialQueueCount = 0;
            int allCarsLengths = 0;
            int initialWindowDurration = freeWindowDuration;
            bool hasCrashed = false;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input.Equals("green"))
                {
                    
                    for (int i = 0; i < initialQueueCount; i++)
                    {
                        if (secondsLeft == 0)
                        {
                            break;
                        }
                        if (carsQueue.Peek().Length <= secondsLeft)
                        {
                            secondsLeft -= carsQueue.Peek().Length;
                            carsQueue.Dequeue();
                            carsSafelyPassedCount++;
                        }
                        else
                        {
                            if (freeWindowDuration < initialWindowDurration)
                            {
                                break;
                            }
                            //else if(freeWindowDuration == initialWindowDurration)
                            //{
                            //    continue;
                            //}
                            charsFromCarPassed = Math.Abs(carsQueue.Peek().Length - secondsLeft);
                            secondsLeft = Math.Max(0,(secondsLeft - carsQueue.Peek().Length));
                            if (freeWindowDuration >= charsFromCarPassed)
                            {
                                carsQueue.Dequeue();
                                carsSafelyPassedCount++;
                                freeWindowDuration = freeWindowDuration - charsFromCarPassed;

                            }
                            else
                            {
                                var hitPoint = carsQueue.Peek().Length - freeWindowDuration;
                                Console.WriteLine($"A crash happened!" + Environment.NewLine + $"{carsQueue.Peek()} was hit at {carsQueue.Peek()[charsFromCarPassed - 1]}.");
                                hasCrashed = true;
                                break;
                            }
                        }
                    }
                    secondsLeft = greenLightDuration;
                }
                else
                {
                    carsQueue.Enqueue(input);
                    initialQueueCount = carsQueue.Count;
                }
                if (hasCrashed)
                {
                    break;
                }
            }
            if (hasCrashed == false)
            {
                Console.WriteLine("Everyone is safe." + Environment.NewLine + $"{carsSafelyPassedCount} total cars passed the crossroads.");
            }
        }
    }
}
