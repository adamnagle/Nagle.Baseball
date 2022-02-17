using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagle.Baseball
{
    public class Team
    {
        public User Manager { get; set; }

        public Team(User manager)
        {
            Manager = manager;
        }

        public List<Player> Players { get; set; } = new List<Player>();

        public List<Player> StartingLinupDefault { get; set; } = new List<Player>();

        public List<GameSnapshot> GameSnapshots { get; set; } = new List<GameSnapshot>();
    }
}
