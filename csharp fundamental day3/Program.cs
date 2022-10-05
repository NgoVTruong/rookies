namespace csharp_fundamental_day3
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            var oneSecond = OneSecond();
            var twoSecond = TwoSecond();
            var threeSecond = ThreeSecond();

            var results = await Task.WhenAll(oneSecond, twoSecond, threeSecond);

            Console.WriteLine($"Random number from 0 to 100: {results[0]}");
            Console.WriteLine($"Random number from 0 to 100: {results[1]}");
            Console.WriteLine($"Random number from 0 to 100: {results[2]}");

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            Console.ReadLine();
        }

        private static async Task<int> OneSecond()
        {
            Random random = new Random();
            int randomNumb = random.Next(0, 100);
            await Task.Delay(1000);
            return randomNumb;
        }

        private static async Task<int> TwoSecond()
        {
            Random random = new Random();
            int randomNumb = random.Next(0, 100);
            await Task.Delay(2000);
            return randomNumb;
        }
        private static async Task<int> ThreeSecond()
        {
            Random random = new Random();
            int randomNumb = random.Next(0, 100);
            await Task.Delay(3000);
            return randomNumb;
        }
    }
}