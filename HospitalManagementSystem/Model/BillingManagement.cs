using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Model
{
    public class BillingManagement
    {
        [Key]
        public Guid BillingId { get; set; }
        public int Price { get; set; }
        public BillStatus Status { get; set; }
        public int OutstandingBill { get; set; } = 0;
        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
