using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Core.DTO
{
    public class VeterinarianDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Specializations { get; set; }
    }
}
