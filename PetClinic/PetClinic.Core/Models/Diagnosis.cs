using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Core.Models
{
    public class Diagnosis
    {
        [Key]
        public Guid Id { get; set; }
        public string Notes { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        public Patient Patient { get; set; }

        [Required]
        public Veterinarian Veterinarian { get; set; }
    }
}
