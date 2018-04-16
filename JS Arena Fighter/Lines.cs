using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS_Arena_Fighter
{
    class Lines
    {
        public static string[] listOfNames = { "Hurog, the orcish sellsword", "Glorfinmad, the elven barbarian", "Thonir Ironhand, the dwarven berserker", "K1llstealer420, the griefer", "Stacy, the clueless tourist", "fifty squirrels in a horse costume", "Greg", "your evil twin", "Dirk Phoenix, the brooding anti-hero", "five thousand lines of buggy code", "Mordecai Nightstalker, the day-walking vampire", "your mentally unstable ex" };
        public static string[] ratingsArray = { "abysmal", "pitiful", "weak", "average", "strong", "powerful", "mighty", "incredible", "unknown" };

        public static string[] weaponType = { "sword", "axe", "spear", "crossbow", "wand", "lance", "halberd", "half-brick in a sock", "spiked fist", "club", "large boulder", "mallet", "fishing rod", "safe", "witty insult", "set of throwing knives", "anachronistic rocket launcher", "flying guillotine", "trebuchet", "shiv", "poison bottle", "pointed stick" };
        public static string[] armorType = { "helmet", "breastplate", "chainmail shirt", "ring of protection", "shield", "enchanted thimble", "power tie", "spiked kneecaps", "bullet-proof shoe", "plot-relevant name", "personal forcefield", "bodyguard", "enchanted cape", "set of bracers" };

        public static string[] weaponMaterial = { "iron ", "copper ", "steel ", "glass ", "diamond ", "awesome ", "adamantium ", "obsidian ", "bone ", "force ", "energy " };
        public static string[] armorMaterial = { "iron ", "copper ", "steel ", "glass ", "diamond ", "awesome ", "adamantium ", "obsidian ", "bone ", "force ", "energy ", "leather ", "cloth " };


        public static string[] battleOpeners = { "eyes you warily...", "screams madly.", "cackles sinisterly.", "sings show tunes.", "bows in respect before taking a stance.", "covertly tries to edit their stats.", "appears in a burst of fireworks.", "pretends to be dead.", "eats a puppy in an attempt to intimidate you.", "rocks out on a guitar before turning their attention to you.", "readies their weapon.", "is... asleep?", "taps their feet impatiently." };
        public static string[] attacks = { "swing at", "kick", "punch", "defenestrate", "whisper spoilers about your favorite show to", "hack at", "elbow", "throw a rock at", "stab", "piledrive", "spit on", "taunt", "cast a magic missile at" };
        public static string[] defends = { "successfully block the attack!", "dance out of the way!", "backstep and avoid the swing!", "use a cheat code!", "throw some sand to provide cover!", "quickly switch place with an innocent bystander!", "turn out to be a decoy!", "catch the weapon in one hand!", "are just too cool for taking damage!" };

        public static string[] stalemates = { "You cross blades furiously for a moment before leaping back.", "You overswing and end up at the other side of the arena.", "Inexplicably, you both hesitate.", "You only make a glancing blow.", "You cleverly sidestep their strike.", "You're both distracted by an interesting bird and forget to fight.", "In the confusion, you both lose track of each other.", "You find a lost puppy and take a moment to return it to its owner.", "It's a near miss!" };
        public static string[] pose = { "flexing your muscles", "donning a pair of sunglasses", "crying at the senseless loss of life", "delivering a scathing review of your opponent's fighting style", "praising the sun", "teabagging your foe's body", "mugging for the audience", "accidentally falling on your own blade", };
        public static string[] finisher = { "impale your opponent on your blade", "kick your foe into a deep well", "sudo your enemy's kill routine", "make your victim cry", "slam them into the ground", "kick your enemy in the crotch", "steal your opponent's girlfriend", "set your foe on fire" };
        public static string[] opponentResponse = { "laughs at your defeat.", "solemnly doffs their hat in respect.", "mutilates your body to show off how hardcore they are.", "rifles through your pockets for spare change.", "is hailed as a hero by the audience.", "cries openly over your untimely demise.", "doesn't care."};
        public static string[] defeated = { "Your lifeless body drops to the ground.", "You are confronted with a critical existance failure.", "Your limbs are no more.", "Without a head, you cannot continue.", "Afterlife next.", "You bleed out on the ground." };

        public static string[] retire = { "you have chosen to retire to spend more time with your remaining limbs" };

        public static int standardDefense = 3;      //This sets how much bonus you get for defending

        public static Random battleDice = new Random();

        public static string GetDeadliness(int damage)  //Make this an enum instead!
        {
            string deadliness = "";
            if (damage <= 0)
            {
                deadliness = "A barely noticeable hit!";
            }
            else if (damage < 3)
            {
                deadliness = "A small scratch!";

            }
            else if (damage < 5)
            {
                deadliness = "A serious injury!";

            }
            else if (damage < 7)
            {
                deadliness = "A grievous cut!";

            }
            else
            {
                deadliness = "A devastating blow!";

            }
            return deadliness;
        }

    }
}
