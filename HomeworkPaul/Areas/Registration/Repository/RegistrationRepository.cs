using System;
using System.Data;
using System.Data.SqlClient;
using HomeworkPaul.Areas.Registration.Models;

namespace HomeworkPaul.Areas.Registration.Repository
{
    //TODO: need a facade class to wrap repo and hashing
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly string _connectionString;

        public RegistrationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int CreateUser(RegistrationDetails registrationDetails)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("InsertUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 255).Value =
                        registrationDetails.FirstName ?? string.Empty;

                    command.Parameters.Add("@Surname", SqlDbType.NVarChar, 255).Value =
                        registrationDetails.Surname ?? string.Empty;

                    command.Parameters.Add("@Email", SqlDbType.VarChar, 320).Value =
                        registrationDetails.Email;

                    command.Parameters.Add("@PasswordHash", SqlDbType.VarChar, 255).Value =
                        registrationDetails.Password;

                    connection.Open();
                    var result = command.ExecuteNonQuery();

                    return result;
                }
            }
        }

        public bool DoesEmailAlreadyExist(string emailAddress)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("DoesEmailAddressExist", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Email", SqlDbType.VarChar, 320).Value = emailAddress;
                    connection.Open();
                    var result = command.ExecuteScalar();

                    if (result == null)
                    {
                        return false;
                    }

                    if (result is DBNull)
                    {
                        return false;
                    }

                    // at least one row; first cell was non-null
                    int status = (int) result;
                    return status == 1;
                }
            }
        }
    }
}