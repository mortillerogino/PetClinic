using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Core.Models
{
    public class Specialization
    {
        [Key]
        public Guid Id { get; set; }

        public Veterinarian Veterinarian { get; set; }
        public Field Field { get; set; }
    }
}
