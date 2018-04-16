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
            int playerHealth = 100;
            int opponentHealth = 100;
            int playerRoll;
            int opponentRoll;
            int whoHits;         //If positive, player hits; if negative, opponent hits; 0: stalemate
            int damageDealt;


            Random battleDice = new Random();




            Console.WriteLine($"The battle has begun! {opponent.GetName()} {Lines.battleOpeners[battleDice.Next(Lines.battleOpeners.Length)]}");

            while ((playerHealth > 0) && (opponentHealth > 0))
            {
                Console.WriteLine();
                Console.ReadKey(true);

                playerRoll = battleDice.Next(7);            //Roll the dice!
                opponentRoll = battleDice.Next(7);


                whoHits = (playerRoll + player.GetOffense() + player.GetDefense()) - (opponentRoll + opponent.GetOffense() + opponent.GetDefense());    //Determine who scores a hit.


                Console.WriteLine($"Your health: {playerHealth}. Their health: {opponentHealth}.");

                if (whoHits > 0)
                {
                    //Player hits!

                    //Calculate damage
                    damageDealt = playerRoll + player.GetOffense() - opponent.GetDefense();
                    if (damageDealt > 0)
                    {
                        opponentHealth -= damageDealt;
                    }
                    Console.WriteLine($"You {Lines.attacks[battleDice.Next(Lines.attacks.Length)]} your opponent! {Lines.GetDeadliness(damageDealt)}");
                }
                else if (whoHits < 0)
                {
                    //Opponent hits!
                    damageDealt = opponentRoll + opponent.GetOffense() - player.GetDefense();
                    if (damageDealt > 0)
                    {
                        playerHealth -= damageDealt;
                    }
                    Console.WriteLine($"They {Lines.attacks[battleDice.Next(Lines.attacks.Length)]} you! {Lines.GetDeadliness(damageDealt)}");
                }
                else
                {
                    //Stalemate.
                    Console.WriteLine(Lines.stalemates[battleDice.Next(Lines.stalemates.Length)]);
                }
            }

            //Declare winner


            if (playerHealth <= 0)
            {
                Console.WriteLine($"You have been defeated. {Lines.defeated[battleDice.Next(Lines.defeated.Length)]}\n{opponent.GetName()} {Lines.opponentResponse[battleDice.Next(Lines.opponentResponse.Length)]}");
                player.Die();
            }
            else if (opponentHealth <= 0)
            {
                Console.WriteLine($"Victory! You {Lines.finisher[battleDice.Next(Lines.finisher.Length)]} and finish the battle by {Lines.pose[battleDice.Next(Lines.pose.Length)]}! Huzzah!");
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
                Console.WriteLine("Suddenly, the arena collapses! Your fight is declared moot due to unforeseen circumstances.");
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
                Console.WriteLine($"You claim their +{loser.GetWeaponStrength()} {loser.GetWeaponName()}, discarding your old {winner.GetWeaponName()}." );
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

    }
}
