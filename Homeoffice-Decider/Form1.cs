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
        BindingList<Agent> Agents = new BindingList<Agent>();
        public Form1()
        {
            InitializeComponent();
            Ugynokok = context.Ugynokoks.ToList();
            foreach (var alkalmazott in Ugynokok)
            {
                Agents.Add(new Agent()
                {
                    name = alkalmazott.nev,
                    rank = alkalmazott.beosztas_fk,
                    hours =Convert.ToInt32((from x in context.Munkaks where alkalmazott.ugynok_sk == x.ugynok_fk select x.dolgozott_orak).FirstOrDefault()),
                    contracts = Convert.ToInt32((from x in context.Munkaks where alkalmazott.ugynok_sk == x.ugynok_fk select x.megkotott_szerzodesek).FirstOrDefault())
                }) ;
                
            }

        }
    }
}
