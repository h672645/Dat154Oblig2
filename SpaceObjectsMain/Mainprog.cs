using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using SpaceSim;

class Astronomy
{
    public static void Main()
    {
        int time;

    
        List<SpaceObject> solarSystem = new List<SpaceObject>
        {
            new Planet("Sun", 0, 0), // Sun with dummy values
                new Planet("Mercury", 57910, 87.97),
                new Planet("Venus", 108200, 224.70),
                new Planet("Earth", 149600,365.26),
                new Planet("Mars", 227940, 686.98),
                new Planet("Jupiter", 778330, 4332.71),
                new Planet("Saturn", 1429400, 10759.50),
                new Planet("Uranus", 2870990, 30685.00),
                new Planet("Neptune", 4504300, 60190.00),
                new Planet("Pluto", 5913520, 90550.00),
                new Moon("Moon", 384, 27.32),
                new Moon("Phobos", 9, 0.32),
                new Moon("Deimos", 23, 1.26)

        };

        foreach (SpaceObject obj in solarSystem)
        {
            obj.Draw();
        }
        Console.ReadLine();

    }

}


