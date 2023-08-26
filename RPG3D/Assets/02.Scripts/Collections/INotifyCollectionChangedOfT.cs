using System;
using UnityEditor.UnityLinker;

public interface INotifyCollectionChanged<T>
{
    event Action<int, T> ItemChanged;
    event Action<int, T> ItemAdded;
    event Action<int, T> ItemRemoved;
    event Action CollectionChanged;
}