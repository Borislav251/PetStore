using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class ClientProduct
    {
        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
