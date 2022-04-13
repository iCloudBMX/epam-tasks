using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> linkedList;

        public HybridFlowProcessor(DoublyLinkedList<T> linkedList)
        {
            this.linkedList = linkedList;
        }

        public T Dequeue()
        {
            return linkedList.RemoveFirst();
        }

        public void Enqueue(T item)
        {
            linkedList.Add(item);
        }

        public T Pop()
        {
            return linkedList.RemoveLast();
        }

        public void Push(T item)
        {
            linkedList.AddAt(0, item);
        }
    }
}
