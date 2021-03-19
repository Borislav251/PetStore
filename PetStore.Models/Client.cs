using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Client
    {
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();

            this.PetsBought = new HashSet<Pet>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(6)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string Lastname { get; set; }

        public virtual ICollection<Pet> PetsBought { get; set; }
    }
}
