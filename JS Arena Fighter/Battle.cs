using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS_Arena_Fighter
{
    class Battle
    {
        public Battle(Fighter player, Fighter opponent)
        {
            int[] healthArray = { 100, 100 };   //Player health, opponent health


            Console.WriteLine($"The battle has begun! {opponent.GetName()} {Lines.battleOpeners[Lines.battleDice.Next(Lines.battleOpeners.Length)]}");

            while ((healthArray[0] > 0) && (healthArray[1] > 0))
            {
                Console.WriteLine();
                Console.WriteLine($"Your health: {healthArray[0]}. Their health: {healthArray[1]}.");

                player.SetRoll(Lines.battleDice.Next(7));            //Roll the dice!
                opponent.SetRoll(Lines.battleDice.Next(7));

                Console.WriteLine("Attack or defend? A/D [D]");
                player.SetActionChoice(Console.ReadKey(true).Key.ToString());


                if (Lines.battleDice.Next() % 2 == 0)               //Opponent randomly attacks or defends. It's not very bright.
                { opponent.SetActionChoice("A"); }
                else
                { opponent.SetActionChoice("D"); }


                if ((player.GetActionChoice() == "A") && (opponent.GetActionChoice() == "A"))
                {
                    //Both attack.
                    Console.WriteLine("You both clash recklessly!");
                    healthArray = BothAttack(healthArray, player, opponent);        //Calculate the result of this choice.
                    player.SetDefenseBonus(0);
                    opponent.SetDefenseBonus(0);
                }

                else if ((player.GetActionChoice() == "D") && (opponent.GetActionChoice() == "D"))
                {
                    //Both defend.
                    Console.WriteLine("You circle each other warily, defenses raised.");
                    player.SetDefenseBonus(Lines.standardDefense);
                    opponent.SetDefenseBonus(Lines.standardDefense);
                }

                else if ((player.GetActionChoice() == "A") && (opponent.GetActionChoice() == "D"))
                {
                    Console.WriteLine("You attack as your opponent defends.");
                    //Player attacks, opponent defends.
                    healthArray = PlayerAttacks(healthArray, player, opponent);        //Calculate the result of this choice.
                    player.SetDefenseBonus(0);
                    opponent.SetDefenseBonus(Lines.standardDefense);
                }

                else if ((player.GetActionChoice() == "D") && (opponent.GetActionChoice() == "A"))
                {
                    //Player defends, opponent attacks.
                    Console.WriteLine("You defend as your opponent attacks.");
                    healthArray = OpponentAttacks(healthArray, player, opponent);        //Calculate the result of this choice.
                    player.SetDefenseBonus(Lines.standardDefense);
                    opponent.SetDefenseBonus(0);
                }

                else
                {
                    Console.WriteLine("If you read this, something didn't go right. Please debug.");    //Dunno how this could be reached, but just in case.
                }
            }

            //Declare winner
            if (healthArray[0] <= 0)
            {
                Console.WriteLine();
                Console.WriteLine($"You have been defeated. {Lines.defeated[Lines.battleDice.Next(Lines.defeated.Length)]}\n{opponent.GetName()} {Lines.opponentResponse[Lines.battleDice.Next(Lines.opponentResponse.Length)]}");
                player.Die();
            }

            else if (healthArray[1] <= 0)
            {
                Console.WriteLine($"Victory! You {Lines.finisher[Lines.battleDice.Next(Lines.finisher.Length)]} and finish the battle by {Lines.pose[Lines.battleDice.Next(Lines.pose.Length)]}! Huzzah!");
                player.AddVictory();
                player.AddScore(opponent.GetScoreRating());
                Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();

                LootEquipment(player, opponent);  //Initiates looting function. Yes, you may take their stuff even if it's weaker than your own. Self-imposed challenge, perhaps?
            }

            else
            {
                Console.WriteLine("Suddenly, the arena collapses! Your fight is declared moot due to unforeseen circumstances.");       //Just in case something happens. Shouldn't.
            }

            Console.ReadKey();
            Console.Clear();
        }

        
        static void LootEquipment(Fighter winner, Fighter loser)
        {
            Console.WriteLine($"They had a +{loser.GetWeaponStrength()} {loser.GetWeaponName()} (compared to your +{winner.GetWeaponStrength()} {winner.GetWeaponName()})");
            Console.WriteLine($"and a +{loser.GetArmorStrength()} {loser.GetArmorName()} (compared to your +{winner.GetArmorStrength()} {winner.GetArmorName()}).");
            Console.WriteLine("You may claim one item as spoils of victory. What's your choice? W/A/N [N]");

            string lootChoice = Console.ReadKey(true).Key.ToString();

            if (lootChoice == "W")
            {
                Console.WriteLine($"You claim their +{loser.GetWeaponStrength()} {loser.GetWeaponName()}, discarding your old {winner.GetWeaponName()}.");
                winner.SetWeaponName(loser.GetWeaponName());
                winner.SetWeaponStrength(loser.GetWeaponStrength());
            }

            else if (lootChoice == "A")
            {
                Console.WriteLine($"You claim their +{loser.GetArmorStrength()} {loser.GetArmorName()}, discarding your old {winner.GetArmorName()}.");
                winner.SetArmorName(loser.GetArmorName());
                winner.SetArmorStrength(loser.GetArmorStrength());
            }

            else
            {
                Console.WriteLine("You leave their equipment alone.");
            }
        }

        
        static int[] BothAttack(int[] healthArray, Fighter player, Fighter opponent)
        {
            Random battleDice = new Random();
            int whoHit = (player.GetRoll() + player.GetOffense() + player.GetDefenseBonus()) - (opponent.GetRoll() + opponent.GetOffense() + opponent.GetDefenseBonus());   //If positive, player hits; if negative, opponent hits; 0: stalemate
            int damageDealt;

            if (whoHit > 0)
            {
                //Player hits!
                damageDealt = (player.GetRoll() + player.GetStr() + player.GetWeaponStrength() + player.GetDefenseBonus()) - (opponent.GetRoll() + opponent.GetDex() + opponent.GetArmorStrength());
                if (damageDealt < 0)
                { damageDealt = 0; }        //Just avoids a negative damage number
                healthArray[1] -= damageDealt;
                Console.WriteLine($"You {Lines.attacks[battleDice.Next(Lines.attacks.Length)]} your opponent! {Lines.GetDeadliness(damageDealt)}");
            }

            else if (whoHit < 0)
            {
                //Opponent hits!
                damageDealt = (opponent.GetRoll() + opponent.GetStr() + opponent.GetWeaponStrength() + opponent.GetDefenseBonus()) - (player.GetRoll() + player.GetDex() + player.GetArmorStrength());
                if (damageDealt < 0)
                { damageDealt = 0; }
                healthArray[0] -= damageDealt;
                Console.WriteLine($"They {Lines.attacks[battleDice.Next(Lines.attacks.Length)]} you! {Lines.GetDeadliness(damageDealt)}");
            }

            else
            {
                //Stalemate.
                Console.WriteLine(Lines.stalemates[battleDice.Next(Lines.stalemates.Length)]);
            }

            return healthArray;
        }

        
        static int[] PlayerAttacks(int[] healthArray, Fighter player, Fighter opponent)
        {
            Random battleDice = new Random();
            int whoHit = (player.GetRoll() + player.GetOffense() + player.GetDefenseBonus()) - (opponent.GetRoll() + opponent.GetOffense() + opponent.GetDefenseBonus());   //If positive, player hits; if negative, opponent hits; 0: stalemate
            int damageDealt;

            if (whoHit > 0)
            {
                //Player hits!
                damageDealt = (player.GetRoll() + player.GetStr() + player.GetWeaponStrength() + player.GetDefenseBonus()) - (opponent.GetRoll() + opponent.GetDex() + opponent.GetArmorStrength());
                if (damageDealt < 0)
                { damageDealt = 0; }        //Just avoids a negative damage number
                healthArray[1] -= damageDealt;
                Console.WriteLine($"You {Lines.attacks[battleDice.Next(Lines.attacks.Length)]} your opponent! {Lines.GetDeadliness(damageDealt)}");
            }

            else if (whoHit < 0)
            {
                //Opponent defends successfully!
                Console.WriteLine($"You {Lines.attacks[battleDice.Next(Lines.attacks.Length)]} your opponent, but they {Lines.defends[battleDice.Next(Lines.defends.Length)]}");
            }

            else
            {
                //Stalemate.
                Console.WriteLine(Lines.stalemates[battleDice.Next(Lines.stalemates.Length)]);
            }

            return healthArray;
        }

        
        static int[] OpponentAttacks(int[] healthArray, Fighter player, Fighter opponent)
        {
            Random battleDice = new Random();
            int whoHit = (player.GetRoll() + player.GetOffense() + player.GetDefenseBonus()) - (opponent.GetRoll() + opponent.GetOffense() + opponent.GetDefenseBonus());   //If positive, player hits; if negative, opponent hits; 0: stalemate
            int damageDealt;

            if (whoHit > 0)
            {
                //Player defends successfully!
                Console.WriteLine($"They {Lines.attacks[battleDice.Next(Lines.attacks.Length)]} you, but you {Lines.defends[battleDice.Next(Lines.defends.Length)]}");
            }

            else if (whoHit < 0)
            {
                //Opponent hits!
                damageDealt = (opponent.GetRoll() + opponent.GetStr() + opponent.GetWeaponStrength() + player.GetDefenseBonus()) - (player.GetRoll() + player.GetDex() + player.GetArmorStrength());
                if (damageDealt < 0)
                { damageDealt = 0; }
                healthArray[0] -= damageDealt;
                Console.WriteLine($"They {Lines.attacks[battleDice.Next(Lines.attacks.Length)]} you! {Lines.GetDeadliness(damageDealt)}");
            }

            else
            {
                //Stalemate.
                Console.WriteLine(Lines.stalemates[battleDice.Next(Lines.stalemates.Length)]);
            }

            return healthArray;
        }
    }
}
