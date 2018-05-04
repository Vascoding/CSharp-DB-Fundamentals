using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Models
{
    public class Camera
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Type { get; set; }

        public bool IsFullFrame { get; set; }

        [Required]
        public int MinIso { get; set; }

        public string MaxIso { get; set; }

        public int MaxShutterSpeed { get; set; }

        public string MaxVideoResolution { get; set; }

        public int MaxFrameRate { get; set; }

    }
}
