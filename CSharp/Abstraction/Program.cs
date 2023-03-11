using Abstraction;

Warrior warrior = new Warrior();
Wizard wizard = new Wizard();
Knight knight = new Knight();
Slime slime = new Slime();
Rat rat = new Rat();

warrior.Breath();
wizard.Breath();
knight.Breath();
slime.Breath();
rat.Breath();
warrior.Attack();

// 자식타입은 부모타입으로 참조가 가능하다 
Creature[] creatures = new Creature[5];
creatures[0] = warrior;
creatures[1] = wizard;
creatures[2] = knight;
creatures[3] = slime;
creatures[4] = rat;
//creatures[0].Attack();

for (int i = 0; i < creatures.Length; i++)
{
    creatures[i].Breath();
}

for (int i = 0; i < creatures.Length; i++)
{
    // is 연산자 : 왼쪽의 객체가 오른쪽 타입으로 형변환을 시도하고 가능하면 true, 아니면 false를 반환
    if (creatures[i] is IAttackable)
    {
        ((IAttackable)creatures[i]).Attack();
    }
}

// nullable 형식 : null 값 할당이 가능하다고 명시하는 형식. 여기서 nullable 해준 이유는 as 연산시 null 반환되기 때문에..
IAttackable? tmpAttackable;
for (int i = 0; i < creatures.Length; i++)
{
    // as 연산자 : 왼쪽의 객체를 오른쪽타입으로 형변환을 시도하고 성공시 캐스팅된 참조를, 실패시 null 을 반환
    tmpAttackable = creatures[i] as IAttackable;
    if (tmpAttackable != null)
    {
        tmpAttackable.Attack();
    }
}


IAttackable[] attackers = new IAttackable[4];
attackers[0] = new Warrior();
attackers[1] = new Wizard();
attackers[2] = new Knight();
attackers[3] = new Slime();
