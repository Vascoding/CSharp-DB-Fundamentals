using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Photography.Data.DTO
{
    public class ParticipantDto
    {
        [XmlAttribute("first-name")]
        public string FristName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }
    }
}
