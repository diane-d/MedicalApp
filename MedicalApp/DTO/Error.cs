using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.WebAPI.DTO
{
    public class Error
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
    }
}
