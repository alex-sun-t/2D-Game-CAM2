using System;
using System.Windows.Controls;

namespace Coop_Exam
{
    public class AI
    {
        public ICharacter Character { get => SelectRandomCharacter(); }
        public void Battle(ICharacter PlayerCharacter)
        {
            Random rnd = new Random();

            int flag = rnd.Next(15);

            if (Character.GetHP() <= 100 && Character.GetHP() >= 80)
            {
                if (flag >= 0 && flag <= 5)
                    PlayerCharacter.SetHP(Character.Hit());
                else if (flag >= 6 && flag <= 11)
                {
                    PlayerCharacter.SetHP(Character.Spell());

                    if(Character.GetMana() < 50)
                    {
                        PlayerCharacter.Hit();
                    }
                }
                else if (flag >= 12 && flag <= 13)
                {
                    Character.Heal();
                    if (Character.GetMana() < 20)
                    {
                        PlayerCharacter.SetHP(Character.Hit());
                    }
                }
                else if (flag >= 14 && flag <= 15)
                {
                    Character.SetShild(true);
                    if (Character.GetMana() < 30)
                    {
                        PlayerCharacter.SetHP(Character.Hit());
                    }
                }
            }
            else if (Character.GetHP() < 80 && Character.GetHP() >= 40)
            {
                if (flag >= 0 && flag <= 4)
                    PlayerCharacter.SetHP(Character.Hit());
                else if (flag >= 5 && flag <= 7 && Character.GetMana() < 50)
                {
                    PlayerCharacter.SetHP(Character.Spell());
                }
                else if (flag >= 8 && flag <= 11 && Character.GetMana() > 20)
                {
                    Character.Heal();
                }

                else if (flag >= 12 && flag <= 15)
                {
                    Character.SetShild(true);
                    if(Character.GetMana() < 30)
                    {
                        PlayerCharacter.SetHP(Character.Hit());
                    }
                }
            }
            else if (Character.GetMana() < 39 && Character.GetMana() > 0)
            {
                if (flag >= 0 && flag <= 3)
                    PlayerCharacter.SetHP(Character.Hit());
                else if (flag >= 4 && flag <= 6 && Character.GetMana() < 50)
                {
                    PlayerCharacter.SetHP(Character.Spell());
                }
                else if (flag >= 7 && flag <= 11 && Character.GetMana() > 20)
                {
                    Character.Heal();
                }

                else if (flag >= 12 && flag <= 15)
                {
                    Character.SetShild(true);
                    if(Character.GetMana() < 30)
                    {
                        PlayerCharacter.SetHP(Character.Hit());
                    }
                }
            }
        }

        public ICharacter SelectRandomCharacter()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 3);
            if (num == 1)
                return new Knight();
            else if (num == 2)
                return new Archer();
            else if (num == 3)
                return new Mage();
            return null;
        }
    }
}
