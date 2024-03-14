using System;
using System.Drawing;
using System.Windows.Forms;
using SpaceSim;
using System.Collections.Generic;

namespace Solarsystemanimation
{
    public partial class Form2 : Form
    {
        private ComboBox spaceObjectsComboBox; // Declare a ComboBox variable
        public Form2()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Enable double buffering to reduce flickering
            this.WindowState = FormWindowState.Maximized; // Set window state to maximize
            this.FormBorderStyle = FormBorderStyle.None; // Remove window border

            // Initialize and configure the ComboBox
            spaceObjectsComboBox = new ComboBox();
            spaceObjectsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            spaceObjectsComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            spaceObjectsComboBox.Location = new Point(10, 10); // Position the ComboBox in the top left corner
            spaceObjectsComboBox.SelectedIndexChanged += SpaceObjectsComboBox_SelectedIndexChanged; // Handle selection change event

            // Add space objects to the ComboBox
            List<SpaceObject> spaceObjects = new List<SpaceObject>
            {
                new Star("Sun", 0, 0),
                new Planet("Mercury", 57910, 87.97),
                new Planet("Venus", 108200, 224.70),
                new Planet("Earth", 149600, 365.26),
                new Planet("Mars", 227940, 686.98),
                new Planet("Jupiter", 778330, 4332.71),
                new Planet("Saturn", 1429400, 10759.50),
                new Planet("Uranus", 2870990, 30685.00),
                new Planet("Neptune", 4504300, 60190.00),
                new Planet("Pluto", 5913520, 90550.00)
            };

            foreach (var spaceObject in spaceObjects)
            {
                spaceObjectsComboBox.Items.Add(spaceObject.Name);
            }

            this.Controls.Add(spaceObjectsComboBox); // Add the ComboBox to the form
        }

        private void SpaceObjectsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selection change event here
            string selectedObjectName = spaceObjectsComboBox.SelectedItem.ToString();
            // You can use the selectedObjectName to access the selected space object
            // For example, you can find the selected space object in the spaceObjects list and perform further actions
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
