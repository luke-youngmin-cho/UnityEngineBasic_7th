using Collections;

Random random = new Random();
int[] arr = //{ 1, 5, 3, 8, 6, 7, 2, 9, 4 };
            Enumerable
            .Repeat(0,100)
            .Select(x => random.Next(0, 100))
            .ToArray();
//SortAlgorithms.BubbleSort(arr);
//SortAlgorithms.SelectionSort(arr);
//SortAlgorithms.InsertionSort(arr);
SortAlgorithms.MergeSort(arr);
Console.WriteLine(SortAlgorithms.OpCount);

for (int i = 0; i < arr.Length; i++)
{
    Console.Write($"{arr[i]},");
}

