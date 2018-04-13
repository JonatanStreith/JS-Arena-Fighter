using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS_Arena_Fighter
{
    class Fighter
    {
        private string Name;
        private int Str;
        private int Dex;
        private int Int;
        private int Victories;
        private int Score;
        private bool Alive;
        private string latestOpponent = "nobody";

        private string[] listOfNames = { "Hurog, the orcish sellsword", "Glorfinmad, the elven barbarian", "Thonir Ironhand, the dwarven berserker", "K1llstealer420, the griefer", "Stacy, the clueless tourist", "fifty squirrels in a horse costume", "Greg", "your evil twin", "Dirk Phoenix, the brooding anti-hero", "five thousand lines of buggy code", "Mordecai Nightstalker, the day-walking vampire", "your mentally unstable ex" };
        private string[] ratingsArray = { "abysmal", "pitiful", "weak", "average", "strong", "powerful", "mighty", "incredible", "unknown" };

        Random soRandom = new Random();

        public Fighter(string fName, int fStr, int fDex, int fInt)
        {
            Name = fName;
            Str = fStr;
            Dex = fDex;
            Int = fInt;
            Victories = 0;
            Score = 0;
            Alive = true;
        }

        public Fighter()
        {
            Name = listOfNames[soRandom.Next(listOfNames.Length)];
            Str = soRandom.Next(3, 10);
            Dex = soRandom.Next(3, 10);
            Int = soRandom.Next(3, 10);


        }

        public string GetName()
        {
            return Name;
        }

        public int GetStr()
        {
            return Str;
        }

        public int GetDex()
        {
            return Dex;
        }

        public int GetInt()
        {
            return Int;
        }

        public string GetRating()
        {
            string Rating = "unknown";
            int statAvg = (Str + Dex + Int) / 3;

            Rating = ratingsArray[statAvg - 3];

            return Rating;
        }


        public int GetScoreRating()
        {
            return (Str + Dex + Int) / 3;
        }

        public int GetOffense()
        {
            return Str + Int;
        }

        public int GetDefense()
        {
            return Dex + Int;
        }


        public void AddVictory()        //Tallies another victory
        {
            Victories++;
        }

        public int SeeVictories()       //Shows how many victories you've had
        {
            return Victories;
        }

        public void AddScore(int newScore)        //Tallies score
        {
            Score = Score + newScore;
        }

        public int SeeScore()       //Shows your score
        {
            return Score;
        }

        public bool IsAlive()       //Check if player is alive
        {
            return Alive;
        }

        public void Die()           //Declare player dead
        {
            Alive = false;
        }

        public void SetLatestOpponent(String name)
        {
            latestOpponent = name;
        }

        public string GetLatestOpponent()
        {
            return latestOpponent;
        }

    }
}
