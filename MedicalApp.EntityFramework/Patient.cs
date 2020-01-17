using System;

namespace MedicalApp.EntityFramework
{
    public class Patient
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Pathologies { get; private set; }

    }
}
