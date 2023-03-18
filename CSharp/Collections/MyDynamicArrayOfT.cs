using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Collections
{
    internal class MyDynamicArray<T> : IEnumerable<T>
    {
        public int Count
        {
            get
            {
                return _count;
            }
        }

        public int Capacity
        {
            get
            {
                return _data.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                return _data[index];
            }
            set
            {
                _data[index] = value;
            }
        }

        // const 키워드
        // 상수 키워드, const 키워드가 붙은 변수는 초기화만 가능하며, 상수처럼 사용됨.
        private const int DEFAULT_SIZE = 1;
        private T[] _data = new T[DEFAULT_SIZE];
        private int _count; // 현재 자료 갯수 (배열의 길이가 아님)



        // 삽입 알고리즘
        // 일반적인 경우에 O(1)
        // Capacity(배열의 크기) 가 모자랄때는 O(N)
        public void Add(T item)
        {
            // 여유공간이 부족하면 더 큰 크기의 배열을 만들고 기존 데이터 복제후 기존 배열은 날림
            if (_count >= _data.Length)
            {
                // 더 큰 크기 배열 만듦
                // (현재 데이터 갯수의 10의 승수 + 1 사이즈 만큼 더 큰 배열을 만듦)
                T[] tmp = new T[_data.Length + (int)Math.Ceiling(Math.Log10(_data.Length)) + DEFAULT_SIZE];

                // 기존 데이터 복제
                for (int i = 0; i < _count; i++)
                {
                    tmp[i] = _data[i];
                }

                // 새 배열참조로 변경 ( 기존 배열을 날림 )
                _data = tmp;
            }
            _data[_count] = item;
            _count++;
        }

        // 탐색 알고리즘
        // O(N)
        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Comparer<T>.Default.Compare(_data[i], item) == 0)
                    return true;
            }

            return false;
        }

        public int FindIndex(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Comparer<T>.Default.Compare(_data[i], item) == 0)
                    return i;
            }

            return -1;
        }

        // Predicate : 파라미터 N 개를 받고 bool 값을 반환하는 함수를 등록할 수 있는 대리자
        public int FindIndex(Predicate<object> match)
        {
            for (int i = 0; i < _count; i++)
            {
                // 해당 대리자에 등록된 함수(들)을 모두 호출하고 마지막 호출된 함수가 반환한 bool 값으로 
                // 내가 원하는 조건 체크
                if (match.Invoke(_data[i]))
                    return i;
            }

            return -1;
        }

        // 삭제 알고리즘
        // O(N)
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                return false;

            for (int i = index; i < _count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _count--;
            _data[_count] = default(T);
            return true;            
        }

        public bool Remove(T item)
        {
            return RemoveAt(FindIndex(item));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            public T Current => _current;
            object IEnumerator.Current => _current;

            private T? _current;
            private int _currentIndex;
            private MyDynamicArray<T> _outer;

            // inner struct/class 에서 outer class의 멤버에 접근하기 위해서는 참조가 필요하기때문에 
            // 생성자에서 넘겨받음
            public Enumerator(MyDynamicArray<T> outer)
            {
                _outer = outer;
                _current = default(T);
                _currentIndex = -1;
            }

            public void Dispose()
            {                
            }

            public bool MoveNext()
            {
                if (_currentIndex + 1 >= _outer.Count)
                    return false;

                _currentIndex++;
                _current = _outer._data[_currentIndex]; // outer 의 private 멤버는 inner 에서 접근 가능
                return true;
            }

            public void Reset()
            {
                _current = default(T);
                _currentIndex = -1;
            }
        }
    }
}
