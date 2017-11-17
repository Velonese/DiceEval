using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsAreAboutToGetDicey
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dicey evaluation software");
            Random rand = new Random();
            while (true)
            {
                int r1, r2, r3, r4, r5;
                Console.WriteLine("Enter 5 numbers between 1 and 8 inclusive seperated by spaces, R will generate random numbers or Q to quit.");
                var keyPress = Console.ReadKey(true);
                string entry = "";
                if (keyPress.Key == ConsoleKey.Q)
                {
                    Console.WriteLine("Thanks!");
                    break;
                }
                else if(keyPress.Key == ConsoleKey.R)
                {
                    r1 = rand.Next(1, 9);
                    r2 = rand.Next(1, 9);
                    r3 = rand.Next(1, 9);
                    r4 = rand.Next(1, 9);
                    r5 = rand.Next(1, 9);
                    Console.WriteLine($"Random results: {r1}, {r2}, {r3}, {r4}, and {r5}...");
                }
                else
                {
                    Console.Write(keyPress.KeyChar);
                    entry += keyPress.KeyChar + Console.ReadLine();
                    
                    var nums = entry.Split(new[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if(nums.Length == 5 && ParseAndValidateDiceResult(nums[0], out r1) 
                        && ParseAndValidateDiceResult(nums[1], out r2) && ParseAndValidateDiceResult(nums[2], out r3) 
                        && ParseAndValidateDiceResult(nums[3], out r4) && ParseAndValidateDiceResult(nums[4], out r5))
                    {
                        Console.WriteLine($"Parsed input results: {r1}, {r2}, {r3}, {r4}, and {r5}...");
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry, please try again!");
                        Console.WriteLine(Environment.NewLine);
                        continue;
                    }
                }

                Console.WriteLine(Environment.NewLine);
                Console.Write("Your score is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(DiceJudge.GetHighScore(r1, r2, r3, r4, r5));
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
        }

        static bool ParseAndValidateDiceResult(string diceResult, out int result)
        {
            return int.TryParse(diceResult, out result) && result > 0 && result < 9;
        }
    }
}
