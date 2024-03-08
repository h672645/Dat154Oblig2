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
        new Star("Sun",150,100,0,0),
        new Planet("Mercury",30,100,579.10,87.97),
        new Planet("Venus",40,100,1082.00,224.70),
        new Planet("Terra", 40, 100,1496.00,365.26 ),
        new Planet("Mars", 30, 100, 2279.40,686.98),
        new Planet("Jupiter", 100,100,7783.30,4332.71),
        new Planet("Saturn",80,100,1429.400,10759.50),
        new Planet("Uranus",70,100,2870.990,30685.00),
        new Planet("Neptune",75,100,4504.300,60190.00),
        new DwarfPlanet("Pluto",20,100,5913.520,90550.00),
        new Moon("The Moon",10,384,27.32,40, 100,149600,365.26)

        };

        foreach (SpaceObject obj in solarSystem)
        {
            obj.Draw();
        }
        Console.ReadLine();

    }

}


