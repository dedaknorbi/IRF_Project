using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homeoffice_Decider.Entitites
{
    public class Tengely : Label
    {
        public Tengely()
        {
            AutoSize = false;
            Width = 300;
            Height = Width;
            Paint += Tengely_Paint;
        }

        private void Tengely_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected void DrawImage(Graphics g)
        {
            g.DrawLine(new Pen(Color.Black, 3), 0, 0, 0, 300);
            g.DrawLine(new Pen(Color.Black, 4), 0, 300, 300, 300);
        }

    }
}
