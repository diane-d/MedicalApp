using System;

namespace MedicalApp.EntityFramework
{
    public class Patient
    {
        public int Id { get;  set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Pathologies { get; set; }

        public Patient(string firstName, string lastName, string phoneNumber,string email, DateTime dateOfBirth, string pathologies) 
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            DateOfBirth = dateOfBirth;
            Pathologies = pathologies;
        }

    }
}
