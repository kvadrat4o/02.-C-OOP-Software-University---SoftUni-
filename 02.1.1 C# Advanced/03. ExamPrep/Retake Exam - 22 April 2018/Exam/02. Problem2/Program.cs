namespace _02._Problem2
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var parkingTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int rows = parkingTokens[0];
            int cols = parkingTokens[1];
            string[,] parking = new string[2 * rows - 1, cols + 2];
            //FillParking(parking);
            int samEntranceNumber = int.Parse(Console.ReadLine());
            var samEntranceCoordinates = "";
            if (samEntranceNumber == 1)
            { 
                parking[1, 0] = "X";
                samEntranceCoordinates = parking[1, 0];
            }
            else if(samEntranceNumber == 2)
            {
                parking[3, 0] = "X";
                samEntranceCoordinates = parking[3,0];
            }
            else
            {
                parking[5, 0] = "X";
                samEntranceCoordinates = parking[5, 0];
            }
            bool hasParked = false;
            int distanceTravelled = 0;
            
            while (hasParked == false)
            {
                var  input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var samPlaceTokens = input[0];
                //var initLocation = parking[samEntrance, 0];
                for (int row = 0; row < parking.GetLength(0); row++)
                {
                    for (int col = 0; col < parking.GetLength(1); col++)
                    {
                        if (parking[row-1,col] == samPlaceTokens)
                        {
                             samEntranceCoordinates = samPlaceTokens;
                            distanceTravelled += col;
                            Console.WriteLine($"Parked successfully at C1." + Environment.NewLine + $"Total Distance Passed: {distanceTravelled}");
                        }
                    }
                }
            }
        }

        //private static void FillParking(string[,] parking)
        //{
        //    for (int row = 0; row < parking.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < parking.GetLength(1); col++)
        //        {
        //            if (parking[row,col] == )
        //            {

        //            }
        //        }
        //    }
        //}
    }
}
