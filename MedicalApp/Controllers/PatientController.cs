using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.BusinessLogic;
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
        { _patientService = patientService; }

        [Route("/Patient/List")]
        [HttpGet]
        public List<PatientDTO> ListPatient()
        {
          

          return  _patientService.GetPatient().Select(i => (MapDTO.MapPatientToDTO(i))).ToList();



        }

      
    }
}
   