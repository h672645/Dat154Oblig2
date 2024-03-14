using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpaceSim
{
    public abstract class SpaceObject
    {
        public string Name { get; set; }
        public double OrbitalRadius { get; set; }
        public double OrbitalPeriod { get; set; }
        public int Size { get; protected set; }

        public delegate void DoTickHandler(object sender, EventArgs e);
        public event DoTickHandler DoTick;

        public SpaceObject(string name, double orbitalRadius, double orbitalPeriod)
        {
            Name = name;
            OrbitalRadius = orbitalRadius;
            OrbitalPeriod = orbitalPeriod;
            Size = 0;
        }

        public double CalculateXPosition(double time)
        {
            double angle = 2 * Math.PI * time / OrbitalPeriod;
            return OrbitalRadius * Math.Cos(angle);
        }

        public double CalculateYPosition(double time)
        {
            double angle = 2 * Math.PI * time / OrbitalPeriod;
            return OrbitalRadius * Math.Sin(angle);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DoTick?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Star : SpaceObject
    {
        public List<Planet> planets {  get; set; }
        public Star(string name, double orbitalRadius, double orbitalPeriod) : base(name, orbitalRadius, orbitalPeriod)
        {
            Size = 200;
        }

    }

    public class Planet : SpaceObject
    {
        public List<Moon> Moons { get; set; }

        public Planet(string name, double orbitalRadius, double orbitalPeriod) : base(name, orbitalRadius, orbitalPeriod)
        {
            Moons = new List<Moon>();
            Size = 100;
        }

        public void AddMoon(Moon moon)
        {
            Moons.Add(moon);
        }

    }

    public class Moon : SpaceObject
    {
        public Planet OrbitingPlanet { get; set; }

        public Moon(string name, double orbitalRadius, double orbitalPeriod, Planet planet) : base(name, orbitalRadius, orbitalPeriod)
        {
            OrbitingPlanet = planet;
            Size = 50;
        }

    }

    // Similarly, define other space objects like Asteroid, Comet, AsteroidBelt, DwarfPlanet, etc.
}