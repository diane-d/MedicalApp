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

        public List<Patient> GetPatients()
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

        public Patient GetOnePatient(int id)
        {
            Patient retVal = new Patient();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryOne = "SELECT Id, FirstName, LastName, Email, PhoneNumber, DateOfBirth, Pathologies FROM dbo.Patients WHERE Id = @Id";

                using (var command = new SqlCommand(queryOne, sqlConnection))
                {
                    command.Parameters.Add (new SqlParameter("@Id", id));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        retVal = new Patient
                        {
                            Id = (int)reader[0],
                            FirstName = (string)reader[1],
                            LastName = (string)reader[2],
                            Email = (string)reader[3],
                            PhoneNumber = (string)reader[4],
                            DateOfBirth = (DateTime)reader[5],
                            Pathologies = (string)reader[6]

                        };
                    }
                    reader.Close();
                }
            }
            return retVal;
        }

        public bool CreatePatient(Patient patient)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryCreate = "INSERT INTO dbo.Patients (FirstName, LastName, Email, PhoneNumber, DateOfBirth, Pathologies) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @DateOfBirth, @Pathologies)";

                using (var command = new SqlCommand(queryCreate, sqlConnection))
                {
                    command.Parameters.Add(new SqlParameter("@FirstName", patient.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", patient.LastName));
                    command.Parameters.Add(new SqlParameter("@Email", patient.Email));
                    command.Parameters.Add(new SqlParameter("@PhoneNumber", patient.PhoneNumber));
                    command.Parameters.Add(new SqlParameter("@DateOfBirth", patient.DateOfBirth));
                    command.Parameters.Add(new SqlParameter("@Pathologies", patient.Pathologies));
                    
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool UpdatePatientPathologies(int id, string pathologies)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryUpdate = "UPDATE dbo.Patients SET Pathologies = @Pathologies WHERE Id = @Id";

                using (var command = new SqlCommand(queryUpdate, sqlConnection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.Parameters.Add(new SqlParameter("@Pathologies", pathologies));

                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool DeletePatient(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryDelete = "DELETE dbo.Patients WHERE Id = @Id";

                using (var command = new SqlCommand(queryDelete, sqlConnection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    return command.ExecuteNonQuery() == 1;
                }
            }
        }
    }
}

