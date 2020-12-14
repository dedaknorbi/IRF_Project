using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeoffice_Decider.Entitites
{
    public class Diagramkeszito
    {
        public Diagram CreateNew(int y1, int y2, int y3)
        {
            return new Diagram(y1,y2,y3);
        }
    }
}
