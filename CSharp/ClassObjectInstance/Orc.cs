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
            // this 키워드
            // 객체 자기자신의 참조를 반환하는 키워드 
            // (함수호출스택 쌓을때 멤버참조를 했던 대상인 객체의 참조를 가짐)
            Console.WriteLine($"나는 오크. 내 이름은 {this.Name} 이다.");
        }

        public void SayMyInfo()
        {
            Console.WriteLine($"이름 : {Name}, 나이 : {Age}, 키 : {Height}, 몸무게 : {Weight}, 성별 : {Gender}");
        }
    }
}
