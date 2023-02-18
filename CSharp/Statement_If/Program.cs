bool condition1 = false;
bool condition2 = false;

if (condition1)
{
    //조건1이 참일때 실행할 내용
    Console.WriteLine("조건1이 참이다");
}
else if (condition2)
{
    //조건1이 거짓이고 조건2가 참일때 실행할 내용
    Console.WriteLine("조건1이 거짓이고 조건2가 참이다");
}
else
{
    //위 조건들이 모두 거짓일때 실행할 내용
    Console.WriteLine("조건 1, 조건2 모두 거짓이다");
}