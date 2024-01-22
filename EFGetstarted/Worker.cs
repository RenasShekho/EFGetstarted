using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetstarted
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public List<Team>? Teams { get; set; }
    }
}
