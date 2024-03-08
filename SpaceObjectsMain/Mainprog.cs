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


        List<SpaceObject> solarSystem = new List<SpaceObject> { 
        
            new Planet("Sun", 0, 0),
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

        // Add moons to each planet
        foreach (var planet in solarSystem)
        {
            if (planet is Planet planetObj)
            {
                switch (planetObj.name)
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



        foreach (SpaceObject obj in solarSystem)
        {
            obj.Draw();
        }
        Console.ReadLine();

    }

}


