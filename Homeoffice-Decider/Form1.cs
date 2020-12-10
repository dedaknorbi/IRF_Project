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
        Ugynokok1Entities context = new Ugynokok1Entities();
        List<Ugynokok> Ugynokok;
        BindingList<Agent> Agents = new BindingList<Agent>();
        public Form1()
        {
            InitializeComponent();
            Ugynokok = context.Ugynokok.ToList();
            foreach (var u in Ugynokok)
            {
                decimal oraszam = Convert.ToInt32((from x in context.Munkak where u.ugynok_sk == x.ugynok_fk select x.dolgozott_orak).FirstOrDefault());
                decimal szerzodesszam = Convert.ToInt32((from x in context.Munkak where u.ugynok_sk == x.ugynok_fk select x.megkotott_szerzodesek).FirstOrDefault());
                if (szerzodesszam == 0)
                {
                    Agents.Add(new Agent()
                    {
                        name = u.nev,
                        rank = u.beosztas_fk,
                        hours = Convert.ToInt32(oraszam),
                        contracts = Convert.ToInt32(szerzodesszam),
                        //efficiency = 0
                    });
                }
                else
                {
                    Agents.Add(new Agent()
                    {

                        name = u.nev,
                        rank = u.beosztas_fk,
                        hours = Convert.ToInt32(oraszam),
                        contracts = Convert.ToInt32(szerzodesszam),
                        efficiency = Math.Round(oraszam / szerzodesszam, 2) 
                    });
                }
            }

            dataGridView1.DataSource = Agents;
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if (Convert.ToInt32(dataGridView1[4,i].Value)==0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
    }
}
