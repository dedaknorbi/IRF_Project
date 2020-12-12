﻿using Homeoffice_Decider.Entitites;
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
        public Form1()
        {
            InitializeComponent();
            ugynokadatfeltoltes();
            dataGridView1.DataSource = Agents;
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
        }

        private void ugynokadatfeltoltes()
        {
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
                    efficiency = Math.Round((h1 + h2 + h3)/100+((c1+c2+c3)/(h1+h2+h3))*100,2)
                });
            }
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
