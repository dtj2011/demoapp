using System;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DataAccess : IDataAccess
    {
        public string GetAll()
        {
            try
            {
                string result = String.Empty;

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "demodb.c5sypl65zyci.us-east-2.rds.amazonaws.com"; 
                builder.UserID = "admin";            
                builder.Password = "Password1";     
                builder.InitialCatalog = "demoappdb";    

                using(SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string query = "Select * from demoUsers";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                int userid = Convert.ToInt32(reader["User_id"]);
                                string firstname = Convert.ToString(reader["User_firstname"]);
                                string lastname = Convert.ToString(reader["User_Lastname"]);
                                string email = Convert.ToString(reader["User_Email"]);
                                string phone = Convert.ToString(reader["User_Phone"]);
                                result += $"\n {userid} {firstname} {lastname} {email} {phone}";
                            }
                        }
                    }
                    return result;
                }  
            }
            catch(SqlException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
