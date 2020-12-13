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
            Width = 50;
            Height = Width;
            Paint += Tengely_Paint;
        }

        private void Tengely_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }

    }
}
