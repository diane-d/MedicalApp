using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.EntityFramework
{
    public class Examination
    {
        public int Id { get; set; }
        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; }
        public virtual Physician Physician { get; set; }
        public int PhysicianId { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Observations { get; set; }

        public Examination(int patientId, int physicianId, DateTime dateAndTime, string observations) { 
            PatientId = patientId;
            PhysicianId = physicianId;
            DateAndTime = dateAndTime;
            Observations = observations;
        }

        public Examination () { }
    }
}
