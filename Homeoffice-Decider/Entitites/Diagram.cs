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
        int a, b, c;
        public Diagram(decimal y1, decimal y2, decimal y3)
        {
            a = Convert.ToInt32(y1*40); b = Convert.ToInt32(y2 *40); c = Convert.ToInt32(y3 *40);
            AutoSize = false;
            Width = 300;
            Height = Width;
            Paint += Diagram_Paint;

        }

        private void Diagram_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected void DrawImage(Graphics g)
        {
            g.DrawLine(new Pen(Color.Gray, 3), 0, 0, 0, 300);
            g.DrawLine(new Pen(Color.Gray, 4), 0, 300, 300, 300);

            g.DrawLine(new Pen(Color.Gray, 3), 0, 240, 5, 240);
            g.DrawLine(new Pen(Color.Gray, 3), 0, 180, 5, 180);
            g.DrawLine(new Pen(Color.Gray, 3), 0, 120, 5, 120);
            g.DrawLine(new Pen(Color.Gray, 3), 0, 60, 5, 60);


            g.DrawLine(new Pen(Color.Blue, 3), 75, 300-a, 150, 300-b);
            g.DrawLine(new Pen(Color.Blue, 3), 150, 300-b, 225, 300-c);

            g.FillEllipse(new SolidBrush(Color.Blue), 70, 295 - a, 10, 10);
            g.FillEllipse(new SolidBrush(Color.Blue), 145, 295 - b, 10, 10);
            g.FillEllipse(new SolidBrush(Color.Blue), 220, 295 - c, 10, 10);
        }

    }
}