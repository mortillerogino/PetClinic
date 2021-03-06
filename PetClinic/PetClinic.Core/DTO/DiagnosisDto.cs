﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Core.DTO
{
    public class DiagnosisDto
    {
        public string Notes { get; set; }
        public Guid PatientId { get; set; }
        public string VeterinarianName { get; set; }
        public DateTime Date { get; set; }
    }
}
