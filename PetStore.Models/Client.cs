using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using PetStore.Common;

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
        [MinLength(GlobalConstants.UsernameMinLength)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MinLength(GlobalConstants.EmailMinLength)]
        public string Email { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientNameMinLength)]
        public string Lastname { get; set; }

        public virtual ICollection<Pet> PetsBought { get; set; }
    }
}
