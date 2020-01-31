using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.BusinessLogic;
using MedicalApp.EntityFramework;
using MedicalApp.WebAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;
        
        public PatientController (PatientService patientService)
        { 
            _patientService = patientService; 
        }

        [Route("[action]")]
        [HttpGet]
        public List<PatientDTO> GetPatients()
        {
          return _patientService.GetPatients().Select(i => (MapDTO.MapPatientToDTO(i))).ToList();
        }

        [Route("[action]/{patientId}")]
        [HttpGet]
        public PatientDTO GetOnePatient(int patientId)
        {
            return MapDTO.MapPatientToDTO(_patientService.GetOnePatient(patientId));
        }

        [Route("[action]")]
        [HttpPost]
        public bool CreatePatient([FromBody] Patient patient)
        {
            return _patientService.CreatePatient(patient);
        }

        [Route("[action]/{patientId}")]
        [HttpPut]
        public bool UpdatePatientPathologies(int patientId, [FromBody] string pathologies)
        {
            return _patientService.UpdatePatientPathologies(patientId, pathologies);
        }

        [Route("[action]/{patientId}")]
        [HttpDelete]
        public bool DeletePatient(int patientId)
        {
            return _patientService.DeletePatient(patientId);
        }

        [Route("[action]/{patientId}")]
        [HttpGet]
        public List<ExaminationDTO> GetPatientExaminations(int patientId)
        {
            return _patientService.GetPatientExaminations(patientId).Select(i => (MapDTO.MapExaminationToDTO(i))).ToList();
        }
    }
}
