using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalManagementSystem.Model
{
    public class MedicalCondition
    {
        public Guid MedicalConditionId { get; set; }
        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public string Description { get; set; }
    }
}
