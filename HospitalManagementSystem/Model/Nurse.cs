using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Model
{
    public class Nurse 
    {
        [Key]
        public Guid NurseId { get; set; }
        [ForeignKey("Hospital")]
        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}