using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Model
{
    public class Doctor 
    {
        [Key]
        public Guid DoctorId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Hospital")]
        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }

    }
}