using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.EntityFramework
{
    public class Physician
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
    }
}
