using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ObservableCollection<T> : INotifyCollectionChanged<T>, IEnumerable<T>
{
    public T this[int index]
    {
        get => items[index];
        set => Change(index, value);
    }

    public List<T> items = new List<T>();

    public event Action<int, T> ItemChanged;
    public event Action<int, T> ItemAdded;
    public event Action<int, T> ItemRemoved;
    public event Action CollectionChanged;

    public T Find(Predicate<T> match) => items.Find(match);
    public int FindIndex(Predicate<T> match) => items.FindIndex(match);

    public void Change(int index, T item)
    {
        items[index] = item;
        ItemChanged?.Invoke(index, item);
        CollectionChanged?.Invoke();
    }

    public void Swap(int index1, int index2)
    {
        if (index1 >= items.Count || index1 < 0 || index2 >= items.Count || index2 < 0)
            throw new IndexOutOfRangeException();

        T item2 = items[index2];
        items[index2] = items[index1];
        items[index1] = item2;
        ItemChanged?.Invoke(index1, item2);
        ItemChanged?.Invoke(index2, items[index2]);
        CollectionChanged?.Invoke();
    }

    public void Add(T item)
    {
        items.Add(item);
        ItemAdded?.Invoke(items.Count - 1, item);
        CollectionChanged?.Invoke();
    }

    public bool Remove(T item)
    {
        int index = items.IndexOf(item);
        if (index < 0)
            return false;

        RemoveAt(index);
        return true;
    }

    public void RemoveAt(int index)
    {
        T tmp = items[index];
        items.RemoveAt(index);
        ItemRemoved?.Invoke(index, tmp);
        CollectionChanged?.Invoke();
    }


    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return items.GetEnumerator();
    }
}
