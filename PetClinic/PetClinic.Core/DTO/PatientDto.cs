using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Core.DTO
{
    public class PatientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserName { get; set; }
    }
}
