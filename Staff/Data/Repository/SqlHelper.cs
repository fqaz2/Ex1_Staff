using Staff.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Data.Repository
{
    class SqlHelper
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        internal static List<Employee> GetStuff()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    List<Employee> staff = new List<Employee>();
                    connection.Open();
                    string sqlExpression = "SELECT * FROM Staff";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) 
                    {
                        while (reader.Read()) 
                        {
                            staff.Add
                                (new Employee()
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    MidleName = reader.GetString(2),
                                    LastName = reader.GetString(3),
                                    Position = reader.GetString(4),
                                    DateOfBirth = reader.GetDateTime(5),
                                    Salary = reader.GetDecimal(6)
                                });
                        }
                    }
                    return staff;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        internal static void DeleteEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    List<Employee> staff = new List<Employee>();
                    connection.Open();
                    string sqlExpression = $"DELETE FROM Staff WHERE id = {employee.Id};";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        internal static void AddEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    List<Employee> staff = new List<Employee>();
                    connection.Open();
                    string sqlExpression = "INSERT INTO Staff ([First Name],[Midle name],[Last name],Position,DateOfBirth,Salary)VALUES(" +
                        $"'{employee.FirstName}', " +
                        $"'{employee.MidleName}', " +
                        $"'{employee.LastName}', " +
                        $"'{employee.Position}', " +
                        $"'{employee.DateOfBirth}', " +
                        $"'{employee.Salary}')";//выглядит страшно
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
