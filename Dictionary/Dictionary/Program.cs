using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary.DataStructures.Dictionary(7) ;

            for (int i = 0; i < 50; i++)
            {
                dict.Add(i);
            }

            var result1 = dict[25];

            Console.WriteLine($"collection if search 25: {string.Join(", ", result1)}");

            dict.Delete(25);

            result1 = dict[25];

            Console.WriteLine($"collection if search 25 after delete: {string.Join(", ", result1 ?? new List<int>())}");

        }
    }
}
