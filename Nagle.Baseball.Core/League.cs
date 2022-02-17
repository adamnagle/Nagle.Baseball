using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagle.Baseball
{
    public class League
    {
        public int Name { get; set; }

        public List<Team> Teams { get; set; } = new List<Team>();
    }
}
