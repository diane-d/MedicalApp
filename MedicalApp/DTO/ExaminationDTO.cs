using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.WebAPI.DTO
{
    public class ExaminationDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int PhysicianId { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Observations { get; set; }
    }
}
