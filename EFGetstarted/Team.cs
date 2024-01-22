using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetstarted
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public List<Worker>? Workers { get; set;}
    }
}
