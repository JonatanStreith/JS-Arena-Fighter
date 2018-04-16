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

        private string weaponName;
        private int weaponStrength;

        private string armorName;
        private int armorStrength;

        private int maxPower;       //How powerful equipment they may have, at most


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

            weaponName = Lines.weaponType[soRandom.Next(Lines.weaponType.Length)];
            weaponStrength = 0;

            armorName = Lines.armorType[soRandom.Next(Lines.armorType.Length)];
            armorStrength = 0;

        }

        public Fighter()
        {
            Name = Lines.listOfNames[soRandom.Next(Lines.listOfNames.Length)];
            Str = soRandom.Next(3, 10);
            Dex = soRandom.Next(3, 10);
            Int = soRandom.Next(3, 10);

            maxPower = (((Str + Dex + Int) / 3)-2);

            weaponName = Lines.weaponType[soRandom.Next(Lines.weaponType.Length)];
            weaponStrength = soRandom.Next(maxPower);

            armorName = Lines.armorType[soRandom.Next(Lines.armorType.Length)];
            armorStrength = soRandom.Next(maxPower);

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

            Rating = Lines.ratingsArray[statAvg - 3];

            return Rating;
        }


        public int GetScoreRating()
        {
            return (Str + Dex + Int) / 3;
        }

        public int GetOffense()
        {
            return Str + Int + weaponStrength;
        }

        public int GetDefense()
        {
            return Dex + Int + armorStrength;
        }




        public string GetWeaponName()
        {
            return weaponName;
        }
        public int GetWeaponStrength()
        {
            return weaponStrength;
        }


        public string GetArmorName()
        {
            return armorName;
        }
        public int GetArmorStrength()
        {
            return armorStrength;
        }


        public void SetWeaponName(string newName)
        {
            weaponName = newName;
        }
        public void SetWeaponStrength(int newStrength)
        {
            weaponStrength = newStrength;
        }

        public void SetArmorName(string newName)
        {
            armorName = newName;
        }
        public void SetArmorStrength(int newStrength)
        {
            armorStrength = newStrength;
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
