using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.WebAPI.DTO
{
    public class Result<T>
    {
        public Error Error { get; set; }
        public T Value { get; set; }
       
    }
}

