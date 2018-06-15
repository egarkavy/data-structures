using System;
using System.Collections;
using System.Collections.Generic;

namespace ListAsSum.DataStructures
{
    public class ListLikeSum: IEnumerable, IEnumerator
    {
        public Node Head { get; set; }
        public bool MoveNext()
        {
            if (Current == null)
            {
                Current = Head;
            }
            else
            {
                Current = (Current as Node).Next;
            }

            return Current != null;
        }

        public void Reset()
        {
            Current = Head;
        }

        public object Current { get; private set; }
        public int Count => Tail.Power + 1;

        public Node Tail
        {
            get
            {
                var current = Head;
                if (Head == null) return null;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                return current;
            }
        }

        public ListLikeSum()
        {
            Head = null;
        }

        public Node At(int index)
        {
            if (Head == null) return null;

            var current = Head;

            while (current.Power != index && current.Next != null)
            {
                current = current.Next;
            }

            if (current.Power == index)
            {
                return current;
            }

            return null;
        }

        public void Init(int freeMember, int power)
        {
            Head = new Node(0, 0);

            InitFrom(freeMember, power, 1);
        }

        public void InitFrom(int freeMember, int power, int from)
        {
            var current = Tail;
            for (int i = from; i < power; i++)
            {
                current.Next = new Node(i, 0);
                current = current.Next;
            }

            current.Next = new Node(power, freeMember);
        }

        public void Add(int freeMember, int power)
        {
            if (Head == null)
            {
                Init(freeMember, power);

                return;
            }

            var elementAt = At(power);
            if (elementAt != null)
            {
                elementAt.FreeMember += freeMember;
                return;
            }

            InitFrom(freeMember, power, Tail.Power + 1);
        }

        public void Add(int member)
        {
            if (Head != null)
            {
                Tail.Next = new Node(Tail.Power + 1, member);
            }
            else
            {
                Head = new Node(0, member);
            }

            
        }

        public void Add(ListLikeSum left, ListLikeSum right)
        {
            var largest = left.Count > right.Count ? left : right;
            var smallest = left.Count > right.Count ? right : left;
            for (int i = 0; i < largest.Count; i++)
            {
                var largestCurrent = largest.At(i);
                var smallestCurrent = smallest.At(i);

                if (smallestCurrent != null)
                {
                    Add(smallestCurrent.FreeMember + largestCurrent.FreeMember);
                }
                else
                {
                    Add(largestCurrent.FreeMember);
                }
            }
        }

        public long Meaning(int x)
        {
            long accomulator = 0;

            var current = Head;
            
            while (current != null) 
            {
                accomulator += (long)Math.Pow(x, current.Power) * current.FreeMember;

                current = current.Next;
            }

            return accomulator;
        }

        public override bool Equals(object obj)
        {
            var compararble = obj as ListLikeSum;
            if (compararble == null)
            {
                return false;
            }

            return Meaning(2) == compararble.Meaning(2);
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}