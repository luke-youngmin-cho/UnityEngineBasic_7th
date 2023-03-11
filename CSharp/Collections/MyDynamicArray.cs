using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class MyDynamicArray
    {
        // const 키워드
        // 상수 키워드, const 키워드가 붙은 변수는 초기화만 가능하며, 상수처럼 사용됨.
        private const int DEFAULT_SIZE = 1;
        private int[] _data = new int[DEFAULT_SIZE];
        public int Count; // 현재 자료 갯수 (배열의 길이가 아님)

        // 삽입 알고리즘
        // 일반적인 경우에 O(1)
        // Capacity(배열의 크기) 가 모자랄때는 O(N)
        public void Add(int item)
        {
            // 여유공간이 부족하면 더 큰 크기의 배열을 만들고 기존 데이터 복제후 기존 배열은 날림
            if (Count >= _data.Length)
            {
                // 더 큰 크기 배열 만듦
                // (현재 데이터 갯수의 10의 승수 + 1 사이즈 만큼 더 큰 배열을 만듦)
                int[] tmp = new int[_data.Length + (int)Math.Ceiling(Math.Log10(_data.Length)) + DEFAULT_SIZE];

                // 기존 데이터 복제
                for (int i = 0; i < Count; i++)
                {
                    tmp[i] = _data[i];
                }

                // 새 배열참조로 변경 ( 기존 배열을 날림 )
                _data = tmp;
            }
            _data[Count] = item;
            Count++;
        }

        // 탐색 알고리즘
        // O(N)
        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_data[i] == item)
                    return true;
            }

            return false;
        }

        public int FindIndex(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_data[i] == item)
                    return i;
            }

            return -1;
        }

        // 삭제 알고리즘
        // O(N)
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                return false;

            for (int i = index; i < Count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            Count--;
            _data[Count] = default(int);
            return true;            
        }

        public bool Remove(int item)
        {
            return RemoveAt(FindIndex(item));
        }
    }
}
