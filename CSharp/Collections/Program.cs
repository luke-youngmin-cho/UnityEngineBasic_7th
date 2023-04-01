using Collections;
using System.Collections;
using System.Collections.Generic;
// 자료구조
// 자료구조에서 공통적으로 구현하는 요소들은
// 탐색, 삽입, 삭제 알고리즘
// 현재 자료 갯수


#region Dynamic Array

// 내가만든 동적배열
//-----------------------------------------------------------------

MyDynamicArray myDynamicArray = new MyDynamicArray();
myDynamicArray.Add(3);
myDynamicArray.Add(1);
myDynamicArray.Add(2);

Console.WriteLine();
for (int i = 0; i < myDynamicArray.Count; i++)
{
    Console.Write($"{myDynamicArray[i]},");
}

myDynamicArray[0] = 5; // 정수 5에 대한 데이터를 가지는 Object 가 힙 영역에 새로 할당됨.

Console.WriteLine();
for (int i = 0; i < myDynamicArray.Count; i++)
{
    Console.Write($"{myDynamicArray[i]},");
}


myDynamicArray.RemoveAt(1);
myDynamicArray.Remove(5); // int 타입을 object 파라미터에 인자로 넘겨주면, object 타입으로 암시적 캐스팅이 일어남
                          // 즉, 정수 5에 대한 데이터를 가지는 Object 가 힙 영역에 새로 할당되고 이 새로 할당된 객체가
                          // 동적배열에 있으면 지워달라는 함수호출이 됨. 
                          // 따라서 기존의 5에대한 객체를 지우는게 아니라 인자를 넘겨줄때 생긴 객체를 지워달라는 요청이됨..ㅠ

object int5 = 5;
myDynamicArray.Add(int5);
myDynamicArray.Remove(int5);

myDynamicArray.RemoveAt(myDynamicArray.FindIndex(x => (int)x == 5));

Console.WriteLine();
for (int i = 0; i < myDynamicArray.Count; i++)
{
    Console.Write($"{myDynamicArray[i]},");
}

// object
// System.Object 타입, C# 의 모든 타입의 기반 타입. 
// 이 타입에 다른 객체를 참조시킬때 힙영역에 System.Object 타입의 객체가 할당됨
int a = 5;
object obj; // System.Object 타입 참조 변수 

obj = a; // a 를 System.Object 타입으로 변환한 객체를 힙영역에 할당하고 참조를 반환함. (Boxing). 일반적인 대입연산보다 약 20배 느림
obj = new System.Object();
obj = myDynamicArray;
MyDynamicArray da2 = (MyDynamicArray)obj; // Object 타입을 하위 타입으로 변환 (Unboxing). 일반적인 대입연산보다 약 4배 느림

// C# System.Collection 의 동적배열
//-------------------------------------------------------------------

ArrayList arrayList = new ArrayList();
arrayList.Add(3);
arrayList.Add('d');
arrayList.Add("안녕");

#endregion

#region Generic Dynamic Array

// 내가만든 Generic 동적 배열
//------------------------------------------------------------------------------------

MyDynamicArray<double> doubleArray = new MyDynamicArray<double>();
doubleArray.Add(3.0);
doubleArray.Add(5.0);
doubleArray.Add(2.0);
doubleArray.Add(4.0);
doubleArray.Remove(5.2);

Console.WriteLine();
Console.WriteLine("Start enumerating Generic MyDynamic array");
IEnumerator<double> enumerator = doubleArray.GetEnumerator();
while (enumerator.MoveNext())
{
    Console.Write($"{enumerator.Current},");
}
enumerator.Dispose();
enumerator.Reset();

// foreach
// foreach (순회할자료형 현재값변수 in IEnumerable)
Console.WriteLine();
Console.WriteLine("Start enumerating Generic MyDynamic array with foreach loop");
foreach (double item in doubleArray)
{
    Console.Write($"{item}, ");
}

// C# System.Collection.Generic 의 동적 배열
//-------------------------------------------------------------------------------------

List<double> doubleList = new List<double>();
doubleList.Add(2.1);
doubleList.RemoveAt(0);
doubleList.FindIndex(x => x == 3.0);
foreach (double item in doubleList)
{

}
#endregion

#region Generic LinkedList
// 내가만든 Generic LinkedList
//--------------------------------------------------------------
MyLinkedList<int> intLinkedList = new MyLinkedList<int>();
intLinkedList.AddLast(2);
intLinkedList.AddLast(3);
intLinkedList.AddFirst(5);
MyLinkedListNode<int> dummy = intLinkedList.FindLast(5);
intLinkedList.AddAfter(dummy, 6);

foreach (int value in intLinkedList)
{
    Console.WriteLine($"내 연결리스트 순회중... {value} ");
}

// C# System.Collections.Generic.LinkedList
//---------------------------------------------------------------
LinkedList<float> floatLinkedList = new LinkedList<float>();
floatLinkedList.AddFirst(3);
LinkedListNode<float>? dummy2 = floatLinkedList.FindLast(3);
floatLinkedList.AddAfter(dummy2, 5);


#endregion

#region Generic Dictionary
// 내가만든 Generic Dictionary
//---------------------------------------------------------------
MyDictionary<string, int> scores = new MyDictionary<string, int>();
scores.Add("철수", 80);
scores.Add("영희", 70);
scores.Remove("영희");
Console.WriteLine(scores["철수"]);

// C# System.Collections.Generic.Dictioanry
//---------------------------------------------------------------
Dictionary<string, char> grades = new Dictionary<string, char>();
grades.Add("철수", 'A');
grades.Add("영희", 'C');
grades.Remove("영희");

foreach (KeyValuePair<string, char> grade in grades)
{
    Console.WriteLine($"{grade.Key} 의 등급 : {grade.Value}");
}

foreach (string key in grades.Keys)
{
    Console.WriteLine($"학급생 {key}");
}

foreach (char value in grades.Values)
{
    Console.WriteLine($"등급표 {value}");
}



#endregion

#region Queue

Queue<string> queue = new Queue<string>();
// 아이템 추가
queue.Enqueue("철수");
queue.Enqueue("영희");
queue.Enqueue("미영");

// 가장 먼저 추가된 아이템 반환
Console.WriteLine(queue.Peek());
while (queue.Count > 0)
{
    // 가장 앞에있는 아이템 제거 및 제거된아이템 반환
    Console.WriteLine(queue.Dequeue());
}

#endregion

#region Stack

Stack<int> stack = new Stack<int>();

// 아이템 추가 
stack.Push(1);
stack.Push(5);
stack.Push(3);

// 가장 늦게 추가된 아이템 반환
Console.WriteLine(stack.Peek());

while (stack.Count > 0)
{
    // 가장 늦게 추가된 아이템 제거 및 반환
    Console.WriteLine(stack.Pop());
}

#endregion