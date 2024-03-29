namespace ZenS_Algorithm_Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5];

            string inputLine;

            bool trueFormat;
            do
            {
                trueFormat = true;

                inputLine = Console.ReadLine();

                // Split the input line into individual integers
                string[] integerStrings = inputLine.Split(' ');

                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        arr[i] = int.Parse(integerStrings[i]);

                        if(arr[i] <= 0) { throw new Exception(); }
                    }
                    catch 
                    {
                        trueFormat = false;
                    }
                }
            }
            while (!trueFormat);

            miniMaxSum(arr);

        }

        static void miniMaxSum(int[] arr)
        {
            // Sort the array
            Array.Sort(arr);

            // Calculate the total sum of all integers
            long sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }

            // Calculate the minimum and maximum sums
            long minSum = sum - arr[4]; // Sum of the first four integers
            long maxSum = sum - arr[0];  // Sum of the last four integers

            // Print the results
            Console.WriteLine($"{minSum} {maxSum}");
        }
    
    }
}