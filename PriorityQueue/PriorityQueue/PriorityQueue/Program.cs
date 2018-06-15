using PriorityQueue.DataStructures;
using PriorityQueue.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new NormalyzedPriorityQueue<int>();

            queue.Add(Priority.Highest, 1);
            queue.Add(Priority.Medium, 5);
            queue.Add(Priority.Low, 7);
            queue.Add(Priority.Low, 8);
            queue.Add(Priority.Medium, 6);
            queue.Add(Priority.Highest, 2);
            queue.Add(Priority.High, 4);
            queue.Add(Priority.Highest, 3);

            var node = queue.PopNode();
            
            while(node != null)
            {
                Console.WriteLine("{0, 10} {1, 5}", node.Priority, node.Data);
                node = queue.PopNode();
            }

            Console.WriteLine();

            queue = new NormalyzedPriorityQueue<int>();

            queue.Add(Priority.Highest, 1);
            queue.Add(Priority.Medium, 2);
            queue.Add(Priority.Low, 3);
            queue.Add(Priority.Low, 4);
            queue.Add(Priority.Medium, 5);
            queue.Add(Priority.Highest, 6);
            queue.Add(Priority.High, 7);
            queue.Add(Priority.Highest, 8);
            queue.Add(Priority.Highest, 9);
            queue.Add(Priority.Highest, 0);
            queue.Add(Priority.Highest, 11);
            queue.Add(Priority.Highest, 12);
            queue.Add(Priority.Highest, 13);
            queue.Add(Priority.Lowest, 14);
            queue.Add(Priority.Lowest, 15);

            node = queue.PopNode();

            while (node != null)
            {
                Console.WriteLine("{0, 10} {1, 5}", node.Priority, node.Data);
                node = queue.PopNode();
            }
        }
    }
}
