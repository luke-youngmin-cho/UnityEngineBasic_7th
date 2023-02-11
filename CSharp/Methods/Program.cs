//Method ⊂ Function

// 함수 
// 함수 선언
// C# 에서는 추상화를 할 때만 함수 선언을 함.

// 함수 정의
// 반환타입 함수이름 (매개변수1타입 매개변수1이름, 매개변수2타입 매개변수2이름)
// {
//  구현부
//  return 반환값
// }

int Sum(int op1, int op2)
{
    // return 
    // 이 함수가 할당된 스택영역의 메모리 제어권을 반환한다 &
    // 함수의 연산 결과값을 반환한다.
    return op1 + op2;
}

// 3가지 실수를 더하고 결과 콘솔창에 출력 후 연산결과를 반환하는 함수 작성
// 1 . 3가지 실수를 더해야한다
// 2.  더한 연산결과값을 콘솔창에 출력한다.
// 3.  연산결과값을 반환한다.
float SumFloat(float op1, float op2, float op3)
{
    // 지역변수 : { } 영역 안에서 선언되고 해당 영역을 벗어나면 메모리 해제되는 변수
    float result = op1 + op2 + op3;
    Console.WriteLine(result);
    return result;
}

// void : 정해진 타입이 없음
void SayHello()
{
    Console.WriteLine("Hello");
    return; // void 반환 하는 함수의 가장 마지막라인의 return 은 생략가능.
}


int result = 0;
// 함수 호출
// 형태 :
// 함수이름(인자1, 인자2 ...);
result = Sum(1, 1);
Console.WriteLine($"1 + 1 = {result}");

//