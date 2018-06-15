using PriorityQueue.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue.DataStructures
{
    class NormalyzedPriorityQueue<T>
    {
        private Dictionary<Priority, int> TimeForEachPriority { get; set; }

        private Node<T> Head { get; set; }

        public int CurrentPriorityIndex { get; set; }
        public int CountOfReturned { get; set; }

        private Priority[] _priorityArray = new Priority[]
           {
                Priority.Highest,
                Priority.High,
                Priority.Medium,
                Priority.Low,
                Priority.Lowest
           };

        public NormalyzedPriorityQueue(
            int timeForHighest = 5,
            int timeForHight = 4,
            int timeForMedium = 3, 
            int timeForLow = 2,
            int timeForLowest = 1)
        {
            TimeForEachPriority = new Dictionary<Priority, int>()
            {
                { Priority.Highest, timeForHighest },
                { Priority.High, timeForHight },
                { Priority.Medium, timeForMedium },
                { Priority.Low, timeForLow },
                { Priority.Lowest, timeForLowest },
            };

            CurrentPriorityIndex = 0;
        }

        public void Add(Priority priority, T data)
        {
            var newNode = new Node<T>(priority, data);
            if (Head == null)
            {
                Head = newNode;
                return;
            }

            var current = Head;

            while(current.Next != null && current.Priority != priority && (int)priority < (int)current.Next.Priority)
            {
                current = current.Next;
            }

            if (current.Next == null)
            {
                current.Next = newNode;
                return;
            }

            while (current.Next != null && current.Next.Priority == priority)
            {
                current = current.Next;
            }

            if (current.Next != null && current.Next.Next != null)
            {
                newNode.Next = current.Next;
            }

            current.Next = newNode;

            return;
        }

        private void Add(Node<T> current, Node<T> insertable)
        {
            if (current.Next == null)
            {
                current.Next = insertable;
                return;
            }

            insertable.Next = current.Next;
            current.Next = insertable;
        }

        public T Pop()
        {
            var node = PopNode();

            if (node == null)
            {
                return default(T);
            }

            return node.Data;
        }

        public Node<T> PopNode()
        {
            if (Head == null)
            {
                return null;
            }
            Node<T> resultNode;
            if (CountOfReturned >= TimeForEachPriority[_priorityArray[CurrentPriorityIndex]])
            {
                CountOfReturned = 0;
                CurrentPriorityIndex = CurrentPriorityIndex == _priorityArray.Length - 1 ? 0 : CurrentPriorityIndex + 1;
            }

            CountOfReturned++;

            resultNode = NodeAt(_priorityArray[CurrentPriorityIndex]);
            if (resultNode == null)
            {
                CountOfReturned++;
                resultNode = PopNode();
                return resultNode;
            }

            Delete(resultNode);

            return resultNode;
        }

        private Node<T> NodeAt(Priority priority)
        {
            var current = Head;

            if (current == null)
            {
                return null;
            }

            while (current.Next != null && current.Priority != priority)
            {
                current = current.Next;
            }

            if (current.Priority == priority)
            {
                return current;
            }

            return null;
        }

        public T At(Priority priority)
        {
            var result = NodeAt(priority);

            if (result != null)
            {
                return result.Data;
            }

            return default(T);
        }

        public void Delete(Node<T> node)
        {
            var current = Head;

            if (current == null || node == null)
            {
                return;
            }

            if (current == node)
            {
                Head = Head.Next;
                return;
            }

            while (current != null && current.Next != node)
            {
                current = current.Next;
            }

            if (current.Next == node)
            {
                current.Next = node.Next;
            }

        }

        public void Delete(Priority priority)
        {
            var nodeToDelete = NodeAt(priority);

            Delete(nodeToDelete);
        }
    }
}
