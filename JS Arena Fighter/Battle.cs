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

            int whoHits;         //If positive, player hits; 2: if negative, opponent hits; 0: stalemate

            int damageDealt;

            string[] battleOpeners = { "eyes you warily...", "screams madly.", "cackles sinisterly.", "sings show tunes", "bows in respect before taking a stance.", "covertly tries to edit their stats.", "appears in a burst of fireworks.", "pretends to be dead.", "eats a puppy in an attempt to intimidate you." };
            string[] attacks = { "swing at", "kick", "punch", "defenestrate", "whisper spoilers about your favorite show to" };
            string[] stalemates = { "You cross blades furiously for a moment before leaping back.", "You overswing and end up at the other side of the arena.", "Inexplicably, you both hesitate.", "You only make a glancing blow.", "You cleverly sidestep their strike.", "You're both distracted by an interesting bird and forget to fight." };
            string[] finisher = { $"impale {opponent.GetName()} on your blade", $"kick {opponent.GetName()} into a deep well", $"sudo {opponent.GetName()}'s kill routine", $"make {opponent.GetName()} cry", $"slam {opponent.GetName()} into the ground", $"kick {opponent.GetName()} in the crotch", $"steal {opponent.GetName()}'s girlfriend", $"set {opponent.GetName()} on fire" };
            string[] pose = { "flexing your muscles", "donning a pair of sunglasses", "crying at the senseless loss of life", "delivering a scathing review of your opponent's fighting style", "praising the sun" };

            Random battleDice = new Random();

            Console.WriteLine($"The battle has begun! {opponent.GetName()} {battleOpeners[battleDice.Next(battleOpeners.Length)]}");

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
                    Console.WriteLine($"You {attacks[battleDice.Next(attacks.Length)]} your opponent for {damageDealt} points of damage!");
                }
                else if (whoHits < 0)
                {
                    //Opponent hits!
                    damageDealt = opponentRoll + opponent.GetOffense() - player.GetDefense();
                    if (damageDealt > 0)
                    {
                        playerHealth -= damageDealt;
                    }
                    Console.WriteLine($"They {attacks[battleDice.Next(attacks.Length)]} you for {damageDealt} points of damage!");
                }
                else
                {
                    //Stalemate.
                    Console.WriteLine(stalemates[battleDice.Next(stalemates.Length)]);
                }
            }

            //Declare winner


            if (playerHealth <= 0)
            {
                Console.WriteLine("You have been defeated.");
                player.Die();
            }
            else if (opponentHealth <= 0)
            {
                Console.WriteLine($"Victory! You {finisher[battleDice.Next(finisher.Length)]} and finish the battle by {pose[battleDice.Next(pose.Length)]}! Huzzah!");
                player.AddVictory();
                player.AddScore(opponent.GetScoreRating());
            }
            else
            {
                Console.WriteLine("Suddenly, the arena collapses! Your fight is declared moot due to unforeseen circumstances.");
            }

        }

    }
}
