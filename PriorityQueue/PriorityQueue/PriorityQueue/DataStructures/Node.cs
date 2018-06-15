using PriorityQueue.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue.DataStructures
{
    public class Node<T>
    {
        public Priority Priority { get; set; }
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(Priority priority, T data, Node<T> next = null)
        {
            Priority = priority;
            Data = data;
            Next = next;
        }
    }
}
