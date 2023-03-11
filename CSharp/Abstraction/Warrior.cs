using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    internal class Warrior : Character
    {
        int currentWeaponID; // 0 == low, 1 == proper, 2 == high
        ISword sword;

        new public void Attack()
        {
            sword.Attack();
        }

        public void Skill()
        {
            sword.Skill();
        }
    }
}

public interface ISword
{
    void Attack();
    void Skill();
}

public interface ILowSword : ISword
{
}

public interface IProperSword : ISword
{
}

public interface IHighSword : ISword
{
}