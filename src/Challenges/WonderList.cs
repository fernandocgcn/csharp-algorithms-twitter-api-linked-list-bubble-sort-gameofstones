using System;

namespace Challenges
{
    /*
     * My WonderList is a simply linked list that each element (node) 
     * is linked to another throuth the Next node defined in the 
     * separated Node class. 
     * It has Count property to simplificate 
     * the return of the number of nodes contained in the list
     * and Head property wich is the first node of the list.
     * The data type of the node is generic and must implement 
     * the IComparable Interface for the BubbleSort implementation.
     */
    public class WonderList<T> where T : IComparable
    {
        private class Node
        {
            public readonly T Data;
            public Node Next;
            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }
        
        private Node Head;
        public int Count { get; private set; }

        private void ValidateOutofRangeIndex(int maxIndex, int index)
        {
            if (index < 0 || index > maxIndex)
                throw new IndexOutOfRangeException(nameof(index));
        }

        /*
         * Return the data of node at the specified index recursively.
         */
        private T GetData(int index, Node node)
        {
            ValidateOutofRangeIndex(Count - 1, index);
            return index == 0 ? node.Data : GetData(index - 1, node?.Next);
        }
        public T this[int index] => GetData(index, Head);

        /*
         * Add data to my WonderList at the specified index recursively.
         */
        private void Add(T data, int index, Node currentNode, Node previousNode = null)
        {
            ValidateOutofRangeIndex(Count, index);
            if (index > 0)
                Add(data, index - 1, currentNode?.Next, currentNode);
            else
            {
                // Add
                Count++;
                var newNode = new Node(data, currentNode);
                if (previousNode == null)
                    Head = newNode;
                else
                    previousNode.Next = newNode;
            }
        }
        public void Add(T data, int index = 0) => Add(data, index, Head);

        /*
         * Remove data from my WonderList at the specified index recursively.
         */
        private void Remove(int index, Node currentNode, Node previousNode = null)
        {
            ValidateOutofRangeIndex(Count - 1, index);
            if (index > 0)
                Remove(index - 1, currentNode?.Next, currentNode);
            else
            {
                // Remove
                Count--;
                if (previousNode == null)
                    Head = currentNode.Next;
                else
                    previousNode.Next = currentNode.Next;
            }
        }
        public void Remove(int index) => Remove(index, Head);

        /*
         * Bubble Sort is one of the simplest sorting algorithms 
         * that works by repeatedly swapping the adjacent elements 
         * if they are in wrong order, 
         * going through the sequence several times, 
         * causing the biggest element in the sequence 
         * to bubble to the top (last position).
         * Here, it is sorting my WonderList recursively!
         */
        private void BubbleSort(int count)
        {
            for (int i = 0; i < count; i++)
                if (this[i].CompareTo(this[i + 1]) > 0)
                {
                    var aux = this[i];
                    Remove(i);
                    Add(aux, i + 1);
                }
            if (count > 0) BubbleSort(count - 1);
        }
        public void BubbleSort() => BubbleSort(Count - 1);

        public override string ToString()
        {
            var list = $"{GetHashCode()}[{Count}]: {{";
            var node = Head;
            while (node != null)
            {
                list += node.Data?.ToString() +
                    (node.Next == null ? "" : ", ");
                node = node.Next;
            }
            return list + "}";
        }
    }
}
