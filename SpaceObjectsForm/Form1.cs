using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SpaceSim;

namespace SpaceObjectsForm
{
    public partial class Form1 : Form
    {
        private ComboBox spaceObjectsComboBox; // Declare a ComboBox variable
        private SpaceObject selectedSpaceObject;

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



        public Form1()
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

            Button exitButton = new Button();
            exitButton.Text = "X";
            exitButton.Font = new Font(exitButton.Font.FontFamily, 12f, FontStyle.Bold);
            exitButton.ForeColor = Color.White;
            exitButton.BackColor = Color.Red;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exitButton.Size = new Size(30, 30);
            exitButton.Location = new Point(this.Width - exitButton.Width - 10, 10);
            exitButton.Click += (sender, e) => this.Close(); // Close the form when the button is clicked

            this.Controls.Add(exitButton); // Add the exit button to the form

            initializeOtherSpaceObjects();

            foreach (var spaceObject in spaceObjects)
            {
                spaceObjectsComboBox.Items.Add(spaceObject.Name);
            }

            this.Controls.Add(spaceObjectsComboBox);
            selectedSpaceObject = spaceObjects.Find(obj => obj.Name == "Sun");
        }

        private void initializeOtherSpaceObjects()
        {
            foreach (var planet in spaceObjects)
            {
                if (planet is Planet planetObj)
                {
                    switch (planetObj.Name)
                    {
                        case "Earth":
                            planetObj.AddMoon(new Moon("Moon", 384, 27.32, planetObj));
                            break;

                        case "Mars":
                            planetObj.AddMoon(new Moon("Phobos", 9, 0.32, planetObj));
                            planetObj.AddMoon(new Moon("Deimos", 23, 1.26, planetObj));
                            break;

                        case "Jupiter":
                            planetObj.AddMoon(new Moon("Metis", 128, 0.29, planetObj));
                            planetObj.AddMoon(new Moon("Adrastea", 129, 0.30, planetObj));
                            planetObj.AddMoon(new Moon("Amalthea", 181, 0.50, planetObj));
                            planetObj.AddMoon(new Moon("Thebe", 222, 0.67, planetObj));
                            planetObj.AddMoon(new Moon("Io", 422, 1.77, planetObj));
                            planetObj.AddMoon(new Moon("Europa", 671, 3.55, planetObj));
                            planetObj.AddMoon(new Moon("Ganymede", 1070, 7.15, planetObj));
                            planetObj.AddMoon(new Moon("Callisto", 1883, 16.69, planetObj));
                            break;

                        case "Saturn":
                            planetObj.AddMoon(new Moon("Pan", 134, 0.58, planetObj));
                            planetObj.AddMoon(new Moon("Atlas", 138, 0.60, planetObj));
                            planetObj.AddMoon(new Moon("Prometheus", 139, 0.61, planetObj));
                            planetObj.AddMoon(new Moon("Pandora", 142, 0.63, planetObj));
                            planetObj.AddMoon(new Moon("Epimetheus", 151, 0.69, planetObj));
                            break;

                        case "Uranus":
                            planetObj.AddMoon(new Moon("Cordelia", 50, 0.34, planetObj));
                            planetObj.AddMoon(new Moon("Ophelia", 54, 0.38, planetObj));
                            planetObj.AddMoon(new Moon("Bianca", 59, 0.43, planetObj));
                            break;

                        case "Neptune":
                            planetObj.AddMoon(new Moon("Naiad", 48, 0.29, planetObj));
                            planetObj.AddMoon(new Moon("Thalassa", 50, 0.31, planetObj));
                            planetObj.AddMoon(new Moon("Despina", 53, 0.33, planetObj));
                            break;

                        case "Pluto":
                            planetObj.AddMoon(new Moon("Charon", 20, 6.39, planetObj));
                            planetObj.AddMoon(new Moon("Nix", 49, 24.86, planetObj));
                            planetObj.AddMoon(new Moon("Hydra", 65, 38.21, planetObj));
                            break;
                    }
                }
            }
        }

        private void SpaceObjectsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string selectedObjectName = spaceObjectsComboBox.SelectedItem.ToString();

            selectedSpaceObject = spaceObjects.Find(obj => obj.Name == selectedObjectName);

            Invalidate();
        }

        private void DrawCenteredObject(Graphics g, SpaceObject spaceObject, Brush b)
        {
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            Brush brush = b;
            double visualSize = spaceObject.Size;

            int objectX = centerX - (int)(visualSize / 2);
            int objectY = centerY - (int)(visualSize / 2);

            int childX = 0;
            int childY = 0;

            g.FillEllipse(brush, objectX, objectY, (float)visualSize, (float)visualSize);


            if (spaceObject is Star sun)
            {
                // Iterate over all space objects
                foreach (SpaceObject childObject in spaceObjects)
                {
                    // Check if the current space object orbits the sun
                    if (childObject is Planet planet)
                    {
                        // Calculate position of the child planet relative to the sun
                        childX += centerX + (int)childObject.CalculateXPosition(0);
                        childY += centerY + (int)childObject.CalculateYPosition(0);

                        // Draw the child planet
                        brush = GetPlanetColor(childObject.Name);
                        g.FillEllipse(b, childX, childY, childObject.Size, childObject.Size);
                    }
                }
            }
        }

        private Brush GetPlanetColor(string planetName)
        {
           
            Brush defaultBrush = Brushes.White;

           
            switch (planetName)
            {
                case "Sun":
                    return Brushes.Yellow;
                case "Mercury":
                    return Brushes.OrangeRed;
                case "Venus":
                    return Brushes.SandyBrown;
                case "Earth":
                    return Brushes.Blue;
                case "Mars":
                    return Brushes.Red;
                case "Jupiter":
                    return Brushes.SandyBrown; 
                case "Saturn":
                    return Brushes.Beige;
                case "Uranus":
                    return Brushes.Cyan; 
                case "Neptune":
                    return Brushes.AliceBlue; 
                case "Pluto":
                    return Brushes.Silver; 
                default:
                    return defaultBrush;
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

            

            if (selectedSpaceObject != null)
            {
                DrawCenteredObject(g, selectedSpaceObject, GetPlanetColor(selectedSpaceObject.Name));
            }

            // Optionally, draw moons and other celestial bodies here
        }
    }
}
