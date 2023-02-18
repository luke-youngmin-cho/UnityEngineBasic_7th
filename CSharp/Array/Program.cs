// 배열
// 특정한 자료형을 연속적으로 할당해놓은(메모리상에서 이어져있음) 형태의 자료구조

// 배열 선언 형태
// : 자료형[] 배열이름
// 배열 동적할당 형태
// :
// 1. new 자료형[자료갯수]
// 2. { 자료1, 자료2 ... }
// 3. new 자료형[자료갯수] {자료1, 자료2, .... }
// 배열은 '참조'형 이며, 힙영역에 동적할당함.
int[] arrInt = new int[3];
int[] arrInt2 = { 1, 3, 5, 2 };
float[] arrFloat = new float[4] { 1.0f, 2.1f, 3.4f, 2.2f };

// 인덱서
// [] 
// 인덱스 접근하기위한 연산자
// 일반적인 배열에서 인덱서는 
// 해당 배열의 주소 + 인덱스 * 단위자료형 위치의 주소로부터 단위자료형만큼 데이터에 접근
arrInt[0] = 1;
arrInt[1] = 2;
//arrInt[3] = 3; // 범위를 벗어난 인덱스접근은 예외처리됨

int index = 0;
while (index < arrFloat.Length)
{
    Console.WriteLine(arrFloat[index]);
    index++;
}

for (int i = 0; i < arrFloat.Length; i++)
{
    Console.WriteLine(arrFloat[i]);
}