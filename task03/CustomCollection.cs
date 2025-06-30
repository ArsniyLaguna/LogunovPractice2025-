using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace task03
{
    public class CustomCollection<T> : IEnumerable<T>
    {
        private List<T> myList = new List<T>(); // начинающий мог бы назвать так

        public void Add(T element)
        {
            myList.Add(element);
        }

        public void Remove(T item) // нет проверки, удалится или нет
        {
            myList.Remove(item);
        }

        public IEnumerator<T> GetEnumerator() // использует встроенный итератор, без защиты
        {
            return myList.GetEnumerator(); // без try/catch и т.п.
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); // просто делегирует
        }

        public IEnumerable<T> GetReverseEnumerator() // просто foreach с индексом
        {
            for (int i = myList.Count - 1; i >= 0; i--)
            {
                yield return myList[i]; // начинающий мог бы не использовать LINQ
            }
        }

        public static IEnumerable<int> GenerateSequence(int start, int count) // всё в одном методе
        {
            for (int i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }

        public IEnumerable<T> FilterAndSort(Func<T, bool> filter, Func<T, IComparable> sort) // IComparable вместо IComparer<T>
        {
            return myList
                .Where(filter)
                .OrderBy(sort);
        }
    }
}