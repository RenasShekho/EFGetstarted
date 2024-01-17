using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFGetstarted
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public List<ToDo> Todos { get; set; } = new ();


    }
}
