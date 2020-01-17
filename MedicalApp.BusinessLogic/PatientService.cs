using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using MedicalApp.EntityFramework;

namespace MedicalApp.BusinessLogic
{
    public class PatientService
    {
        const string ConnectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Medical;Integrated Security=true;";

        public List<Patient> GetPatient()
        {
            List<Patient> retVal = new List<Patient>();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryAll = "SELECT Id, FirstName, LastName, Email, PhoneNumber, DateOfBirth, Pathologies  FROM dbo.Patients";

                using (var command = new SqlCommand(queryAll, sqlConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var patient = new Patient
                        {
                            Id = (int)reader[0],
                            FirstName = (string)reader[1],
                            LastName = (string)reader[2],
                            Email = (string)reader[3],
                            PhoneNumber = (string)reader [4],
                            DateOfBirth = (DateTime)reader[5],
                            Pathologies = (string)reader[6]

                        };

                        retVal.Add(patient);
                    }

                    reader.Close();
                }
            }

            return retVal;
        }
    }
}

