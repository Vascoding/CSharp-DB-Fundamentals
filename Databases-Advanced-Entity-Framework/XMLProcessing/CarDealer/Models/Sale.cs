
namespace CarDealer.Models
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class Sale
    {
       
        [Key]
        public int Id { get; set; }

        public decimal Discount { get; set; }

        [JsonIgnore]
        public virtual Car Car { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }
    }
}
