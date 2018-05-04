using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeddingPlanner.Data.DTOs;
using WeddingPlanner.Data.Store;
using WeddingsPlanner.JSONImport.DTOs;

namespace WeddingsPlanner.JSONImport
{
    public static class JsonImport
    {
        public static void ImportAgencies()
        {
            var json = File.ReadAllText("../../Import/agencies.json");
            var agencies = JsonConvert.DeserializeObject<IEnumerable<AgencyDto>>(json);
            AgencyStore.AddAgencies(agencies);
        }

        public static void ImportPeople()
        {
            var json = File.ReadAllText("../../Import/people.json");
            var people = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(json);
            PersonStore.AddPeople(people);
        }

        public static void ImportWedings()
        {
            var json = File.ReadAllText("../../Import/weddings.json");
            var weddings = JsonConvert.DeserializeObject<IEnumerable<WeddingDto>>(json);
            WeddingStore.AddWeddings(weddings);
        }
    }
}
