using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeoffice_Decider.Entitites
{
    public class Agent
    {
        public string name { get; set; }
        public string rank { get; set; }
        public int h1_hours { get; set; }
        public int h1_contracts { get; set; }
        public int h2_hours { get; set; }
        public int h2_contracts { get; set; }
        public int h3_hours { get; set; }
        public int h3_contracts { get; set; }
        public decimal efficiency { get; set; }
    }
}
