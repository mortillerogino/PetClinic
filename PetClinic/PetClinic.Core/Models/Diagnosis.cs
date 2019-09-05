using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Core.Models
{
    public class Diagnosis
    {
        public Guid Id { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }

        public Patient Patient { get; set; }
        public Veterinarian Veterinarian { get; set; }
    }
}
