
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS_Arena_Fighter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputName = "";
            int inputStr = 0;
            int inputDex = 0;
            int inputInt = 0;
            bool legit;             //Tracks whether an input is legitimately parsable
            string wantFight;


            Console.WriteLine("Welcome to the Arena, warrior! By what name will you be remembered?");
            inputName = Console.ReadLine();
            Console.WriteLine($"You are {inputName}, a beginner fighter. What are your abilities, {inputName}?");
            Console.WriteLine();
            Console.WriteLine("A warrior is defined by their strength, dexterity, and intelligence.");
            Console.WriteLine();
            Console.WriteLine("Strength will make your blows deadlier and more sure. \nDexterity will allow you to dodge an opponent's attacks, and reduce the severity of their hits. \nIntelligence will aid your fighting ability overall.");
            Console.WriteLine();
            Console.WriteLine("You have eighteen points to assign to your abilities. While you may spend less, \ndo not attempt to assign more, or you will be cast out of the arena in disgrace.");


            do
            {
                Console.WriteLine();
                Console.Write("Strength: ");
                legit = Int32.TryParse(Console.ReadLine(), out inputStr);
                Console.Write("Dexterity: ");
                legit = Int32.TryParse(Console.ReadLine(), out inputDex);
                Console.Write("Intelligence: ");
                legit = Int32.TryParse(Console.ReadLine(), out inputInt);

                Console.WriteLine($"You have stated that you have a strength of {inputStr}, dexterity of {inputDex} and intelligence of {inputInt}. Is this correct? Y/N [N]");
            } while (Console.ReadKey(true).Key.ToString() != "Y");          //If player doesn't say yes, start over.


            if (inputStr + inputDex + inputInt > 18)                        //You cheated! Now you get kicked out. Jerk.
            {
                Console.WriteLine("\"CHEATER! Begone from the arena, and do not return until you have learned to play fairly!\"");
                Console.WriteLine();
                Console.WriteLine("You are forcibly thrown out of the arena.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Fighter player = new Fighter(inputName, inputStr, inputDex, inputInt);

            Console.WriteLine();
            Console.WriteLine($"You arm yourself with a +{player.GetWeaponStrength()} {player.GetWeaponName()} and don a +{player.GetArmorStrength()} {player.GetArmorName()}. Your destiny awaits.");
            Console.ReadKey();
            Console.Clear();

            //Now we can begin fighting! Yeah!
            Console.WriteLine($"{player.GetName()} enters the arena!");
            Console.WriteLine();

            do            //Loop for as long as we want to fight.
            {
                Console.WriteLine($"You currently wield a +{player.GetWeaponStrength()} {player.GetWeaponName()} and wear a +{player.GetArmorStrength()} {player.GetArmorName()}.");
                Console.WriteLine();
                Console.WriteLine("Do you want to challenge an opponent? Y/N [N]");
                Console.WriteLine();

                wantFight = Console.ReadKey(true).Key.ToString();

                if (wantFight == "Y")
                {
                    Fighter opponent = new Fighter();                       //Create opponent
                    Console.WriteLine($"You come face to face with {opponent.GetName()}! They look {opponent.GetRating()}! \n\nThey carry a +{opponent.GetWeaponStrength()} {opponent.GetWeaponName()} and wear a +{opponent.GetArmorStrength()} {opponent.GetArmorName()}. \n\nDo you want to challenge them? Y/N [N]");

                    if (Console.ReadKey(true).Key.ToString() == "Y")
                    {
                        Console.Clear();
                        player.SetLatestOpponent(opponent.GetName());
                        Battle newBattle = new Battle(player, opponent);        //Create battle
                    }
                    else
                    {
                        Console.WriteLine($"You back away with a hasty excuse. For your cowardice, you are docked three points.");
                        player.AddScore(-3);
                    }
                }

            } while ((wantFight == "Y") && (player.IsAlive() == true));


            if (player.IsAlive() == true)
            { Retire(player); }
            else
            { Bury(player); }

            Console.ReadLine();         //The end!
        }


        public static void Retire(Fighter player)
        {
            //do retirement stuff
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"After a long and bloody career in the arena, {Lines.retire[Lines.battleDice.Next(Lines.battleOpeners.Length)]}");

            Console.WriteLine($"Goodbye, {player.GetName()}. You achieved {player.SeeScore()} points, and slew {player.SeeVictories()} opponents, including {player.GetLatestOpponent()}. \nYou claim your +{player.GetWeaponStrength()} {player.GetWeaponName()} and your +{player.GetArmorStrength()} {player.GetArmorName()} as keepsakes of your time.");
            Console.WriteLine("Thanks for playing!");
        }


        public static void Bury(Fighter player)
        {
            //Do death stuff
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("You have died.");

            Console.WriteLine($"Rest in peace, {player.GetName()}. \nYou achieved {player.SeeScore()} points, and slew {player.SeeVictories()} opponents, before falling to the might of {player.GetLatestOpponent()}. \nYou are buried with your +{player.GetWeaponStrength()} {player.GetWeaponName()} and your +{player.GetArmorStrength()} {player.GetArmorName()}.");
            Console.WriteLine("Thanks for playing!");
        }
    }
}
