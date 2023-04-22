using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Player
    {
        public int hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
                //onHpChanged(value);
                //onHpChanged.Invoke(value); // 인자로 넘겨받은 값의 레이스컨디션을 해결해줌
                onHpChanged?.Invoke(value); // ? : Null check 연산자. Null 이 아닐경우 대리자 호출 
            }
        }
        private int _hp;
        public int hpMin = 0;
        public int hpMax = 100;
        // 대리자 타입 선언
        public delegate void HpChangedHandler(int hp);
        // 대리자 선언
        //public event HpChangedHandler onHpChanged;
        // event 한정자. 해당 대리자를 += 과 -= 의 L-Value 로서만 사용할 수 있도록 제한하는 한정자.
        // (외부에서 직접 호출하는것을 막는 제한자.)

        public event Action<int> onHpChanged; // Action 대리자 : void 반환, n 개의 파라미터를 받는 대리자
        public event Func<int, float> func; // Func 대리자 : <T> 반환, n 개의 파라미터를 받는 대리자
        public event Predicate<int> predicate; // Predicate 대리자 : bool 반환, n 개의 파라미터를 받는 대리자

        public Player()
        {
            hp = hpMax;
        }
    }
}
