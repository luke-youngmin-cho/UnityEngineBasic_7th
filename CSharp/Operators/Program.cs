int a = 14;
int b = 5;
int c = 0;

// 산술연산자
// 더하기, 빼기, 곱하기, 나누기, 나머지
//==============================================================

// 더하기
c = a + b;
Console.WriteLine(c);

// 빼기
c = a - b;
Console.WriteLine(c);

// 곱하기
c = a * b;
Console.WriteLine(c);

// 나누기
// 정수간 나눗셈은 소숫점을 버린 정수를 반환
c = a / b;
Console.WriteLine(c);

// 나머지
// 실수간 나머지셈은 정수간 나머지셈과 동일하게 수행
c = a % b;
Console.WriteLine(c);

// 증감 연산자
// 증가 , 감소
//==================================================================

// 증가연산
++c; // 전위연산 == c = c + 1;
c++; // 후위연산
c = 0;
Console.WriteLine(++c);
Console.WriteLine(c++);
Console.WriteLine(c);

// 감소연산
--c; // 전위연산 == c = c - 1;
c--;

// 관계 연산자
// 같음, 다름, 크기 등 비교 연산자
// 관계연산자의 연산결과가 참이면 true, 거짓이면 false 반환
//===============================================================
Console.WriteLine("관계연산");

// 같음 비교
Console.WriteLine(a == b);

// 다름 비교
Console.WriteLine(a != b);

// 크기 비교
Console.WriteLine(a > b);
Console.WriteLine(a >= b);
Console.WriteLine(a < b);
Console.WriteLine(a <= b);

// 복합 대입 연산자
// 산술연산자와 복합해놓은 대입연산자
//================================================================
c = 20;
c += b; // == c = c + b;
c -= b; // == c = c - b;
c *= b; // == c = c * b;
c /= b; // == c = c / b;
c %= b; // == c = c % b;

// 논리 연산자 (bool 연산용 연산자)
// or, and, xor, not. 연산결과도 bool
//=================================================================
Console.WriteLine("논리연산");
bool A = true;
bool B = false;

// or 
// 둘 중 하나라도 참이면 true 를 반환, 그외 false를 반환
Console.WriteLine(A | B);

// and
// 둘 다 참일때만 true, 나머지 false
Console.WriteLine(A & B);

// xor
// 둘 중 하나만 참일때 true , 그외 false
Console.WriteLine(A ^ B);

// not
// bool 값을 반전시키는 연산수행 (true -> false, false -> true)
Console.WriteLine(!A);

// 조건부 논리연산자
// 조건부 or, 조건부 and
//===================================================================

// 조건부 or
// 첫번째 피연산자가 true 이면 B 읽지 않고 true 반환
Console.WriteLine(A || B);

// 조건부 and
// 첫번째 피연산자가 false 이면 B 읽지 않고 false 반환
Console.WriteLine(A && B);

// 비트 연산자
// or, and, xor, not, shift-left, shift-right
//====================================================================

// a == 2^3 + 2^2 + 2^1 == 00000000 00000000 00000000 00001110
// b == 2^2 + 2^0       == 00000000 00000000 00000000 00000101
//
// or 
Console.WriteLine(a | b);
// result               == 00000000 00000000 00000000 00001111 == 17

// and
Console.WriteLine(a & b);
// result               == 00000000 00000000 00000000 00000100 == 4

// xor
Console.WriteLine(a ^ b);
// result               == 00000000 00000000 00000000 00001011 == 11

// not
Console.WriteLine(~a);
// result               == 11111111 11111111 11111111 11110001 == -15

// 2의 보수 
// : 2진수로 표현했을때 모든 자릿수 반전후에 +1 
// 컴퓨터가 마이너스 부호를 처리하는 방법
// ~a + 1 == -a
// ~-a + 1 == a

// -a     == 11111111 11111111 11111111 11110010
//~-a     == 00000000 00000000 00000000 00001101
//~-a + 1 == 00000000 00000000 00000000 00001110 == a

// a      == 00000000 00000000 00000000 00001110 == 14
// a << 2 == 00000000 00000000 00000000 00111000 = 56
Console.WriteLine(a << 2);
Console.WriteLine(a >> 1);