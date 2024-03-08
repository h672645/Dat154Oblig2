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
        public Star(String name) : base(name)
        {
     
        }

        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject
    {
        public List<Moon> Moons { get; set; }

        public Planet(String name) : base(name)
        {
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
        public Planet OrbitingPlanet { get; set; }

        public Moon(String name, Planet orbitingPlanet) : base(name)
        {
            this.OrbitingPlanet = null;
        }

        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }

    public class Asteroid : SpaceObject
    {
        public Asteroid(String name) : base(name)
        {

        }

        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }

    public class Comet : SpaceObject
    {
        public Comet(String name) : base(name)
        {
            
        }

        public override void Draw()
        {
            Console.Write("Comet : ");
            base.Draw();
        }
    }

    public class AsteroidBelt : SpaceObject
    {

        public AsteroidBelt(String name) : base(name)
        {
            Asteroids = new List<Asteroid>();
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
        public DwarfPlanet(String name) : base(name)
        {
            
        }

        public override void Draw()
        {
            Console.Write("DwarfPlanet :");
            base.Draw();
        }
    }
}
