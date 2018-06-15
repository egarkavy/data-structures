using Dictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.DataStructures
{
    public class Dictionary
    {
        public int Delimeter { get; set; }

        public SegmentModel[] Segments { get; set; }

        public Dictionary(int delimeter)
        {
            Delimeter = delimeter;

            Segments = new SegmentModel[Delimeter];

            for (int i = 0; i < delimeter; i++)
            {
                Segments[i] = new SegmentModel();
            }
        }
        
        public void Add(int value)
        {
            var mod = value % Delimeter;

            Segments[mod].Values.Add(value);
        }

        public List<int> this[int key]
        {
            get
            {
                var mod = key % Delimeter;

                var isHere = Segments[mod].Values.Any(x => x == key);

                return isHere ? Segments[mod].Values : null;
            }
        }

        public void Delete (int value)
        {
            var mod = value % Delimeter;

            Segments[mod].Values.Remove(value);
        }
    }
}
