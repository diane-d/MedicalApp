using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using MedicalApp.EntityFramework;
using System.Linq;

namespace MedicalApp.BusinessLogic
{
    public class ExaminationService
    {
        const string ConnectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Medical;Integrated Security=true;";

        public List<Examination> GetExaminations()
        {
            List<Examination> retVal = new List<Examination>();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryAll = "SELECT Id, PatientId, PhysicianId, DateAndTime, Observations FROM dbo.Examinations";

                using (var command = new SqlCommand(queryAll, sqlConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var examination = new Examination
                        {
                            Id = (int)reader[0],
                            PatientId = (int)reader[1],
                            PhysicianId = (int)reader[2],
                            DateAndTime = (DateTime)reader[3],
                            Observations = (string)reader[4]

                        };

                        retVal.Add(examination);
                    }

                    reader.Close();
                }
            }

            return retVal;
        }

        public Examination GetOneExamination(int id)
        {
            Examination retVal = new Examination();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryOne = "SELECT Id, PatientId, PhysicianId, DateAndTime, Observations FROM dbo.Examinations WHERE Id = @Id";

                using (var command = new SqlCommand(queryOne, sqlConnection))
                {
                    command.Parameters.Add (new SqlParameter("@Id", id));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        retVal = new Examination
                        {
                            Id = (int)reader[0],
                            PatientId = (int)reader[1],
                            PhysicianId = (int)reader[2],
                            DateAndTime = (DateTime)reader[3],
                            Observations = (string)reader[4]
                        };
                    }
                    reader.Close();
                }
            }
            return retVal;
        }

        public bool CreateExamination(Examination examination)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryCreate = "INSERT INTO dbo.Examinations (PatientId, PhysicianId, DateAndTime, Observations) VALUES (@PatientId, @PhysicianId, @DateAndTime, @Observations)";

                using (var command = new SqlCommand(queryCreate, sqlConnection))
                {
                    command.Parameters.Add(new SqlParameter("@PatientId", examination.PatientId));
                    command.Parameters.Add(new SqlParameter("@PhysicianId", examination.PhysicianId));
                    command.Parameters.Add(new SqlParameter("@DateAndTime", examination.DateAndTime));
                    command.Parameters.Add(new SqlParameter("@Observations", examination.Observations));

                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool DeleteExamination(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryDelete = "DELETE dbo.Examinations WHERE Id = @Id";

                using (var command = new SqlCommand(queryDelete, sqlConnection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public List<Examination> GetPatientExaminations(int id)
        {
            List<Examination> retVal = new List<Examination>();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryGetExaminations = "SELECT Id, PatientId, PhysicianId, DateAndTime, Observations FROM dbo.Examinations WHERE PatientId = @Id";

                using (var command = new SqlCommand(queryGetExaminations, sqlConnection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var examination = new Examination
                        {
                            Id = (int)reader[0],
                            PatientId = (int)reader[1],
                            PhysicianId = (int)reader[2],
                            DateAndTime = (DateTime)reader[3],
                            Observations = (string)reader[4]
                        };

                        retVal.Add(examination);
                    }

                    reader.Close();
                }
            }

            return retVal;
        }
    }
}
