using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Model
{
    public class Hospital
    {
        [Key]
        public Guid HospitalId { get; set; }
        public string Name { get; set; }
      

    }
}
