using System.Threading.Tasks;
using Delegate;


Player player = new Player();
PlayerUI playerUI = new PlayerUI();
player.onHpChanged += playerUI.Refresh; // 구독 observer, listner, subscriber
//player.onHpChanged -= playerUI.Refresh; // 구독 취소

// 람다식 표현 : 함수를 선언하지않고 컴파일러가 인식할수 있는 키워드들을 생략하고 표현하는 방법
player.onHpChanged += (hp) =>
{
    Console.WriteLine("UI 가 갱신되었습니다!");
};

int count = 0;
while (true)
{
    if (count % 4 == 0)
        player.hp -= 2; // player.hp = player.hp - 2;

    //playerUI.Refresh(player.hp);
    Thread.Sleep(1000);
    count++;
}

