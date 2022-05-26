using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalManagementSystem.Model
{
    public class Patient 
    {
        [Key]
        public Guid PatientId { get; set; }
        public string Name { get; set; }
        public PatientStatus Status { get; set; } = PatientStatus.UnRegistered;
        [ForeignKey("Hospital")]
        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
