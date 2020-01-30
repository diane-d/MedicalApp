using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using MedicalApp.EntityFramework;
using System.Linq;

namespace MedicalApp.BusinessLogic
{
    public class PhysicianService
    {
        const string ConnectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Medical;Integrated Security=true;";

        public List<Physician> GetPhysicians()
        {
            List<Physician> retVal = new List<Physician>();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryAll = "SELECT Id, FirstName, LastName, Email, PhoneNumber FROM dbo.Physicians";

                using (var command = new SqlCommand(queryAll, sqlConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var physician = new Physician
                        {
                            Id = (int)reader[0],
                            FirstName = (string)reader[1],
                            LastName = (string)reader[2],
                            Email = (string)reader[3],
                            PhoneNumber = (string)reader[4]

                        };

                        retVal.Add(physician);
                    }

                    reader.Close();
                }
            }

            return retVal;
        }

        public Physician GetOnePhysician(int id)
        {
            Physician retVal = new Physician();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryOne = "SELECT Id, FirstName, LastName, Email, PhoneNumber FROM dbo.Physicians WHERE Id = @Id";

                using (var command = new SqlCommand(queryOne, sqlConnection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        retVal = new Physician
                        {
                            Id = (int)reader[0],
                            FirstName = (string)reader[1],
                            LastName = (string)reader[2],
                            Email = (string)reader[3],
                            PhoneNumber = (string)reader[4]

                        };
                    }
                    reader.Close();
                }
            }
            return retVal;
        }

        public bool CreatePhysician(Physician physician)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryCreate = "INSERT INTO dbo.Physicians (FirstName, LastName, Email, PhoneNumber) VALUES (@FirstName, @LastName, @Email, @PhoneNumber)";

                using (var command = new SqlCommand(queryCreate, sqlConnection))
                {
                    command.Parameters.Add(new SqlParameter("@FirstName", physician.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", physician.LastName));
                    command.Parameters.Add(new SqlParameter("@Email", physician.Email));
                    command.Parameters.Add(new SqlParameter("@PhoneNumber", physician.PhoneNumber));

                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool DeletePhysician(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string queryDelete = "DELETE dbo.Physicians WHERE Id = @Id";

                using (var command = new SqlCommand(queryDelete, sqlConnection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    return command.ExecuteNonQuery() == 1;
                }
            }
        }
    }
}
