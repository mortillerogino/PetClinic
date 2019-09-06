using PetClinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Core.DTO
{
    public class PaginatedPatientsDto
    {
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
    }
}
