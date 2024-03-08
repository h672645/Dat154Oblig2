using System;
using System.Drawing;
using System.Windows.Forms;

namespace Solarsystemanimation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Enable double buffering to reduce flickering
        }

        public class CelestialBody
        {
            public double ActualOrbitalRadius { get; set; } // In pixels
            public double ActualDistanceFromSun { get; set; } // In pixels

            public double VisualSize { get; set; } // In pixels
            public double VisualPositionX { get; set; } // In pixels
            public double VisualPositionY { get; set; } // In pixels

            public void CalculateVisualProperties(double scalingFactor)
            {
                VisualSize = ActualOrbitalRadius * scalingFactor;
                VisualPositionX = ActualDistanceFromSun * scalingFactor;
                VisualPositionY = 0; // Assuming a 2D representation with the sun at the center
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            double sunSize = 100; // Example size of the sun in pixels
            double averagePlanetDistance = 100; // Example average distance of planets from the sun in pixels
            double scalingFactor = sunSize / averagePlanetDistance;


            base.OnPaint(e);
            Graphics g = e.Graphics;
            this.BackColor = Color.Black;

            CelestialBody planet = new CelestialBody { ActualOrbitalRadius = 20, ActualDistanceFromSun = 100 };
            planet.CalculateVisualProperties(scalingFactor);
            g.FillEllipse(Brushes.Blue, (float)planet.VisualPositionX+100, (float)planet.VisualPositionY+200, (float)planet.VisualSize, (float)planet.VisualSize);

            // Define brushes for each planet
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

            // Draw each planet
            g.FillEllipse(sol, 100, 100, 50, 50);
            g.FillEllipse(mercury, 77, 0, 20, 20);
            g.FillEllipse(venus, 130, 0, 25, 25);
            g.FillEllipse(earth, 160, 0, 25, 25);
            g.FillEllipse(mars, 200, 0, 20, 20);
            g.FillEllipse(jupiter, 300, 0, 40, 40);
            g.FillEllipse(saturn, 360, 0, 35, 35);
            g.FillEllipse(uranus, 410, 0, 30, 30);
            g.FillEllipse(neptune, 460, 0, 30, 30);
            g.FillEllipse(pluto, 510, 0, 15, 15);

            // Optionally, draw moons and other celestial bodies here
        }
    }
}
