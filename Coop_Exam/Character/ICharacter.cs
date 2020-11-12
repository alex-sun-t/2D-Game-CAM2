using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
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
        ICollection<string> Animation_IDLE();
    }
}
