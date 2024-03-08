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
        new Star("Sun"),
        new Planet("Mercury"),
        new Planet("Venus"),
        new Planet("Terra"),
        new Planet("Mars"),
        new Planet("Jupiter"),
        new Planet("Saturn"),
        new Planet("Uranus"),
        new Planet("Neptune"),
        new DwarfPlanet("Pluto"),
        new Moon("The Moon", new Planet("Earth"))
        };

        foreach (SpaceObject obj in solarSystem)
        {
            obj.Draw();
        }
        Console.ReadLine();

    }

}


