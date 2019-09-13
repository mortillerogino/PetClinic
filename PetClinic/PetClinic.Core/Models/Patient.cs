using Newtonsoft.Json;
using PetClinic.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Core.Models
{
    public class Patient
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }

        public string ApplicationUserID { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Diagnosis> Diagnoses { get; set; }
    }
}
