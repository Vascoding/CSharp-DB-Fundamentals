using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeddingPlanner.Data.DTOs
{
    public class VanueDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("capacity")]
        public int Capacity { get; set; }
    
        [XmlElement("town")]
        public string Town { get; set; }

    }
}
