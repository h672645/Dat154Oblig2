using System;
using System.Reflection;

namespace SpaceSim
{


    public class SpaceObject
    {
        private int otherObjectRadius;
        private int otherRotationalSpeed;
        private double otherOrbitalRadius;
        private double otherOrbitalPeriod;

        public static double CalculateXPosition(double time, double orbitalRadius)
        {
            double radian = time * Math.PI / 180; // Convert time to radians
            double X = orbitalRadius * Math.Cos(radian);
            return X;
        }

        public static double CalculateYPosition(double time, double orbitalRadius)
        {
            double radian = time * Math.PI / 180; // Convert time to radians
            double Y = orbitalRadius * Math.Sin(radian);
            return Y;
        }


        public String name { get; set; }
        public SpaceObject(String name)
        {
            this.name = name;
        }

        public SpaceObject(string name, int otherObjectRadius, int otherRotationalSpeed, double otherOrbitalRadius, double otherOrbitalPeriod) : this(name)
        {
            this.otherObjectRadius = otherObjectRadius;
            this.otherRotationalSpeed = otherRotationalSpeed;
            this.otherOrbitalRadius = otherOrbitalRadius;
            this.otherOrbitalPeriod = otherOrbitalPeriod;
        }

        public virtual void Draw()
        {
            Console.WriteLine(name);
        }
    }
    public class Star : SpaceObject
    {
        public int ObjectRadius { get; set; }
        public int RotationalSpeed { get; set; }

        public double OrbitalRadius { get; set; }
        public double OrbitalPeriod { get; set; }

        public Star(String name, int objectRadius, int rotationalSpeed, double orbitalRadius, double orbitalPeriod) : base(name) {
            this.ObjectRadius = objectRadius;
            this.RotationalSpeed = rotationalSpeed;
            this.OrbitalRadius = orbitalRadius;
            this.OrbitalPeriod = orbitalPeriod;
        }
        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }
    public class Planet(String name, int objectRadius, int rotationalSpeed, double orbitalRadius, double orbitalPeriod) : SpaceObject(name)
    {
        public int ObjectRadius { get; set; } = objectRadius;
        public int RotationalSpeed { get; set; } = rotationalSpeed;

        public double OrbitalRadius { get; set; } = orbitalRadius;
        public double OrbitalPeriod { get; set; } = orbitalPeriod;
        public List<Moon> Moons { get; set; } = new List<Moon>();

        public void AddMoon(Moon moon)
        {
            this.Moons.Add(moon);
        }

        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }
    public class Moon : SpaceObject
    {
        protected int ObjectRadius { get; set; }

        protected double OrbitalRadius { get; set; }
        protected double OrbitalPeriod { get; set; }

        public Moon(String name, int objectRadius, double orbitalRadius, double orbitalPeriod, int otherObjectRadius, int otherRotationalSpeed, double otherOrbitalRadius, double otherOrbitalPeriod) : base(name, otherObjectRadius, otherRotationalSpeed, otherOrbitalRadius, otherOrbitalPeriod)
        {
            this.ObjectRadius = objectRadius;
            this.OrbitalPeriod = orbitalPeriod;
            this.OrbitalRadius = orbitalRadius;

        }
        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }

    public class Asteroid : SpaceObject
    {
        public int ObjectRadius { get; set; }
        public int RotationalSpeed { get; set; }

        public double OrbitalRadius { get; set; }
        public double OrbitalPeriod { get; set; }

        public Asteroid(String name, int objectRadius, int rotationalSpeed, double orbitalRadius, double orbitalPeriod) : base(name) {
            this.ObjectRadius = objectRadius;
            this.RotationalSpeed = rotationalSpeed;
            this.OrbitalRadius = orbitalRadius;
            this.OrbitalPeriod = orbitalPeriod;
        }
        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }

    public class Comet : SpaceObject
    {
        public int ObjectRadius { get; set; }


        public double OrbitalRadius { get; set; }
        public double OrbitalPeriod { get; set; }

        public Comet(String name, int objectRadius, double orbitalRadius, double orbitalPeriod) : base(name) {
            this.ObjectRadius = objectRadius;
            this.OrbitalRadius = orbitalRadius;
            this.OrbitalPeriod = orbitalPeriod;
        }
        public override void Draw()
        {
            Console.Write("Comet : ");
            base.Draw();
        }
    }

    public class AsteroidBelt : Planet
    {
        public int ObjectRadius { get; set; }
        public int RotationalSpeed { get; set; }

        public double OrbitalRadius { get; set; }
        public double OrbitalPeriod { get; set; }

        public AsteroidBelt(String name, int objectRadius, int rotationalSpeed, double orbitalRadius, double orbitalPeriod, int otherObjectRadius, int otherRotationalSpeed, double otherOrbitalRadius, double otherOrbitalPeriod) : base(name, otherObjectRadius, otherRotationalSpeed, otherOrbitalRadius, otherOrbitalPeriod) {
            this.ObjectRadius = objectRadius;
            this.OrbitalRadius = orbitalRadius;
            this.OrbitalPeriod = orbitalPeriod;
            this.RotationalSpeed = rotationalSpeed;
        }
        public override void Draw()
        {
            Console.Write("AsteroidBelt : ");
            base.Draw();
        }
    }

    public class DwarfPlanet : SpaceObject
    {

        public int ObjectRadius { get; set; }
        public int RotationalSpeed { get; set; }

        public double OrbitalRadius { get; set; }
        public double OrbitalPeriod { get; set; }
        public DwarfPlanet(String name, int objectRadius, int rotationalSpeed, double orbitalRadius, double orbitalPeriod) : base(name) {
            this.ObjectRadius = objectRadius;
            this.RotationalSpeed = rotationalSpeed;
            this.OrbitalPeriod = orbitalPeriod;
            this.OrbitalRadius = orbitalRadius;
        }
        public override void Draw()
        {
            Console.Write("DwarfPlanet :");
            base.Draw();
        }

    }

}