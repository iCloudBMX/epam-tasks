using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private LinkedList<T> linkedList;

        public DoublyLinkedList()
        {
            linkedList = new LinkedList<T>();
        }

        public int Length 
        {
            get => linkedList.Count;
        }

        public void Add(T node)
        {
            if (node is null)
                throw new ArgumentNullException();

            linkedList.AddLast(node);
        }

        public void AddAt(int index, T node)
        {
            if (index < 0 || index > this.Length)
                throw new IndexOutOfRangeException();

            var head = linkedList.First;

            if (index == this.Length)
            {
                linkedList.AddLast(node);
                return;
            }               

            while(index > 0)
            {
                head = head.Next;
                index--;
            }

            linkedList.AddBefore(head, node);
        }

        public T ElementAt(int index)
        {
            if (index >= 0 && index < this.Length)
            {
                var head = linkedList.First;

                while (index > 0 && head != null)
                {
                    head = head.Next;
                    index--;
                }

                return head.Value;
            }
            else
                throw new IndexOutOfRangeException();
        }

        public IEnumerator<T> GetEnumerator() => this.linkedList.GetEnumerator();

        public void Remove(T item)
        {
            linkedList.Remove(item);
        }

        public T RemoveAt(int index)
        {
            var node = this.ElementAt(index);

            linkedList.Remove(node);

            return node;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.linkedList.GetEnumerator();    
    }
}
