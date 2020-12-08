using Homeoffice_Decider.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homeoffice_Decider
{
    public partial class Form1 : Form
    {
        UgynokEntities context = new UgynokEntities();
        List<Agent> Agents;
        public Form1()
        {
            InitializeComponent();
            Agents = context.Ugynokoks.ToList();
        }
    }
}
