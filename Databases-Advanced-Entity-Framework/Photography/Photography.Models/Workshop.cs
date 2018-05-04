﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Models
{
    public class Workshop
    {

        public Workshop()
        {
            this.Participants = new HashSet<Photographer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public string Location { get; set; }

        public decimal PrciePerParticipant { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }

        public Photographer Trainer { get; set; }

        public virtual ICollection<Photographer> Participants { get; set; }
    }
}
