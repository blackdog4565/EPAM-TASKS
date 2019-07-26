using System;
using System.Collections;
using System.Collections.Generic;

namespace task_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    public class DynamicArray<T> : IEnumerable<T>
    {
        private int _defaultCapacity = 8;
        private T[] _array;
        private int _length = 0;
        public int Capacity { get; private set; }
        public int Length { get; private set; }
        public DynamicArray()
        {
            Capacity = _defaultCapacity;
            _array = new T[Capacity];
        }
        public DynamicArray(int userCapacity)
        {
            Capacity = userCapacity;
            _array = new T[Capacity];
        }
        public DynamicArray(IEnumerable<T> userCollection)
        {
            Capacity = GetLength(userCollection);
            _array = new T[Capacity];

            foreach (var item in userCollection)
            {
                this.Add(item);
            }
        }
        public void Add(T item)
        {
            if (Length + 1 > Capacity)
            {
                Capacity++;
                T[] t = new T[Capacity];

                for (int i = 0; i < Length; i++)
                {
                    t[i] = _array[i];
                }
                _array = t;
            }
            _array[Length] = item;
            Length++;
        }
        public void AddRange(IEnumerable<T> userCollection)
        {
            Capacity = Length + GetLength(userCollection);
            Console.WriteLine(Capacity);

            T[] temp = new T[Capacity];

            int index = 0;

            foreach (var item in _array)
            {
                temp[index] = item;
                index++;
            }

            foreach (var item in userCollection)
            {
                temp[index] = item;
                index++;
            }

            Length = temp.Length;
            _array = temp;
        }
        public bool Remove(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i].Equals(item))
                {
                    for (int j = i; j < Length - 1; j++)
                    {
                        _array[i] = _array[i+1];
                        i++;
                    }
                    Length--;
                    for (int k = 0; k < Length; k++)
                    {
                        _array[k] = _array[k];
                    }
                    return true;
                }
            }
            return false;
        }
        public bool Insert(T item, int pos)
        {
            try
            {
                Length++;
                if (Capacity < Length)
                {
                    Capacity++;
                }
                T[] temp = new T[Length];

                for (int i = 0; i < Length - 1; i++)
                {
                    temp[i] = _array[i];
                }

                if (pos == 0)
                {
                    for (int i = Length - 1; i > pos; i--)
                    {
                        temp[i] = temp[i - 1];
                    }
                }
                else
                {
                    for (int i = Length - 1; i >= pos; i--)
                    {
                        temp[i] = temp[i - 1];
                    }
                }

                temp[pos] = item;

                _array = temp;

                return true;
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public T this[int index]
        {
            get
            {
                if (index > Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _array[index];
            }
            set
            {
                if (index > Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _array[index] = value;
            }
        }
        public int GetLength(IEnumerable<T> userCollection)
        {
            int colLength = 0;
            foreach (var item in userCollection)
            {
                colLength++;
            }
            return colLength;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
