using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.EntityFramework
{
    public class Examination
    {
        public int Id { get; private set; }
        public virtual Patient Patient { get; private set; }
        public int PatientId { get; private set; }
        public virtual Physician Physician { get; private set; }
        public int PhysicianId { get; private set; }
        public DateTime DateAndTime { get; private set; }
        public string Observations { get; private set; }

        public Examination(int patientId, int physicianId, DateTime dateAndTime, string observations) { 
            PatientId = patientId;
            PhysicianId = physicianId;
            DateAndTime = dateAndTime;
            Observations = observations;

        }

    }
}
