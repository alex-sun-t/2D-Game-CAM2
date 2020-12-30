using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Coop_Exam
{
    public class Archer : ICharacter, INotifyPropertyChanged
    {
        static private readonly int maxHP = 100;
        static private readonly int maxMana = 100;

        string name = "Archer";
        int hp = maxHP;
        int mana = maxMana;
        int power = 6;

        bool shild = false;

        private string icon_Hit = @"Icons\Archer\Hit.png";
        private string icon_Spell = @"Icons\Archer\Spell.png";
        private string icon_Shild = @"Icons\Archer\Shild.png";

        public string Name { get => name; set { name = value; } }
        public int HP
        {
            get => hp; set
            {
                hp = value;
                if (hp > maxHP)
                    hp = maxHP;
                OnPropertyChanged("HP");
            }
        }
        public int Mana
        {
            get => mana; set
            {
                mana = value;
                if (mana > maxMana)
                    mana = maxMana;
                OnPropertyChanged("Mana");
            }
        }
        public string Icon_Hit { get => icon_Hit; }
        public string Icon_Spell { get => icon_Spell; }
        public string Icon_Shild { get => icon_Shild; }
        public int Power { get => power; }

        public int Hit()
        {
            return Power;
        }

        public int Spell()
        {
            //int manaPrice = 50;
            //Mana -= manaPrice;
            //ManaRegeneration();     
            return Power + 3;
        }

        public void Heal()
        {
            //int manaPrice = 20;
            Random rnd = new Random();
            //Mana -= manaPrice;
            //ManaRegeneration();
            HP += rnd.Next(6, 10);
        }
        public string SetHP(int Damage)
        {
            if (shild)
            {
                shild = false;
                return "Shild!";
            }
            HP -= Damage;
            return "- " + Damage;
        }

        public void SetName(string value)
        {
            Name = value;
        }
        public int GetMana()
        {
            return Mana;
        }

        public int GetHP()
        {
            return HP;
        }

        public void ManaRegeneration()
        {
            Random rnd = new Random();
            Mana += rnd.Next(5, 15);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public bool GetShild()
        {
            return shild;
        }

        public void SetShild(bool shild)
        {
            this.shild = shild;
           // Mana -= 30;
        }

        public List<string> Sprites_IDLE()
        {
            List<string> Sprites_IDLE = new List<string>() {
            @"Animation\Archer\IDLE\IDLE_000.png",
            @"Animation\Archer\IDLE\IDLE_001.png",
            @"Animation\Archer\IDLE\IDLE_002.png",
            @"Animation\Archer\IDLE\IDLE_003.png",
            @"Animation\Archer\IDLE\IDLE_004.png",
            @"Animation\Archer\IDLE\IDLE_005.png"};

            return Sprites_IDLE;
        }

        public List<string> Sprites_ATTACK()
        {
            List<string> Sprites_ATTACK = new List<string>() {
            @"Animation\Archer\ATTACK\ATTACK_000.png",
            @"Animation\Archer\ATTACK\ATTACK_001.png",
            @"Animation\Archer\ATTACK\ATTACK_002.png",
            @"Animation\Archer\ATTACK\ATTACK_003.png",
            @"Animation\Archer\ATTACK\ATTACK_004.png"};

            return Sprites_ATTACK;
        }

        public List<string> Sprites_DIE()
        {
            List<string> Sprites_DIE = new List<string>() {
            @"Animation\Archer\DIE\DIE_000.png",
            @"Animation\Archer\DIE\DIE_001.png",
            @"Animation\Archer\DIE\DIE_002.png",
            @"Animation\Archer\DIE\DIE_003.png",
            @"Animation\Archer\DIE\DIE_004.png",
            @"Animation\Archer\DIE\DIE_005.png",
            @"Animation\Archer\DIE\DIE_006.png",
            @"Animation\Archer\DIE\DIE_007.png",
            @"Animation\Archer\DIE\DIE_008.png",
            @"Animation\Archer\DIE\DIE_009.png"};

            return Sprites_DIE;
        }

        public List<string> Sprites_RUN()
        {
            List<string> Sprites_RUN = new List<string>() {
            @"Animation\Archer\RUN\RUN_000.png",
            @"Animation\Archer\RUN\RUN_001.png",
            @"Animation\Archer\RUN\RUN_002.png",
            @"Animation\Archer\RUN\RUN_003.png",
            @"Animation\Archer\RUN\RUN_004.png",
            @"Animation\Archer\RUN\RUN_005.png",
            @"Animation\Archer\RUN\RUN_006.png",
            @"Animation\Archer\RUN\RUN_007.png",
            @"Animation\Archer\RUN\RUN_008.png",
            @"Animation\Archer\RUN\RUN_009.png",
            @"Animation\Archer\RUN\RUN_010.png",
            @"Animation\Archer\RUN\RUN_011.png",
            @"Animation\Archer\RUN\RUN_012.png",
            @"Animation\Archer\RUN\RUN_013.png"};

            return Sprites_RUN;
        }

        public List<string> Sprites_WALK()
        {
            List<string> Sprites_WALK = new List<string>() {
            @"Animation\Archer\WALK\WALK_000.png",
            @"Animation\Archer\WALK\WALK_001.png",
            @"Animation\Archer\WALK\WALK_002.png",
            @"Animation\Archer\WALK\WALK_003.png",
            @"Animation\Archer\WALK\WALK_004.png",
            @"Animation\Archer\WALK\WALK_005.png",
            @"Animation\Archer\WALK\WALK_006.png",
            @"Animation\Archer\WALK\WALK_007.png",
            @"Animation\Archer\WALK\WALK_008.png",
            @"Animation\Archer\WALK\WALK_009.png"};

            return Sprites_WALK;
        }

        public List<string> Sprites_SPELL_Part_1()
        {
            List<string> Sprites_Spell = new List<string>() {
            @"Animation\Archer\SPELL\SPELL_000.png",
            @"Animation\Archer\SPELL\SPELL_001.png",
            @"Animation\Archer\SPELL\SPELL_002.png",
            @"Animation\Archer\SPELL\SPELL_003.png",
            @"Animation\Archer\SPELL\SPELL_004.png"};

            return Sprites_Spell;
        }

        public List<string> Sprites_SPELL_Part_2()
        {
            List<string> Sprites_Spell = new List<string>() {
            @"Animation\Archer\SPELL\SPELL_005.png",
            @"Animation\Archer\SPELL\SPELL_006.png",
            @"Animation\Archer\SPELL\SPELL_007.png"};

            return Sprites_Spell;
        }

        public void ManaPrice(int manaPrice)
        {
            Mana -= manaPrice;
        }
    }
}
