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
    public class PhysicianController : ControllerBase
    {
        private readonly PhysicianService _physicianService;

        public PhysicianController(PhysicianService physicianService)
        {
            _physicianService = physicianService;
        }

        [Route("[action]")]
        [HttpGet]
        public List<PhysicianDTO> GetPhysicians()
        {
            return _physicianService.GetPhysicians().Select(i => (MapDTO.MapPhysicianToDTO(i))).ToList();
        }

        [Route("[action]/{physicianId}")]
        [HttpGet]
        public PhysicianDTO GetOnePhysician(int physicianId)
        {
            return MapDTO.MapPhysicianToDTO(_physicianService.GetOnePhysician(physicianId));
        }

        [Route("[action]")]
        [HttpPost]
        public bool CreatePhysician([FromBody] Physician physician)
        {
            return _physicianService.CreatePhysician(physician);
        }

        [Route("[action]/{physicianId}")]
        [HttpDelete]
        public bool DeletePhysician(int physicianId)
        {
            return _physicianService.DeletePhysician(physicianId);
        }
    }
}
