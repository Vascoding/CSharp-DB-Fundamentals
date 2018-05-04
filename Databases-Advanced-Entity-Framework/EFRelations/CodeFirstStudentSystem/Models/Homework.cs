using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstStudentSystem.Models
{
    public enum ContentType
    {
        Application,
        Pdf,
        Zip
    }
    public class Homework
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

    }
}
