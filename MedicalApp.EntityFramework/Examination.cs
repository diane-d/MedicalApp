using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.EntityFramework
{
    class Examination
    {
        public int Id { get; private set; }
        public Patient Patient { get; private set; }
        public Physician Physician { get; private set; }
        public DateTime DateAndTime { get; private set; }
        public string Observations { get; private set; }
    }
}
