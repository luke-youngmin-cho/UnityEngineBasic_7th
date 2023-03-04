using HorseRacing;
using System.Threading;
// 진행 방식
//
// 말 클래스 필요
// 말 클래스는 달린거리, 이동하기(달리기) 라는 함수를 가집니다.
// 
// 프로그램 시작시
// 말 다섯마리 만들고
// 각 말은 초당 10 ~ 20 (정수형) 범위의 거리를 랜덤하게 전진.
// 각각의 말은 거리 200에 도달하면 도착해서 더이상 전진하지 않고 
// 매초 각 말들이 아직 달리고 있다면 달린 거리를, 도착했다면 도착 상태를 콘솔창에 출력 해줍니다.
// 모든 말이 도착했다면 경주를 끝내고 등수 순서대로 말들의 이름을 콘솔창에 출력 해줍니다.

Random random;
int minSpeed = 10;
int maxSpeed = 20;
int goalPosition = 200;
bool gameFinished = false;
int currentGrade = 0;
int sec = 0;

Horse[] horses = new Horse[5]; // 말의 참조를 담을 수 있는 변수 5개크기의 공간을 확보한것 (말 만든거 아님..!)
Horse[] horsesFinished = new Horse[5];

// 말 다섯마리 만들고
for (int i = 0; i < horses.Length; i++)
{
    horses[i] = new Horse();
    horses[i].Name = $"경주마{i}";
}

while (gameFinished == false)
{
    Console.WriteLine($"================================ 달리는중 ... {sec} 초 =============================");
    sec++;
    //각 말은 초당 10 ~20(정수형) 범위의 거리를 랜덤하게 전진.
    // 각각의 말은 거리 200에 도달하면 도착해서 더이상 전진하지 않고 
    // 매초 각 말들이 아직 달리고 있다면 달린 거리를, 도착했다면 도착 상태를 콘솔창에 출력 해줍니다.
    for (int i = 0; i < horses.Length; i++)
    {
        if (horses[i].IsFinished == false)
        {
            random = new Random();
            horses[i].Run(random.Next(minSpeed, maxSpeed + 1));

            if (horses[i].TotalDistance >= goalPosition)
            {
                horses[i].IsFinished = true;
                horsesFinished[currentGrade] = horses[i];
                currentGrade++;
            }

            Console.WriteLine($"{horses[i]} 의 현재 달린거리 : {horses[i].TotalDistance}"); ;
        }
        else
        {
            Console.WriteLine($"{horses[i]} 는 도착함");
        }
    }

    if (currentGrade >= horses.Length)
    {
        gameFinished = true;
    }

    Thread.Sleep(1000);
}

// 모든 말이 도착했다면 경주를 끝내고 등수 순서대로 말들의 이름을 콘솔창에 출력 해줍니다.
for (int i = 0; i < horsesFinished.Length; i++)
{
    Console.WriteLine($"{i + 1} 등 : {horsesFinished[i].Name}");
}