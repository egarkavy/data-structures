using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListAsSum.DataStructures
{
    public class Node
    {
        public int Power { get; set; }
        public int FreeMember { get; set; }
        public Node Next { get; set; }

        public Node(int power, int freeMember, Node next = null)
        {
            Power = power;
            FreeMember = freeMember;
            Next = next;
        }
    }
}
