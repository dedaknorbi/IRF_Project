using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homeoffice_Decider.Entitites
{
    public class Diagram : Label
    {
        int a=0,b=0,c=0;
        public Diagram(int y1,int y2,int y3)
        {
            a = y1;b = y2;c = y3;
            AutoSize = false;
            Width = 10;
            Height = Width;
            Paint += Diagram_Paint;
            MessageBox.Show("a");

        }

        private void Diagram_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show("b");
            DrawImage(e.Graphics);
        }

        protected void DrawImage(Graphics g)
        {
            MessageBox.Show("c");
            g.DrawLine(new Pen(Color.Blue, 3), 75, a, 150, b);
            g.DrawLine(new Pen(Color.Blue, 4), 150, b, 225, c);

        }

    }
}
