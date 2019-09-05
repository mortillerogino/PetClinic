using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Core.Models
{
    public class Veterinarian
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Specialization> Specializations { get; set; }
    }
}
