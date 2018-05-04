using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital
{
    class Startup
    {
        static void Main(string[] args)
        {
            var medicament = new Medicament()
            {
                
                Name = "Paracetamol",
            };


            var diagnose = new Diagnose()
            {
                
                Name = "Cold",
                Comment = "You are gonna be fine in 2 weeks"

            };

            var visitation = new Visitation()
            {
               
                Date = new DateTime(2005, 12, 5),
                Comment = "maiic",
                
            };

            var doctor = new Doctor()
            {
                Name = "dr.Stefanov",
                Speciality = "Hirurg",
            };


            var patient = new Patient()
            {
                FirstName = "Steven",
                LastName = "Segal",
                Address = "Tsar Simeon 3",
                Email = "steven@dir.bg",
                BirthDay = new DateTime(1995, 3, 23),
                MedicalInsurance = true,
                
            };

            var context = new HospitalContext();
            context.Medicaments.Add(medicament);
            context.Diagnoses.Add(diagnose);
            context.Visitations.Add(visitation);
            context.Doctors.Add(doctor);
            context.Patients.Add(patient);
            context.SaveChanges();

        }
    }
}
