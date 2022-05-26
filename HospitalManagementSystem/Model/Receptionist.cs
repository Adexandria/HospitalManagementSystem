using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalManagementSystem.Model
{
    public class Receptionist 
    {
        [Key]
        public Guid ReceptionistId { get; set; }
        [ForeignKey("Hospital")]
        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
