using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data.DTO
{
    public class CameraDto
    {
        public string Type { get; set; }
        public string Make { get; set; }
        
        public string Model { get; set; }

        public bool IsFullFrame { get; set; }

        
        public int MinIso { get; set; }

        public string MaxIso { get; set; }

        public int MaxShutterSpeed { get; set; }

        public string MaxVideoResolution { get; set; }

        public int MaxFrameRate { get; set; }
    }
}
