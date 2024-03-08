using System;
using System.Collections.Generic;

namespace SpaceSim
{
    public class SpaceObject
    {
        public String name { get; set; }

        public SpaceObject(String name)
        {
            this.name = name;
        }

        public virtual void Draw()
        {
            Console.WriteLine(name);
        }
    }

    public class Star : SpaceObject
    {
        public double OrbitalDistance {  get; set; }

        public double OrbitalPeriod {  get; set; }

        public Star(String name, double orbitalDistance, double orbitalPeriod) : base(name)
        {
            OrbitalDistance = orbitalDistance;
            OrbitalPeriod = orbitalPeriod;
        }

        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject
    {
        public double OrbitalDistance { get; set; }

        public double OrbitalPeriod { get; set; }

        public List<Moon> Moons { get; set; }

        public Planet(String name, double orbitalDistance, double orbitalPeriod) : base(name)
        {
            this.OrbitalDistance = orbitalDistance;
            this.OrbitalPeriod = orbitalPeriod;
            this.Moons = new List<Moon>();
        }

        public void AddMoon(Moon moon)
        {
            Moons.Add(moon);
        }

        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }

    public class Moon : SpaceObject
    {
        public double OrbitalDistance { get; set; }

        public double OrbitalPeriod { get; set; }
        public Planet OrbitingPlanet { get; set; }

        public Moon(String name, double orbitalDistance, double orbitalPeriod, Planet planet) : base(name)
        {
            this.OrbitalDistance = orbitalDistance;
            this.OrbitalPeriod = orbitalPeriod;  
            this.OrbitingPlanet = planet;
        }

        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }

    public class Asteroid : SpaceObject
    {
        public double OrbitalDistance { get; set; }

        public double OrbitalPeriod { get; set; }

        public Asteroid(String name, double orbitalDistance, double orbitalPeriod) : base(name)
        {
            this.OrbitalDistance= orbitalDistance;
            this.OrbitalPeriod= orbitalPeriod;  
        }

        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }

    public class Comet : SpaceObject
    {
        public double OrbitalDistance { get; set; }

        public double OrbitalPeriod { get; set; }

        public AsteroidBelt AsteroidBelt { get; set; }

        public Comet(String name, AsteroidBelt asteroidBelt, double orbitalDistance, double orbitalPeriod) : base(name)
        {
            this.OrbitalDistance = orbitalDistance;
            this.OrbitalPeriod = orbitalPeriod;
            this.AsteroidBelt = asteroidBelt;
        }

        public override void Draw()
        {
            Console.Write("Comet : ");
            base.Draw();
        }
    }

    public class AsteroidBelt : SpaceObject
    {
        public double OrbitalDistance { get; set; }

        public double OrbitalPeriod { get; set; }

        public AsteroidBelt(String name, double orbitalDistance, double orbitalPeriod) : base(name)
        {
            Asteroids = new List<Asteroid>();
            this.OrbitalDistance = orbitalDistance;
            this.OrbitalPeriod= orbitalPeriod; 
        }

        public List<Asteroid> Asteroids { get; set; }

        public override void Draw()
        {
            Console.Write("AsteroidBelt : ");
            base.Draw();
        }
    }

    public class DwarfPlanet : SpaceObject
    {
        public double OrbitalDistance { get; set; }

        public double OrbitalPeriod { get; set; }
        public DwarfPlanet(String name, double orbitalDistance, double orbitalPeriod) : base(name)
        {
            this.OrbitalDistance= orbitalDistance;
            this.OrbitalPeriod = orbitalPeriod;
        }

        public override void Draw()
        {
            Console.Write("DwarfPlanet :");
            base.Draw();
        }
    }
}
