using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Photography.Models;

namespace Photography.Data.DTO
{
    public class WorkshopDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("start-date")]
        public string StartDate { get; set; }

        [XmlAttribute("end-date")]
        public string EndDate { get; set; }

        [XmlAttribute("logation")]
        public string Location { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlElement("trainer")]
        public string Trainer { get; set; }

        [XmlElement("participants")]
        public List<ParticipantDto> Participants { get; set; }
    }
}
