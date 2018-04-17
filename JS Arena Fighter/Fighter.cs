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
        private string actionChoice;                //What the fighter chooses - attack or defend
        private int diceRoll;                       //What they rolled last


        private string weaponName;
        private int weaponStrength;

        private string armorName;
        private int armorStrength;

        private int maxPower;                       //How powerful equipment they may have, at most
        private int defenseBonus;                   //You get a bonus to your attack if you defended last turn



        public Fighter(string fName, int fStr, int fDex, int fInt)
        {
            Name = fName;
            Str = fStr;
            Dex = fDex;
            Int = fInt;
            Victories = 0;
            Score = 0;
            Alive = true;

            weaponName = String.Concat(Lines.weaponMaterial[Lines.battleDice.Next(Lines.weaponMaterial.Length)], Lines.weaponType[Lines.battleDice.Next(Lines.weaponType.Length)]);
            weaponStrength = 0;

            armorName = String.Concat(Lines.armorMaterial[Lines.battleDice.Next(Lines.armorMaterial.Length)], Lines.armorType[Lines.battleDice.Next(Lines.armorType.Length)]);
            armorStrength = 0;

        }

        public Fighter()
        {
            Name = Lines.listOfNames[Lines.battleDice.Next(Lines.listOfNames.Length)];
            Str = Lines.battleDice.Next(3, 10);
            Dex = Lines.battleDice.Next(3, 10);
            Int = Lines.battleDice.Next(3, 10);

            maxPower = (((Str + Dex + Int) / 3) - 2);

            weaponName = String.Concat(Lines.weaponMaterial[Lines.battleDice.Next(Lines.weaponMaterial.Length)], Lines.weaponType[Lines.battleDice.Next(Lines.weaponType.Length)]);
            weaponStrength = Lines.battleDice.Next(maxPower);

            armorName = String.Concat(Lines.armorMaterial[Lines.battleDice.Next(Lines.armorMaterial.Length)], Lines.armorType[Lines.battleDice.Next(Lines.armorType.Length)]);
            armorStrength = Lines.battleDice.Next(maxPower);

        }



        public string GetRating()
        {
            string Rating = "unknown";
            int statAvg = (Str + Dex + Int) / 3;

            Rating = Lines.ratingsArray[statAvg - 3];

            return Rating;
        }


        //Bunch of very simple queries and actions

        public string GetName()
        { return Name; }

        public int GetStr()
        { return Str; }

        public int GetDex()
        { return Dex; }

        public int GetInt()
        { return Int; }

        public int GetScoreRating()
        { return (Str + Dex + Int) / 3; }

        public int GetOffense()
        { return Str + Int + weaponStrength; }

        public int GetDefense()
        { return Dex + Int + armorStrength; }


        public string GetWeaponName()
        { return weaponName; }

        public int GetWeaponStrength()
        { return weaponStrength; }


        public string GetArmorName()
        { return armorName; }

        public int GetArmorStrength()
        { return armorStrength; }


        public void SetWeaponName(string newName)
        { weaponName = newName; }

        public void SetWeaponStrength(int newStrength)
        { weaponStrength = newStrength; }


        public void SetArmorName(string newName)
        { armorName = newName; }

        public void SetArmorStrength(int newStrength)
        { armorStrength = newStrength; }


        public void AddVictory()        //Tallies another victory
        { Victories++; }

        public int SeeVictories()       //Shows how many victories you've had
        { return Victories; }


        public void AddScore(int newScore)        //Tallies score
        { Score = Score + newScore; }

        public int SeeScore()       //Shows your score
        { return Score; }


        public bool IsAlive()       //Check if player is alive
        { return Alive; }

        public void Die()           //Declare player dead
        { Alive = false; }


        public void SetLatestOpponent(String name)
        { latestOpponent = name; }

        public string GetLatestOpponent()
        { return latestOpponent; }


        public void SetActionChoice(String action)
        { actionChoice = action; }

        public string GetActionChoice()
        { return actionChoice; }


        public void SetDefenseBonus(int bonus)
        { defenseBonus = bonus; }

        public int GetDefenseBonus()
        { return defenseBonus; }


        public void SetRoll(int roll)
        { diceRoll = roll; }

        public int GetRoll()
        { return diceRoll; }
    }
}
