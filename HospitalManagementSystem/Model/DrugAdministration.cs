using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalManagementSystem.Model
{
    public class DrugAdministration
    {
        [Key]
        public Guid DrugId { get; set; }
        public string Drug { get; set; }

        [ForeignKey("Pharmacist")]
        public Guid PharmacistId { get; set; }
        public Pharmacist Pharmacist { get; set; }

        [ForeignKey("Appointment")]
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }


        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        public int Quantity { get; set; }
    }
}
