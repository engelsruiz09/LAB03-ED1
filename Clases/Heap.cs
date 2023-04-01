using System;
using System.Collections.Generic;

namespace Clases
{
    public class Heap<T>
    {
        private List<ColaPrioridadNode<T>> heap;

        public Heap()
        {
            heap = new List<ColaPrioridadNode<T>>();
        }

        public void Insert(T data, int priority)
        {
            ColaPrioridadNode<T> node = new ColaPrioridadNode<T>(data, priority, null);
            heap.Add(node);
            HeapifyUp(heap.Count - 1);
        }

        public T ExtractMax()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            ColaPrioridadNode<T> max = heap[0];
            int lastIndex = heap.Count - 1;
            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);
            HeapifyDown(0);

            return max.Data;
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            if (index > 0 && heap[index].Prioridad < heap[parentIndex].Prioridad)
            {
                Swap(index, parentIndex);
                HeapifyUp(parentIndex);
            }
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int largestChildIndex = index;

            if (leftChildIndex < heap.Count && heap[leftChildIndex].Prioridad < heap[largestChildIndex].Prioridad)
            {
                largestChildIndex = leftChildIndex;
            }

            if (rightChildIndex < heap.Count && heap[rightChildIndex].Prioridad < heap[largestChildIndex].Prioridad)
            {
                largestChildIndex = rightChildIndex;
            }

            if (largestChildIndex != index)
            {
                Swap(index, largestChildIndex);
                HeapifyDown(largestChildIndex);
            }
        }

        private void Swap(int index1, int index2)
        {
            ColaPrioridadNode<T> temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }
}
