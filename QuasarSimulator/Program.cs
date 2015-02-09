using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Quasar();
        }

        static void Quasar()
        {
            int credits, endingCredits, bet;
            Console.WriteLine("OPTIMAL PLAY IS ASSUMED!!!\n");
            Console.Write("How many credits do you want to start with? ");
            credits = Int32.Parse(Console.ReadLine());
            Console.Write("How much do you want to end with? ");
            endingCredits = Int32.Parse(Console.ReadLine());
            Console.Write("How much do you want to bet per game? ");
            bet = Int32.Parse(Console.ReadLine());
            RunSim(credits, endingCredits, bet);
        }

        static void RunSim(double credits, int endingCredits, int bet)
        {
            int wins = 0, losses = 0;
            CryptoRandom rng = new CryptoRandom();
            int gameCount = 0;
            while (credits < endingCredits)
            {
                if (bet > credits)
                {
                    break;
                }
                gameCount++;
                credits -= bet;
                int number = 0;
                number = rng.Next(1, 10);
                while (number < 17)
                {
                    switch (number)
                    {
                        case 1:
                        case 2:
                        case 6:
                        case 7:
                        case 8:
                        case 13:
                        case 14:
                        case 15:
                            number += rng.Next(4, 8);
                            break;
                        case 3:
                        case 4:
                        case 5:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 16:
                            number += rng.Next(1, 9);
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("\nGAME {0}", gameCount);
                if (number <= 20)
                {
                    Console.WriteLine("RESULT: WIN");
                    wins++;
                    switch (number)
                    {
                        case 17:
                            credits += bet;
                            Console.WriteLine("CREDITS WON: {0}", bet);
                            break;
                        case 18:
                            credits += bet * 1.25;
                            Console.WriteLine("CREDITS WON: {0}", bet * 1.25);
                            break;
                        case 19:
                            credits += bet * 1.5;
                            Console.WriteLine("CREDITS WON: {0}", bet * 1.5);
                            break;
                        case 20:
                            credits += bet * 2;
                            Console.WriteLine("CREDITS WON: {0}", bet * 2);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("RESULT: LOSE");
                    Console.WriteLine("CREDITS LOST: {0}", bet);
                    losses++;
                }
                Console.WriteLine("NUMBER: {0}", number);
            }
            Results(credits, wins, losses, gameCount);
        }

        static void Results(double credits, int wins, int losses, int gameCount)
        {
            Console.WriteLine("\nFINAL CREDITS: {0}", credits);
            int totalSeconds = gameCount * 6;
            TimeSpan time = TimeSpan.FromSeconds(totalSeconds);
            Console.WriteLine("APPROXIMATE TIME: {0} DAYS, {1} HOURS, {2} MINUTES, {3} SECONDS (6 seconds per game)", time.Days, time.Hours, time.Minutes, time.Seconds);
            Console.WriteLine("WINS TO LOSSES: {0} : {1}", wins, losses);
            int totalGames = wins + losses;
            double winPercentage = (double)wins / (double)totalGames;
            Console.WriteLine("WIN PERCENTAGE: {0:0.0%}", winPercentage);
            Console.ReadKey();
        }
    }
}
