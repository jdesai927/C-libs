using System;
using System.Collections.Generic;

namespace trialgame {
	public class PriorityQueue<T> where T : class, IComparable<T>
	{
	    private List<T> array;
	
	    private int size;
	
	    public PriorityQueue()
	    {
	        array = new List<T>();
	        array.Add(null);
	        size = 0;
	    }
	
	    private bool PercolateUp(T elem, int index)
	    {
	        if (index == 1 || index == 0)
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
	        array.Add(elem);
	        size++;
	        int currentIndex = size;
	        bool perc = true;
	        while (perc)
	        {
	            perc = PercolateUp(elem, currentIndex);
	            currentIndex /= 2;
	        }
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
	        if (size == 0)
	        {
	            throw new KeyNotFoundException();
	        }
	        T elem = array[1];
	        array[1] = array[size];
	        T toPerc = array[1];
	        array.RemoveAt(size);
	        array.TrimExcess();
	        int currentIndex = 1;
	        while (currentIndex * 2 < array.Count && currentIndex * 2 + 1 < array.Count)
	        {
	            currentIndex = PercolateDown(toPerc, currentIndex);
	        }
	        size--;
	        return elem;
	    }
		
		public void Remove(T elem)
		{
			int i = array.IndexOf(elem);
            if (i == -1)
                throw new ArgumentException();
			array[i] = array[size];
			T toPerc = array[i];
			array.RemoveAt(size);
			while (i * 2 < array.Count && i * 2 + 1 < array.Count)
	        {
	            i = PercolateDown(toPerc, i);
	        }
			size--;
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
}
