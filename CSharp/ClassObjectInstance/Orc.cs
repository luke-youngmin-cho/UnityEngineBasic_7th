using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObjectInstance
{
    internal class Orc
    {
        public string Name;
        public int Age;
        public float Height;
        public float Weight;
        public char Gender;

        public void SayMyName()
        {
            Console.WriteLine($"나는 오크. 내 이름은 {Name} 이다.");
        }

        public void SayMyInfo()
        {
            Console.WriteLine($"이름 : {Name}, 나이 : {Age}, 키 : {Height}, 몸무게 : {Weight}, 성별 : {Gender}");
        }
    }
}
