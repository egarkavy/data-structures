using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListAsSum.DataStructures;

namespace ListAsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new ListLikeSum() { 2, 5, 4, 7, 8, 1};
            var list2 = new ListLikeSum() {7, 2, 3, 0, 0};

            var list3 = new ListLikeSum {{list1, list2}};

            var list4 = new ListLikeSum { {5, 3}};
            var list5 = new ListLikeSum {{5, 3}};

            var areEq = list4.Equals(list5);
            Console.WriteLine($"is list4 eq list5 {areEq}");
            areEq = list2.Equals(list1);
            var list6 = new ListLikeSum() { 7, 2, 3 };

            var value = list6.Meaning(2);

            for (int i = 0; i < list1.Count; i++)
            {
                Console.Write($"{list1.At(i).FreeMember} ");
            }

            Console.WriteLine();
            Console.WriteLine($"is list2 eq list1 {areEq}");
        }
    }
}
