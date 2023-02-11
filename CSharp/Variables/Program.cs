// 변수 (Variables)
// 아직 정해지지 않은 값 

// 변수를 사용하겠다고 '선언' 하는것의 의미 : 
// 특정 형태의 값이 들어갈 수 있는 (쓸수있는) 메모리영역의 공간을 할당

// 변수 선언 형태 :
// 자료형 이름;
//
// 초기화 형태 : 
// 자료형 이름 = 초기화값;
// = : 대입연산자. 오른쪽에있는 값을 왼쪽에있는 변수에 대입하는 연산자.

int number1 = 25; // int : 부호가 있는 4byte 정수형
uint number2 = 4; // unsigned integer : 부호가 없는 4byte 정수형
short snum; // short : 부호가 있는 2byte 정수형
long lnum; // long : 부호가 있는 8 byte 정수형
float fnum = 2.0f; // float : 4byte 실수형
double dnum = 4.2; // double : 8byte 실수형
char c = 'k'; // char : 2 byte 문자형
string s = "안녕?"; // string : 2 byte * 문자갯수 + 1 byte (null) 문자열형
bool isTrue = false; // bool : 1 byte 논리형
