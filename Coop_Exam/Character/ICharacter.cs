using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Coop_Exam
{
    public interface ICharacter
    {
        void SetName(string value);
        string SetHP(int Damage);
        int Hit();
        int Spell();
        void Heal();
        void ManaRegeneration();

        int GetMana();
        int GetHP();
        bool GetShild();
        void SetShild(bool shild);
        List<string> Sprites_IDLE();
        List<string> Sprites_ATTACK();
        List<string> Sprites_RUN();
        List<string> Sprites_WALK();
        List<string> Sprites_DIE();

       List<string> Sprites_SPELL_Part_1();

       List<string> Sprites_SPELL_Part_2();

        void ManaPrice(int manaPrice);
    }
}
