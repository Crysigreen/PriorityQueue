using System;
using System.Collections.Generic;

public class PriorityQueue<E> where E : IComparable<E>
{
    private List<E> heap;

    public PriorityQueue()
    {
        heap = new List<E>();
    }

    public int Size => heap.Count;

    public void Add(E element)
    {
        heap.Add(element);
        HeapifyUp();
    }

    public E Peek()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("PriorityQueue is empty.");

        return heap[0];
    }

    public E Poll()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("PriorityQueue is empty.");

        E root = heap[0];
        int lastIndex = heap.Count - 1;
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);

        HeapifyDown();

        return root;
    }

    private void HeapifyUp()
    {
        int currentIndex = heap.Count - 1;

        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;

            if (heap[currentIndex].CompareTo(heap[parentIndex]) > 0)
            {
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void HeapifyDown()
    {
        int currentIndex = 0;

        while (true)
        {
            int leftChildIndex = 2 * currentIndex + 1;
            int rightChildIndex = 2 * currentIndex + 2;
            int largestIndex = currentIndex;

            if (leftChildIndex < heap.Count && heap[leftChildIndex].CompareTo(heap[largestIndex]) > 0)
                largestIndex = leftChildIndex;

            if (rightChildIndex < heap.Count && heap[rightChildIndex].CompareTo(heap[largestIndex]) > 0)
                largestIndex = rightChildIndex;

            if (largestIndex != currentIndex)
            {
                Swap(currentIndex, largestIndex);
                currentIndex = largestIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void Swap(int index1, int index2)
    {
        E temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }
}

public class Program
{
    public static void Main()
    {
        // Пример использования PriorityQueue
        PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

        priorityQueue.Add(5);
        priorityQueue.Add(2);
        priorityQueue.Add(8);

        Console.WriteLine("Peek: " + priorityQueue.Peek()); // Вывод: 8
        Console.WriteLine("Poll: " + priorityQueue.Poll()); // Вывод: 8

        Console.WriteLine("Size: " + priorityQueue.Size); // Вывод: 2
    }
}
