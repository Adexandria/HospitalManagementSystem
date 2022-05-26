using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Model
{
    public class Pharmacist
    {
        [Key]
        public Guid PharmacistId { get; set; }
        [ForeignKey("Hospital")]
        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }

    }
}