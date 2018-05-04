using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WeddingPlanner.Models;

namespace WeddingPlanner.Data.DTOs
{
    public class PresentDto
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("invitation-id")]
        public int InvitationId { get; set; }

        [XmlAttribute("present-name")]
        public string Name { get; set; }

        [XmlAttribute("size")]
        public string Size { get; set; }

        [XmlAttribute("amount")]
        public decimal Amount { get; set; }
    }
}
