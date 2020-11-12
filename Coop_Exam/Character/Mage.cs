using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Coop_Exam
{
    public class Mage : ICharacter, INotifyPropertyChanged
    {
        static private readonly int maxHP = 100;
        static private readonly int maxMana = 100;

        string name = "Mage";
        int hp = 100;
        int mana = 100;
        int power = 3;

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
            ManaRegeneration();
            return Power;
        }

        public int Spell()
        {
            int manaPrice = 50;
            if (Mana < 50)
                return 0;
            Mana -= manaPrice;
            ManaRegeneration();
            return Power + 3;
        }

        public void Heal()
        {
            int manaPrice = 20;
            if (Mana < 20)
                return;
            Random rnd = new Random();
            Mana -= manaPrice;
            ManaRegeneration();
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
            Mana -= 30;
        }

        public ICollection<string> Animation_IDLE()
        {
            List<string> Sprites_Knight = new List<string>() {
            @"Animation\Mage\IDLE\IDLE_000.png",
            @"Animation\Mage\IDLE\IDLE_001.png",
            @"Animation\Mage\IDLE\IDLE_002.png",
            @"Animation\Mage\IDLE\IDLE_003.png",
            @"Animation\Mage\IDLE\IDLE_004.png",
            @"Animation\Mage\IDLE\IDLE_005.png",
            @"Animation\Mage\IDLE\IDLE_006.png",
            @"Animation\Mage\IDLE\IDLE_007.png",
            @"Animation\Mage\IDLE\IDLE_008.png",
            @"Animation\Mage\IDLE\IDLE_009.png"};

            return Sprites_Knight;
        }
    }
}
