using MedicalApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.WebAPI.DTO
{
    public  class MapDTO
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
    }
}
