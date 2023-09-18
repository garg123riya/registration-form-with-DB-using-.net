using DataModels;
using project;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DataService
    {
        private readonly string connectionString;
        public DataService()
        {
            connectionString = SqlHelper.GetConnectionString();
        }

        public UserRegistrationDetails SaveUser(UserRegistrationDetails user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO [dbo].[StudentData]([StudentName],[StudentEmail],[StudentEducation],[Password],[ImageName],[ImagePath]) VALUES(@StudentName , @StudentEmail , @StudentEducation , @Password , @ImageName, @ImagePath)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@StudentName", user.Name);
                cmd.Parameters.AddWithValue("@StudentEmail", user.Email);
                cmd.Parameters.AddWithValue("@StudentEducation", user.Edu);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@ImageName", user.ImageName);
                cmd.Parameters.AddWithValue("@ImagePath", user.ImagePath);

                var r = cmd.ExecuteNonQuery();
            }

            return user;
        }
    }
}
