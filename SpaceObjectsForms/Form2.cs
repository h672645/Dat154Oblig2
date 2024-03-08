using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solarsystemanimation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }






        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            this.BackColor = Color.Black;
            Brush sol = new SolidBrush(Color.Yellow);
            Brush mercury = new SolidBrush(Color.SandyBrown);
            Brush venus = new SolidBrush(Color.Brown);
            Brush earth = new SolidBrush(Color.Blue);
            Brush mars = new SolidBrush(Color.Red);
            Brush jupiter = new SolidBrush(Color.DarkKhaki);
            Brush saturn = new SolidBrush(Color.Beige);
            Brush uranus = new SolidBrush(Color.Cyan);
            Brush neptune = new SolidBrush(Color.AliceBlue);
            Brush moon = new SolidBrush(Color.Gray);
            Brush asteroid = new SolidBrush(Color.LightGray);
            Brush comet = new SolidBrush(Color.LightBlue);
            Brush pluto = new SolidBrush(Color.Silver);
            g.FillEllipse(sol, 0, 0, 50, 50);
            g.FillEllipse(mercury, 77, 0, 20, 20);
            g.FillEllipse(venus, 130, 0, 25, 25);
            g.FillEllipse(earth,160,0,25,25);
            g.FillEllipse(mars,200,0,20,20);
            g.FillEllipse(jupiter,300,0,40,40);
            g.FillEllipse(saturn, 360, 0, 35, 35);
            g.FillEllipse(uranus, 410,0,30,30);
            g.FillEllipse(neptune,460,0,30,30);
            g.FillEllipse(pluto,510,0,15,15);
        }
       
    }

    }

