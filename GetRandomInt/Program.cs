using System;
using System.Diagnostics;


namespace GetRandomInt
{
    class MainClass
    {
        public const int MIN_VALUE_LIMIT = 0;
        public const int MAX_VALUE_LIMIT = 100000;

        public static void Main(string[] args)
        {
            Console.WriteLine("Command: min max calls");
            Console.WriteLine("Example: 1 10 20");
            Console.WriteLine("1  - min");
            Console.WriteLine("10 - max");
            Console.WriteLine("20 - number of calls to GetRandomInt(min,max)");
            Console.WriteLine();
            Console.WriteLine("Enter command:");

            string input;
            while ((input = Console.ReadLine()) != null)
            {
                string[] command = input.Split(' ');
                int min, max, calls;
                int.TryParse(command[0], out min);
                int.TryParse(command[1], out max);
                int.TryParse(command[2], out calls);

                min = min < MIN_VALUE_LIMIT ? MIN_VALUE_LIMIT : min;
                max = max > MAX_VALUE_LIMIT ? MAX_VALUE_LIMIT : max;

                // Insert better error checking and argument validation here

                FisherYates randomizer = new FisherYates(min, max);
                randomizer.OnNumbersComplete = HandleRandomNumbersComplete;

                Console.WriteLine("----- Start -----");
                var watch = Stopwatch.StartNew();
                for (int i = 0; i < calls; i++)
                {
                    Console.WriteLine(randomizer.GetRandomInt());
                }

                watch.Stop();
                Console.WriteLine("------ End ------");
                Console.WriteLine(string.Format("Elapsed Time:{0} ms", watch.ElapsedMilliseconds));
                Console.WriteLine();
                Console.WriteLine("Enter command:");
            }
        }

        private static void HandleRandomNumbersComplete()
        {
            Console.WriteLine("--- Random Numbers Complete ---");
        }
    }
}
