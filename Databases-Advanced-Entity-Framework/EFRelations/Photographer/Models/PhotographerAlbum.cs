
namespace Photographer.Models
{
    
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   
    public enum Role
    {
        Owner,
        Viewer
    }
    public class PhotographerAlbum
    {
        [Key]
        [ForeignKey("Photographer")]
        [Column(Order = 1)]
        public int Photographer_Id { get; set; }

        public virtual Photographer Photographer { get; set; }

        [Key]
        [ForeignKey("Album")]
        [Column(Order = 2)]
        public int Album_Id { get; set; }

        public virtual Album Album { get; set; }

        public Role Role { get; set; }
    }
}
