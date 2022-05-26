using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalManagementSystem.Model
{
    public class Appointment
    {
        [Key]
        public Guid AppointmentId { get; set; }
        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime AppointmentTime { get; set; }
        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        
    }
}
