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
        List<Ugynokok> Ugynokok;
        List<Agent> Agents = new List<Agent>();
        public Form1()
        {
            InitializeComponent();
            Ugynokok = context.Ugynokoks.ToList();
            foreach (var alkalmazott in Ugynokok)
            {
                Agents.Add(new Agent() { name = alkalmazott.nev, rank = alkalmazott.beosztas_fk});
            }
            int elemszám = Agents.Count();
            MessageBox.Show(Convert.ToString(elemszám));

        }
    }
}
