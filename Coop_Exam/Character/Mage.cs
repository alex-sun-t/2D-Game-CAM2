using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Coop_Exam
{
    public class Mage : ICharacter, INotifyPropertyChanged
    {
        static private readonly int maxHP = 100;
        static private readonly int maxMana = 100;

        string name = "Mage";
        int hp = 100;
        int mana = 100;
        int power = 7;

        private bool shild = false;

        private string icon_Hit = @"Icons\Mage\Hit.png";
        private string icon_Spell = @"Icons\Mage\Spell.png";
        private string icon_Shild = @"Icons\Mage\Shild.png";

        public string Name { get => name; set { name = value; } }
        public int HP
        {
            get => hp; set
            {
                hp = value;
                if (hp > maxHP)
                    hp = maxHP;
                OnPropertyChanged();
            }
        }
        public int Mana
        {
            get => mana; set
            {
                mana = value;
                if (mana > maxMana)
                    mana = maxMana;
                OnPropertyChanged();
            }
        }
        public string Icon_Hit { get => icon_Hit; }
        public string Icon_Spell { get => icon_Spell; }
        public string Icon_Shild { get => icon_Shild; }

        public int Power { get => power; }

        public int Hit()
        {
            //ManaRegeneration();
            return Power;
        }

        public int Spell()
        {
            if (Mana < 50)
                return 0;
            //ManaRegeneration();
            return Power + 3;
        }

        public void Heal()
        {
            Random rnd = new Random();
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
            //Mana -= 30;
        }

        public List<string> Sprites_IDLE()
        {
            List<string> Sprites_Knight = new List<string>() {
            @"Animation\Mage\IDLE\IDLE_000.png",
            @"Animation\Mage\IDLE\IDLE_005.png",
            @"Animation\Mage\IDLE\IDLE_000.png",
            @"Animation\Mage\IDLE\IDLE_005.png",
            @"Animation\Mage\IDLE\IDLE_000.png",
            @"Animation\Mage\IDLE\IDLE_005.png",
            @"Animation\Mage\IDLE\IDLE_001.png",
            @"Animation\Mage\IDLE\IDLE_002.png",
            @"Animation\Mage\IDLE\IDLE_003.png",
            @"Animation\Mage\IDLE\IDLE_004.png",
            @"Animation\Mage\IDLE\IDLE_005.png"};

            return Sprites_Knight;
        }

        public List<string> Sprites_RUN()
        {
            List<string> Sprites_RUN = new List<string>() {
            @"Animation\Mage\RUN\RUN_000.png",
            @"Animation\Mage\RUN\RUN_001.png",
            @"Animation\Mage\RUN\RUN_002.png",
            @"Animation\Mage\RUN\RUN_003.png",
            @"Animation\Mage\RUN\RUN_004.png",
            @"Animation\Mage\RUN\RUN_005.png",
            @"Animation\Mage\RUN\RUN_006.png",
            @"Animation\Mage\RUN\RUN_007.png",
            @"Animation\Mage\RUN\RUN_008.png",
            @"Animation\Mage\RUN\RUN_009.png",
            @"Animation\Mage\RUN\RUN_010.png"};

            return Sprites_RUN;
        }

        public List<string> Sprites_WALK()
        {
            List<string> Sprites_WALK = new List<string>() {
            @"Animation\Mage\WALK\WALK_000.png",
            @"Animation\Mage\WALK\WALK_001.png",
            @"Animation\Mage\WALK\WALK_002.png",
            @"Animation\Mage\WALK\WALK_003.png",
            @"Animation\Mage\WALK\WALK_004.png",
            @"Animation\Mage\WALK\WALK_005.png",
            @"Animation\Mage\WALK\WALK_006.png",
            @"Animation\Mage\WALK\WALK_007.png",
            @"Animation\Mage\WALK\WALK_008.png",
            @"Animation\Mage\WALK\WALK_009.png"};

            return Sprites_WALK;
        }

        public List<string> Sprites_ATTACK()
        {
            List<string> Sprites_ATTACK = new List<string>() {
            @"Animation\Mage\ATTACK\ATTACK_000.png",
            @"Animation\Mage\ATTACK\ATTACK_001.png",
            @"Animation\Mage\ATTACK\ATTACK_002.png",
            @"Animation\Mage\ATTACK\ATTACK_003.png",
            @"Animation\Mage\ATTACK\ATTACK_004.png",
            @"Animation\Mage\ATTACK\ATTACK_005.png",
            @"Animation\Mage\ATTACK\ATTACK_006.png"};

            return Sprites_ATTACK;
        }

        public List<string> Sprites_DIE()
        {
            List<string> Sprites_DIE = new List<string>() {
            @"Animation\Knight\DIE\DIE_000.png",
            @"Animation\Knight\DIE\DIE_001.png",
            @"Animation\Knight\DIE\DIE_002.png",
            @"Animation\Knight\DIE\DIE_003.png",
            @"Animation\Knight\DIE\DIE_004.png",
            @"Animation\Knight\DIE\DIE_005.png",
            @"Animation\Knight\DIE\DIE_006.png",
            @"Animation\Knight\DIE\DIE_007.png",
            @"Animation\Knight\DIE\DIE_008.png",
            @"Animation\Knight\DIE\DIE_009.png"};

            return Sprites_DIE;
        }

        public List<string> Sprites_SPELL_Part_1()
        {
            List<string> Sprites_DIE = new List<string>() {
            @"Animation\Mage\SPELL\SPELL_000.png",
            @"Animation\Mage\SPELL\SPELL_001.png",
            @"Animation\Mage\SPELL\SPELL_002.png",
            @"Animation\Mage\SPELL\SPELL_003.png"};

            return Sprites_DIE;
        }

        public List<string> Sprites_SPELL_Part_2()
        {
            List<string> Sprites_DIE = new List<string>() {
            @"Animation\Mage\SPELL\SPELL_004.png",
            @"Animation\Mage\SPELL\SPELL_005.png",
            @"Animation\Mage\SPELL\SPELL_006.png"};

            return Sprites_DIE;
        }

        public void ManaPrice(int manaPrice)
        {
            Mana -= manaPrice;
        }
    }
}
