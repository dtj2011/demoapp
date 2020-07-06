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
                    string query = "Select * from Products";

                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                result += (reader.GetString(0) + " " + reader.GetString(1));
                            }
                        }
                    }
                    return result;
                }  
            }
            catch(SqlException se)
            {
                throw;
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
