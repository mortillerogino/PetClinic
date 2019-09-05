using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Core.Models
{
    public class Veterinarian
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Specialization> Specializations { get; set; }
    }
}
