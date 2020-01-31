using MedicalApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.WebAPI.DTO
{
    public class MapDTO
    {
        public static PatientDTO MapPatientToDTO(Patient patient)
        {
            return new PatientDTO
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
                DateOfBirth = patient.DateOfBirth,
                Pathologies = patient.Pathologies
            };
        }

        public static PhysicianDTO MapPhysicianToDTO(Physician physician)
        {
            return new PhysicianDTO
            {
                Id = physician.Id,
                FirstName = physician.FirstName,
                LastName = physician.LastName,
                PhoneNumber = physician.PhoneNumber,
                Email = physician.Email
            };
        }

        public static ExaminationDTO MapExaminationToDTO(Examination examination)
        {
            return new ExaminationDTO
            {
                PatientId = examination.PatientId,
                PhysicianId = examination.PhysicianId,
                DateAndTime = examination.DateAndTime,
                Observations = examination.Observations
            };
        }
    }
}
