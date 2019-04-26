﻿using System;

namespace TBD_TBG
{
    public class Stats
    {
        //CLASS ATTRIBUTES
        public string archetype; //the player's archetype (Palidin, Rogue, Fighter, or Adventurer)
            //stats
        private int agility; //affects evasion and who goes first (if you have greater agi then your opponent you go first)
        private double evasion; //chance of an enemy hitting you
        private int attack; //damage done with attacks
        private int maxHP; //maximum health
        private int currentHP; //current health. You lose when this reaches zero.

        //CLASS CONSTRUCTORS
            //for the player
        public Stats(string _arch)
        {
            archetype = _arch;
            SetInitialArchStats();

        }       
            //for enemies    
        public Stats(int _agi, int _att, int _maxHP)
        {
            agility = _agi;
            attack = _att;
            maxHP = _maxHP;
            currentHP = maxHP;
        }
        private void SetInitialArchStats()
        {
            //we can always rebalance the archetype stats later
            //TODO: Change to a switch statement
            //TODO: Change to lists to set stats in one line
            if (archetype == "Adventurer")
            { //balanced stats
                agility = 20;
                attack = 40;
                maxHP = 100;
            }
            else if (archetype == "Paladin") //focus on hp
            {
                agility = 15;
                attack = 30;
                maxHP = 130;
            }
            else if (archetype == "Brawler") //focus on attack
            {
                agility = 25;
                attack = 50;
                maxHP = 80;
            }
            else if (archetype == "Rogue") //focus on agility
            {
                agility = 35;
                attack = 45;
                maxHP = 75;                
            }
            currentHP = maxHP;
            SetEvasionStat();
        }
        //CLASS METHODS

            //determines the evasion stat based off of the playe's agility stat
            //evasion should never be greater than 100% 
        private void SetEvasionStat()
        {
            evasion = (0.01*(agility))/(1+(0.01)*(agility));//chance to be hit by an enemy attack
            //evasion should be greater than 0 and less than 1
            //EX: 0 agi = 0 eva, 20 agi = .28 eva, 50 agi = 50 eva, 100 agi = 60 eva
            //diminishing returns on evasion with more agility            
        }
            //getters
        public int GetAgilty()
        {
            return agility; 
        }
        public double GetEvasion()
        {
            return evasion; 
        }
        public int GetAttack()
        {
            return attack;
        }
        public int GetCurrentHP()
        {
            return currentHP;
        }
        public int GetMaxHP()
        {
            return maxHP;
        }
        public string GetStatOverview()
        {
            string str = "";
            str += "Agility: " + agility + "\n";
            str += "Evasion: " + (100*evasion).ToString("#.00") + "%\n";
            str += "Attack: " + attack + "\n";
            str += "Current HP: " + currentHP + "\n";
            str += "Maximum HP: " + maxHP + "\n";
            return str; 
        }

        //setters
        public void SetAgilty(int _agi)
        {
            agility = _agi;
        }
        public void SetEvasion(double _eva)
        {
            evasion = _eva;
        }
        public void SetAttack(int _att)
        {
            attack = _att;
        }
        public void SetCurrentHP(int _curHP)
        {
            currentHP = _curHP;
        }
        public void SetMaxHP(int _maxHP)
        {
            maxHP = _maxHP;
        }



    }

}

