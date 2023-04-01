using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class SortAlgorithms
    {
        public static int OpCount;
         

        #region Bubble Sort
        /// <summary>
        /// 거품 정렬
        /// 바로뒤의 요소가 현재 요소보다 작으면 스왑
        /// Outer for loop 가 한 번 돌 때마다 가장 큰 수의 위치가 고정
        /// O(N^2)
        /// Stable : 동일한 값의 정렬 전의 요소들의 순서가 정렬 후에도 보장됨
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
            OpCount = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        Swap(ref arr[j],ref arr[j + 1]);
                    }
                }
            }
        }
        #endregion

        #region Selection Sort
        /// <summary>
        /// 선택 정렬
        /// 현재의 바로 뒤부터 끝까지 중에서 가장 작은 수를 찾아서 스왑
        /// Outer for loop 가 한 번 돌때마다 가장 작은수의 위치가 하나씩 고정
        /// O(N^2)
        /// Unstable
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            OpCount = 0;
            int minIndex;
            for (int i = 0; i < arr.Length; i++)
            {
                minIndex = i;
                OpCount += 1;
                for (int j = i + 1;j < arr.Length ; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                        OpCount += 1;
                    }
                }
                Swap(ref arr[i], ref arr[minIndex]);
            }
        }
        #endregion

        #region Insertion Sort
        /// <summary>
        /// 삽입 정렬
        /// 현재 위치보다 이전 위치들중 더 큰 값이 있으면 해당값을 그 다음 인덱스에 덮어쓰고
        /// 위 과정이 끝나면 마지막으로 찾았던 큰값 인덱스 위치에 현재 탐색하던 위치의 값(key) 를 덮어씀
        /// O(N^2)
        /// Stable
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertionSort(int[] arr)
        {
            OpCount = 0;
            int key;
            int j;
            for (int i = 0; i < arr.Length; i++)
            {
                key = arr[i];
                j = i - 1;
                OpCount += 2;
                // key 값보다 큰값이 있을경우 해당값을 바로뒤에 덮어씀
                while (j >= 0 &&
                         arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                    OpCount += 2;
                }
                arr[j + 1] = key; // 마지막으로 찾은 key 값 보다 큰 값의 인덱스에 key 값 대입
                OpCount += 1;
            }
        }
        #endregion

        #region Merge Sort
        /// <summary>
        /// 병합 정렬
        /// 요소를 최소단위까지 나눈후에 차례대로 병합을 하면서 정렬함 (Divide & conquer)
        /// O(NLogN)
        /// Stable
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        public static void MergeSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int mid = end + (start - end) / 2 - 1; // overflow 방지용. 결론적으로는 (start + end) / 2 임
                MergeSort(arr, start, mid);
                MergeSort(arr, mid + 1, end);

                Merge(arr, start, mid, end);
            }            
        }

        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int[] tmp = new int[end - start + 1];
            for (int i = 0; i <= end - start; i++)
                tmp[i] = arr[i + start];

            int part1 = start;
            int part2 = mid + 1;
            int index = start;

            while (part1 <= mid && 
                      part2 <= end)
            {
                // part1 이 part2  이하라면 part1 을 채택
                if (tmp[part1 - start] <= tmp[part2 - start])
                {
                    arr[index++] = tmp[part1++ - start];                   
                }
                else
                {
                    arr[index++] = tmp[part2++ - start];
                }
            }

            // 남은 part1을 뒤에 쭉 이어붙여줌
            // 남은 part2 는 이미 정복된상태기때문에 그대로 쓰면됨.
            for (int i = 0; i <= mid - part1; i++)
            {
                arr[index + i] = tmp[part1 - start + i];
            }
        }

        private static void MergeObsolete(int[] arr, int start, int mid, int end)
        {
            int[] tmp = new int[end + 1];
            for (int i = 0; i <= end; i++)
                tmp[i] = arr[i];

            int part1 = start;
            int part2 = mid + 1;
            int index = start;

            while (part1 <= mid &&
                      part2 <= end)
            {
                // part1 이 part2  이하라면 part1 을 채택
                if (tmp[part1] <= tmp[part2])
                {
                    arr[index++] = tmp[part1++];
                }
                else
                {
                    arr[index++] = tmp[part2++];
                }
            }

            // 남은 part1을 뒤에 쭉 이어붙여줌
            // 남은 part2 는 이미 정복된상태기때문에 그대로 쓰면됨.
            for (int i = 0; i <= mid - part1; i++)
            {
                arr[index + i] = tmp[part1 + i];
            }
        }

        #endregion

        #region Quick Sort
        /// <summary>
        /// 빠른 정렬
        /// O(N^2)
        /// θ(NLogN)
        /// 현존하는 정렬알고리즘중에 가장 빠르다. 
        /// 정복할때마다 Pivot 에 해당하는 인덱스위치가 고정되어서 
        /// 정복할때 고려해야하는 경우의수가 계속 줄어듦.
        /// Pivot의 위치가 평균적으로 끝지점에 몰리지 않기 때문에 
        /// 이분할을 하는 경우처럼 LogN 이 된다.
        /// N^2 이 되는 경우를 최대한 방지하기위해서 Pivot을 설정하는 특별한 알고리즘을
        /// 추가로 적용할 수도 있다..
        /// Unstable
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        public static void QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int p = Partition(arr, start, end);
                QuickSort(arr, start, p - 1);
                QuickSort(arr, p + 1, end);
            }
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end + (start - end) / 2];

            while (true)
            {
                while (arr[start] < pivot) start++;
                while (arr[end] > pivot) end--;

                if (start < end)
                {
                    Swap(ref arr[start], ref arr[end]);
                }
                else
                {
                    return end; // return pivot index
                }
            }
        }

        #endregion

        #region Heap Sort
        /// <summary>
        /// Max - 힙 정렬
        /// SIFT-UP Heapfiy 시 O(NLogN)
        /// SIFT_DOWN Healpfiy 시 O(N^2)
        /// Unstable
        /// </summary>
        /// <param name="arr"></param>
        public static void HeapSort(int[] arr)
        {
            //Max-힙구조로 변환 (정렬하면서)
            HeapifyTopDown(arr);
            //HeapifyBottonUp(arr);

            //원래 구조로 변환
            InverseHeapify(arr);
        }

        // O(NLogN)
        public static void HeapifyTopDown(int[] arr)
        {
            int end = 1;
            while (end < arr.Length)
            {
                SIFT_Up(arr, 0, end++);
            }
        }

        // O(N^2)
        public static void HeapifyBottonUp(int[] arr)
        {
            int end = arr.Length - 1;
            int current = end;

            while (current >= 0)
            {
                SIFT_Down(arr, end, current--);
            }
        }

        public static void InverseHeapify(int[] arr)
        {
            int end = arr.Length - 1;
            while (end > 0)
            {
                Swap(ref arr[0], ref arr[end]);
                end--; // 마지막 아이템 고정
                SIFT_Down(arr, end, 1);
            }
        }

        // O(LogN)
        public static void SIFT_Up(int[] arr, int root, int current)
        {
            int parent = (current - 1) / 2;
            while (current > root)
            {
                if (arr[current] > arr[parent])
                {
                    Swap(ref arr[current], ref arr[parent]);
                    current = parent;
                    parent = (current - 1) / 2;
                }
                else
                {
                    break;
                }
            }
        }

        // O(N)
        public static void SIFT_Down(int[] arr, int end, int current)
        {
            int parent = (current - 1) / 2;

            while (current <= end)
            {
                // 오른쪽 자식이 더 크면 오른쪽으로 스왑
                if (current + 1 <= end &&
                    arr[current] < arr[current + 1])
                    current++;

                if (arr[current] > arr[parent])
                {
                    Swap(ref arr[current], ref arr[parent]);
                    parent = current;
                    current = parent * 2 + 1; // 왼쪽자식으로감
                }
                else
                {
                    break;
                }
            }
        }

        #endregion
        // ref 키워드 : 인자로 참조를 받고싶을 경우 사용.
        // out 키워드 : 함수 반환시 해당 파라미터 값을 반환하고 싶을 때 사용.
        private static void Swap(ref int a,ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
            OpCount += 3;
        }
    }
}
