using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Photography.Data;
using Photography.Data.DTO;
using Photography.Models;

namespace Photography.ImportJSON
{
    public class Startup
    {
        static void Main(string[] args)
        {
            //ImportLenses();
            //ImportCameras();
            //ImportPhotographers();
        }

        private static void ImportPhotographers()
        {
            using (var context = new PhotographyContext())
            {
                string json = File.ReadAllText("../../Import/photographers.json");
                var photographers = JsonConvert.DeserializeObject<IEnumerable<PhotographerDto>>(json);

                foreach (var c in photographers)
                {
                    List<Len> lens = new List<Len>();
                    foreach (var l in c.Lenses)
                    {
                        Len len = context.Lens.Find(l);
                        if (len != null)
                        {
                            lens.Add(len);
                        }
                    }
                    if (c.FirstName != null && c.LastName != null)
                    {
                        Random rnd = new Random();
                        var primary = rnd.Next(1, context.Cameras.Count());
                        var secondary = rnd.Next(1, context.Cameras.Count());
                        Camera primCam = context.Cameras.Find(primary);
                        Camera secCam = context.Cameras.Find(secondary);
                        Photographer photographer = new Photographer()
                        {
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Phone = c.Phone,
                            PrimaryCamera = primCam,
                            SecondaryCamera = secCam
                        };
                        context.Photographers.Add(photographer);
                        int lensCount = 0;
                        foreach (var l in lens)
                        {
                            if (l.CompatibleWith == photographer.PrimaryCamera.Make || l.CompatibleWith == photographer.SecondaryCamera.Make)
                            {
                                photographer.Lens.Add(l);
                                lensCount++;
                            }
                        }
                        Console.WriteLine($"Successfully imported {c.FirstName} {c.LastName} | Lenses: {lensCount}");
                    }
                    else
                    {
                        Console.WriteLine($"Error. Invalid data provided");
                    }
                }
                context.SaveChanges();
            }
        }

        private static void ImportCameras()
        {
            using (var context = new PhotographyContext())
            {
                string json = File.ReadAllText("../../Import/cameras.json");
                var cameras = JsonConvert.DeserializeObject<IEnumerable<CameraDto>>(json);

                foreach (var c in cameras)
                {
                    if (c.Type != null && c.Make != null && c.Model != null && c.MinIso >= 100)
                    {
                        Camera camera = new Camera()
                        {
                            Type = c.Type,
                            Make = c.Make,
                            Model = c.Model,
                            MinIso = c.MinIso,
                            MaxIso = c.MaxIso,
                            IsFullFrame = c.IsFullFrame,
                            MaxShutterSpeed = c.MaxShutterSpeed,
                            MaxFrameRate = c.MaxFrameRate,
                            MaxVideoResolution = c.MaxVideoResolution
                        };
                        context.Cameras.Add(camera);
                        Console.WriteLine($"Successfully imported {c.Type} {c.Make} {c.Model}");
                    }
                    else
                    {
                        Console.WriteLine("Error. Invalid data provided");
                    }
                }
                context.SaveChanges();
            }
        }

        private static void ImportLenses()
        {
            using (var context = new PhotographyContext())
            {
                string json = File.ReadAllText("../../Import/lenses.json");
                var lenses = JsonConvert.DeserializeObject<IEnumerable<LensDto>>(json);

                foreach (var l in lenses)
                {
                    Len len = new Len()
                    {
                        Make = l.Make,
                        FocalLength = l.FocalLength,
                        MaxAperture = l.MaxAperture,
                        CompatibleWith = l.CompatibleWith
                    };
                    context.Lens.Add(len);
                    Console.WriteLine($"Successfully imported {l.Make} {l.FocalLength}mm f{l.MaxAperture}");
                }
                context.SaveChanges();
            }
        }
    }
}
