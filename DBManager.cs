using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptionn
{
   static class DBManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                "Initial Catalog = Login;" +
                "integrated Security= true;";
        internal static bool Check(string usera, string passw)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand();
                //associo connessione
                command.Connection = connection;
                //definisco il tipo input
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM dbo.LoginTable ";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string user = (string)reader[1];
                    string pass = (string)reader[2];
                    if (user == usera && pass == passw)
                        return true;
                }
                connection.Close();
            }
            return false;
        }
        internal static void Login(string userName, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                //associo connessione
                command.Connection = connection;
                //definisco il tipo input
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.LoginTable values (@username, @password)";
                try
                {
                    if (!Check(userName, password))
                    {
                        command.Parameters.AddWithValue("@username", userName);
                        command.Parameters.AddWithValue("@password", password);
                        command.ExecuteNonQuery();
                       
                        Console.WriteLine("Custumer Registered");
                      
                    }
                  else
                    {
                        throw new Exception("You are already registered");
                       
                    }
                   
                }
                catch(Exception e) 
                {
                    Console.WriteLine(e.Message);
                  
                }
                 
                connection.Close();
            }
        }
    }
}
