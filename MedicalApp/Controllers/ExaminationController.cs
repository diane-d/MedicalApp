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
    public class ExaminationController : ControllerBase
    {
        private readonly ExaminationService _examinationService;
        
        public ExaminationController (ExaminationService examinationService)
        { 
            _examinationService = examinationService; 
        }

        [Route("[action]")]
        [HttpGet]
        public List<ExaminationDTO> GetExaminations()
        {
          return _examinationService.GetExaminations().Select(i => (MapDTO.MapExaminationToDTO(i))).ToList();
        }

        [Route("[action]/{examinationId}")]
        [HttpGet]
        public ExaminationDTO GetOneExamination(int examinationId)
        {
            return MapDTO.MapExaminationToDTO(_examinationService.GetOneExamination(examinationId));
        }

        [Route("[action]")]
        [HttpPost]
        public bool CreateExamination([FromBody] Examination examination)
        {
            return _examinationService.CreateExamination(examination);
        }

        [Route("[action]/{examinationId}")]
        [HttpDelete]
        public bool DeleteExamination(int examinationId)
        {
            return _examinationService.DeleteExamination(examinationId);
        }

        [Route("[action]/{patientId}")]
        [HttpGet]
        public List<ExaminationDTO> GetPatientExaminations(int patientId)
        {
            return _examinationService.GetPatientExaminations(patientId).Select(i => (MapDTO.MapExaminationToDTO(i))).ToList();
        }
    }
}
