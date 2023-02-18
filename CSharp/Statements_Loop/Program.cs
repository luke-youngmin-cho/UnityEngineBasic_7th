// 반복문을 사용할 때는
// 무한루프에 빠지지 않도록 조건을 주의해서 설정해줘야함.

// while 반복문
// 형태 : 
// while (반복할 조건)
// { 반복할 내용 }

int count = 0;
while (count <= 5)
{
    Console.WriteLine(count);
    count++;
}

do
{
    Console.WriteLine(count);
    count++;
} while (count < 5);

// for 문의 구조
// for (처음할 연산내용; 반복시작 전에 체크할 논리값; 반복후에 할 연산내용)
// {반복내용}

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}