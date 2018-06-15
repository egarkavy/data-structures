using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Models
{
    public class SegmentModel
    {
        public List<int> Values { get; set; }
        
        public SegmentModel()
        {
            Values = new List<int>();
        }
    }
}
