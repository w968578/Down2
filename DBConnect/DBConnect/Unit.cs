/*
CSC 424
Instructor Lindy Lewis
Down 2
Billy Loveday, Gabriel Mayo, Michael Ouille, Dane Reggia, Chris Touchette
Class definition for the Unit class for hExSCAPE

TO DO:
Add derived stats and functions to calculate them
Define equipment (Should it be another class?) and add equipment slots
Define level up logic. Currently only increases stats by 1
Hook into the database and create units with data pulled from the unit table
Determine the necessity of a destructor and implement if necessary
Determine where to handle a unit's Experience Points (XP)
*/
using System;

namespace DBConnect
{
    //Struct for handling unit data. Currently doesn't account for any derived stats
    struct UnitData
    {
        public string unitName;
        public int unitLevel;      //The unit's power increases as its level does
        public int maxHitPoints;      //The amount of damage a unit can sustain
        public int curHitPoints;      //The current amount of HP
        public int maxMagicPoints;    //The units spellcasting resource
        public int curMagicPoints;    //The current amount of MP
        public int strength;
        public int dexterity;
        public int agility;
        public int intelligence;
        public int wisdom;
        public int charisma;
        public int unitType;       //For the database
        public string unitTypeName;    //Fighter, Wizard, etc
        public string alignment;
        public int unitID;         //For the database

        //What's the difference between unitType and unitID? Would unitType
        //be something like boss vs regular enemy vs player-controlled? -Gabriel Mayo, 3-25-2018
    }

    public class Unit
    {
        private UnitData unitStats; //Stats for the current unit

        //Named constants to define Maximum Level and Stat Values
        public const int MAX_LEVEL = 99;
        public const int MAX_HP_VALUE = 999;
        public const int MAX_MP_VALUE = 99;
        public const int MAX_STAT_VALUE = 99;    //Any stats other than HP and MP

        //Default constructor creates a level 1 Peasant with 1 in all stats 
        //named "New Peasant". This is likely not actually useful for the game
        //but I'm including it for testing purposes later -Gabriel Mayo, 3-25-2018
        public Unit()
        {
            unitStats.unitName = "New Peasant";
            unitStats.unitLevel = 1;
            unitStats.maxHitPoints = 1;
            unitStats.curHitPoints = unitStats.maxHitPoints;
            unitStats.maxMagicPoints = 0;
            unitStats.curMagicPoints = unitStats.maxMagicPoints;
            unitStats.strength = 1;
            unitStats.dexterity = 1;
            unitStats.agility = 1;
            unitStats.intelligence = 1;
            unitStats.wisdom = 1;
            unitStats.charisma = 1;
            unitStats.unitType = 1;
            unitStats.unitTypeName = "Peasant";     //Do we need both a type and type name? Why/why not?
            unitStats.alignment = "True Neutral";
            unitStats.unitID = 999;
        }

        //Overloaded constructor takes a unit ID in the form of an integer
        //and pulls the unit data from the database
        public Unit(string newUnitID)
        {
            DBConnect grabUnit = new DBConnect();
            try
            {
                this.unitStats = grabUnit.SelectUnitData(newUnitID);
            }
            catch
            {
                Console.WriteLine("Unable to find data for that unit ID");
            }

        }

        //Level Up function. Currently increases HP by 10 and all other stats by 1
        //Will need proper logic implementation
        public void LevelUp()
        {
            if (unitStats.unitLevel < MAX_LEVEL)
            {
                unitStats.unitLevel++;
            }
            if (unitStats.maxHitPoints < MAX_HP_VALUE)
            {
                unitStats.maxHitPoints += 10;
            }
            if (unitStats.curHitPoints < MAX_HP_VALUE)
            {
                unitStats.curHitPoints += 10;
            }
            if (unitStats.maxMagicPoints < MAX_MP_VALUE)
            {
                unitStats.maxMagicPoints++;
            }
            if (unitStats.curMagicPoints < MAX_MP_VALUE)
            {
                unitStats.curMagicPoints++;
            }
            if (unitStats.strength < MAX_STAT_VALUE)
            {
                unitStats.strength++;
            }
            if (unitStats.dexterity < MAX_STAT_VALUE)
            {
                unitStats.dexterity++;
            }
            if (unitStats.agility < MAX_STAT_VALUE)
            {
                unitStats.agility++;
            }
            if (unitStats.intelligence < MAX_STAT_VALUE)
            {
                unitStats.intelligence++;
            }
            if (unitStats.wisdom < MAX_STAT_VALUE)
            {
                unitStats.wisdom++;
            }
            if (unitStats.charisma < MAX_STAT_VALUE)
            {
                unitStats.charisma++;
            }
        }

        //Getter functions

        public string GetUnitName()
        {
            return unitStats.unitName;
        }


        public int GetUnitLevel()
        {
            return unitStats.unitLevel;
        }


        public int GetMaxHitPoints()
        {
            return unitStats.maxHitPoints;
        }

        public int GetCurHitPoints()
        {
            return unitStats.curHitPoints;
        }

        public int GetMaxMagicPoints()
        {
            return unitStats.maxMagicPoints;
        }

