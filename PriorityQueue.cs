using System;
using System.Collections.Generic;

public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> array;

    private int size;

    public PriorityQueue()
    {
        array = new List<T>(1);
        size = 0;
    }

    private bool PercolateUp(T elem, int index)
    {
        if (index == 1)
        {
            return false;
        }
        T parent = array[index/2];
        if (parent.CompareTo(elem) > 0)
        {
            array[index/2] = elem;
            array[index] = parent;
        }
        else
        {
            return false;
        }
        return index == 2 || index == 3 || elem.CompareTo(array[index/4]) < 0;
    }

    public void Add(T elem)
    {
        array.Capacity++;
        array[size + 1] = elem;
        int currentIndex = size + 1;
        bool perc = true;
        while (perc)
        {
            perc = PercolateUp(elem, currentIndex);
            currentIndex /= 2;
        }
        size++;
    }

    private int PercolateDown(T elem, int index)
    {
        T child1 = array[index * 2];
        T child2 = array[(index * 2) + 1];
        T childToSwap = child1;
        int indexToSwap = index * 2;
        if (child1.CompareTo(child2) > 0)
        {
            childToSwap = child2;
            indexToSwap++;
        }
        array[index] = childToSwap;
        array[indexToSwap] = elem;
        return indexToSwap;
    }

    public T Remove()
    {
        T elem = array[1];
        array[1] = array[size];
        array.RemoveAt(size);
        array.TrimExcess();
        int currentIndex = 1;
        bool perc = true;
        while (perc)
        {
            currentIndex = PercolateDown(elem, currentIndex);
            perc = !((elem.CompareTo(array[currentIndex * 2]) < 0) && (elem.CompareTo(array[currentIndex * 2 + 1])) < 0);
        }
        size--;
        return elem;
    }

    public int Size()
    {
        return size;
    }

    public bool Empty()
    {
        return size == 0;
    }

    public static void main()
    {

    }

}

