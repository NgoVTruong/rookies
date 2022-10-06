// namespace csharp_fundamental_day3
// {
//     class Program1
//     {
//         public static void Main(string[] args)
//         {
//             Task.WhenAll(GetPrimeNumbers(0, 100));
//             Console.ReadLine();
//         }

//         static async Task GetPrimeNumbers(int minimum, int maximum)
//         {
//             await Task.Run(() =>
//             {
//                 for (int i = minimum; i <= maximum; i++)
//                 {
//                     if(IsPrimeNumber(i))
//                     {
//                         Console.WriteLine(i);
//                     }
//                 }
//             });
//         }

//         static bool IsPrimeNumber(int number) 
//         {
//             int i;

//             for (i = 2; i < number; i++)
//             {
//                 if(number % i == 0)
//                 {
//                     return false;
//                 }
//             }

//             return true;
//         }
//     }
// }