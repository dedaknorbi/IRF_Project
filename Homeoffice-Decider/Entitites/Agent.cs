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
        public int hours { get; set; }
        public int contracts { get; set; }
        public decimal efficiency { get; set; }
    }
}