        public int GetCurMagicPoints()
        {
            return unitStats.curMagicPoints;
        }

        public int GetStrength()
        {
            return unitStats.strength;
        }

        public int GetDexterity()
        {
            return unitStats.dexterity;
        }

        public int GetAgility()
        {
            return unitStats.agility;
        }

        public int GetIntelligence()
        {
            return unitStats.intelligence;
        }

        public int GetWisdom()
        {
            return unitStats.wisdom;
        }

        public int GetCharisma()
        {
            return unitStats.charisma;
        }

        public int GetUnitType()
        {
            return unitStats.unitType;
        }

        public string GetUnitTypeName()
        {
            return unitStats.unitTypeName;
        }

        public string GetAlignment()
        {
            return unitStats.alignment;
        }

        public int GetUnitID()
        {
            return unitStats.unitID;
        }

        //Setter functions

        //setter for the unit's Name
        public void SetUnitName(string newUnitName)
        {
            unitStats.unitName = newUnitName;
        }

        //setter for the unit's Level
        public void SetUnitLevel(int newLevel)
        {
            if (newLevel <= MAX_LEVEL)
            {
                unitStats.unitLevel = newLevel;
            }
            else
            {
                unitStats.unitLevel = MAX_LEVEL;
            }
        }

        //setter for the unit's Maximum Hit Points (HP)
        public void SetMaxHitPoints(int newMaxHitPoints)
        {
            if (newMaxHitPoints <= MAX_HP_VALUE)
            {
                unitStats.maxHitPoints = newMaxHitPoints;
            }
            else
            {
                unitStats.maxHitPoints = MAX_HP_VALUE;
            }
        }

        //setter for the unit's Current Hit Points (HP)
        public void SetCurHitPoints(int newCurHitPoints)
        {
            if (newCurHitPoints <= MAX_HP_VALUE)
            {
                unitStats.curHitPoints = newCurHitPoints;
            }
            else
            {
                unitStats.curHitPoints = MAX_HP_VALUE;
            }
        }

        //setter for the unit's Maximum Magic Points (MP)
        public void SetMaxMagicPoints(int newMaxMagicPoints)
        {
            if (newMaxMagicPoints <= MAX_MP_VALUE)
            {
                unitStats.maxMagicPoints = newMaxMagicPoints;
            }
            else
            {
                unitStats.maxMagicPoints = MAX_MP_VALUE;
            }
        }

        //setter for the unit's Current Magic Points (MP)
        public void SetCurMagicPoints(int newCurMagicPoints)
        {
            if (newCurMagicPoints <= MAX_MP_VALUE)
            {
                unitStats.curMagicPoints = newCurMagicPoints;
            }
            else
            {
                unitStats.curMagicPoints = MAX_MP_VALUE;
            }
        }

        //setter for the unit's Strength
        public void SetStrength(int newStrength)
        {
            if (newStrength <= MAX_STAT_VALUE)
            {
                unitStats.strength = newStrength;
            }
            else
            {
                unitStats.strength = MAX_STAT_VALUE;
            }
        }

        //setter for the unit's Dexterity
        public void SetDexterity(int newDexterity)
        {
            if (newDexterity <= MAX_STAT_VALUE)
            {
                unitStats.dexterity = newDexterity;
            }
            else
            {
                unitStats.dexterity = MAX_STAT_VALUE;
            }
        }

        //setter for the unit's Agility
        public void SetAgility(int newAgility)
        {
            if (newAgility <= MAX_STAT_VALUE)
            {
                unitStats.agility = newAgility;
            }
            else
            {
                unitStats.agility = MAX_STAT_VALUE;
            }
        }

        //setter for the unit's Intelligence
        public void SetIntelligence(int newIntelligence)
        {
            if (newIntelligence <= MAX_STAT_VALUE)
            {
                unitStats.intelligence = newIntelligence;
            }
            else
            {
                unitStats.intelligence = MAX_STAT_VALUE;
            }
        }

        //setter for the unit's Wisdom
        public void SetWisdom(int newWisdom)
        {
            if (newWisdom <= MAX_STAT_VALUE)
            {
                unitStats.wisdom = newWisdom;
            }
            else
            {
                unitStats.wisdom = MAX_STAT_VALUE;
            }
        }

        //setter for the unit's Charisma
        public void SetCharisma(int newCharisma)
        {
            if (newCharisma <= MAX_STAT_VALUE)
            {
                unitStats.charisma = newCharisma;
            }
            else
            {
                unitStats.charisma = MAX_STAT_VALUE;
            }
        }

        //setter for the unit's type
        public void SetUnitType(int newUnitType)
        {
            unitStats.unitType = newUnitType;
        }

        //setter for the Unit's type name
        public void SetUnitTypeName(string newUnitTypeName)
        {
            unitStats.unitTypeName = newUnitTypeName;
        }

        //setter for the Unit's alignment
        public void SetAlignment(string newAlignment)
        {
            unitStats.alignment = newAlignment;
        }

        //setter for the Unit's id
        public void SetUnitID(int newUnitID)
        {
            unitStats.unitID = newUnitID;
        }
    }
}