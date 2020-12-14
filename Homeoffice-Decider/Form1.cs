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
        UgynokokEntities1 context = new UgynokokEntities1();
        List<Ugynokok> Ugynokok;
        BindingList<Agent> Agents = new BindingList<Agent>();
        Szures szuro = Szures.semmire;

        private Diagram _nextDiagram;
        private Diagramkeszito _vonaldiagram;
        public Diagramkeszito Vonaldiagram
        {
            get { return _vonaldiagram; }
            set { _vonaldiagram = value;
                DisplayNext();
            }
        }

        public Form1()
        {
            InitializeComponent();
            ugynokadatfeltoltes();
            tablazatformazas();
            dataGridView1.CurrentCell=dataGridView1[0,0];
            Vonaldiagram = new Diagramkeszito();
        }

        private void ugynokadatfeltoltes()
        {
            Agents.Clear();
            Ugynokok = context.Ugynokok.ToList();
            foreach (var u in Ugynokok)
            {
                decimal h1= Convert.ToDecimal((from x in context.Munkak
                                             where u.ugynok_sk == x.ugynok_fk
                                             select x.h1_dolgozott_orak).FirstOrDefault());
                decimal c1 = Convert.ToDecimal((from x in context.Munkak
                                                where u.ugynok_sk == x.ugynok_fk
                                                select x.h1_szerzodesek).FirstOrDefault());
                decimal h2 = Convert.ToDecimal((from x in context.Munkak
                                                where u.ugynok_sk == x.ugynok_fk
                                                select x.h2_dolgozott_orak).FirstOrDefault());
                decimal c2 = Convert.ToDecimal((from x in context.Munkak
                                                where u.ugynok_sk == x.ugynok_fk
                                                select x.h2_szerzodesek).FirstOrDefault());
                decimal h3 = Convert.ToDecimal((from x in context.Munkak
                                                where u.ugynok_sk == x.ugynok_fk
                                                select x.h3_dolgozott_orak).FirstOrDefault());
                decimal c3 = Convert.ToDecimal((from x in context.Munkak
                                                where u.ugynok_sk == x.ugynok_fk
                                                select x.h3_szerzodesek).FirstOrDefault());
                Agents.Add(new Agent()
                {
                    name = u.nev,
                    rank = u.beosztas_fk,
                    h1_hours = Convert.ToInt32(h1),
                    h1_contracts = Convert.ToInt32(c1),
                    h2_hours = Convert.ToInt32(h2),
                    h2_contracts = Convert.ToInt32(c2),
                    h3_hours = Convert.ToInt32(h3),
                    h3_contracts = Convert.ToInt32(c3),
                    efficiency = Math.Round((h1 + h2 + h3)/100+(c1+c2+c3),2)
                });
            }
        }

        private void jutalomkiosztas()
        {
            for (int i = 0; i < Agents.Count; i++)
            {
                Agents[i].jutalom = false;
                int sorrend = 0;
                for (int j = 0; j < Agents.Count; j++)
                {
                    if (Agents[i].efficiency < Agents[j].efficiency)
                    {
                        sorrend++;
                    }
                }
                if (sorrend < Convert.ToInt32(textBox1.Text))
                {
                    Agents[i].jutalom = true;
                }
            }
            dataGridView1.Refresh();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < Agents.Count; i++)
            {
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = DefaultBackColor;
                if (Agents[i].jutalom)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void szures()
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                szuro = Szures.mindkettore;
            }
            if (!checkBox1.Checked && checkBox2.Checked)
            {
                szuro = Szures.oraszamra;
            }
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                szuro = Szures.poziciora;
            }
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                szuro = Szures.semmire;
            }

            if (szuro == Szures.poziciora)
            {
                for (int i = 0; i < Agents.Count; i++)
                {
                    if (Agents[i].rank == "Vezérigazgató" || Agents[i].rank == "Regionális vezető")
                    {
                        Agents.RemoveAt(i);
                    }
                }
            }

            if (szuro == Szures.oraszamra)
            {
                for (int i = 0; i < Agents.Count; i++)
                {
                    if (Agents[i].h1_hours + Agents[i].h2_hours + Agents[i].h3_hours<320)
                    {
                        Agents.RemoveAt(i);
                    }
                }
            }

            if (szuro == Szures.mindkettore)
            {
                for (int i = 0; i < Agents.Count; i++)
                {
                    if ((Agents[i].h1_hours + Agents[i].h2_hours + Agents[i].h3_hours) < 320
                        || Agents[i].rank == "Vezérigazgató" || Agents[i].rank == "Regionális vezető")
                    {
                        Agents.RemoveAt(i);
                    }
                }
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            ugynokadatfeltoltes();
            szures();
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            ugynokadatfeltoltes();
            szures();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            jutalomkiosztas();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Vonaldiagram = new Diagramkeszito();
        }
        private void DisplayNext()
        {
            decimal y1 = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value)
                + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value) / 100;
            decimal y2 = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value)
                + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value) / 100;
            decimal y3 = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value)
                + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value) / 100;
            if (_nextDiagram !=null)
            {
                panel1.Controls.Remove(_nextDiagram);
            }
            _nextDiagram = Vonaldiagram.CreateNew(y1, y2, y3);
            panel1.Controls.Add(_nextDiagram);
        }
        private void tablazatformazas()
        {
            dataGridView1.DataSource = Agents;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Columns[0].HeaderText = "Név";
            dataGridView1.Columns[1].HeaderText = "Beosztás";
            dataGridView1.Columns[2].HeaderText = "1. hónap óraszám";
            dataGridView1.Columns[3].HeaderText = "2. hónap szerződések";
            dataGridView1.Columns[4].HeaderText = "2. hónap óraszám";
            dataGridView1.Columns[5].HeaderText = "2. hónap szerződések";
            dataGridView1.Columns[6].HeaderText = "3. hónap óraszám";
            dataGridView1.Columns[7].HeaderText = "3. hónap szerződések";
            dataGridView1.Columns[8].HeaderText = "Hatékonysági mutató";
            dataGridView1.Columns[9].HeaderText = "Jutalom";
            dataGridView1.Columns[1].Width = 95;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[5].Width = 70;
            dataGridView1.Columns[6].Width = 60;
            dataGridView1.Columns[7].Width = 70;
            dataGridView1.Columns[8].Width = 75;
            dataGridView1.Columns[9].Width = 55;
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
        }
    }
}
