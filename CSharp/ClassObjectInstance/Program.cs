// using 키워드
// using namespace이름 :
// 특정 namespsace를 이 cs에서 사용하겠다 
using ClassObjectInstance;

// 값타입, 참조타입
// 값타임 : 값을 직접 메모리에 쓰고 읽는 형태, 일반적으로 스택영역에 할당
// 참조타입 : 데이터가 있는 메모리의 주소로 값을 간접 쓰기/읽기를 하는 형태, 힙영역에 할당

// new 키워드
// 동적할당 키워드. 런타임에서 메모리를 동적할당할 때 사용
SwordMan swordMan = new SwordMan();

// .연산자
// 멤버접근연산자
swordMan.Name = "검사1";
swordMan.Attack();
swordMan.Jump();

SwordMan swordMan2 = new SwordMan();
swordMan2.Name = "검사2";

swordMan = swordMan2;
// 검사1을 점프시키고 싶은데 어떻게하지? => 안됨

Orc orc1 = new Orc();
orc1.Name = "상급오크";
orc1.Age = 210;
orc1.Height = 60.3f;
orc1.Weight = 80.2f;
orc1.Gender = '여';

Orc orc2 = new Orc();
orc2.Name = "하급오크";
orc2.Age = 140;
orc2.Height = 72.0f;
orc2.Weight = 24.4f;
orc2.Gender = '남';

orc1.SayMyName();
orc1.SayMyInfo();
orc2.SayMyName();
orc2.SayMyInfo();