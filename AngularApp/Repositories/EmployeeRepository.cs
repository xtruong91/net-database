using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AngularApp.Models;
using Microsoft.Extensions.Configuration;

namespace AngularApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string connectionString;
        public EmployeeRepository(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@City", employee.City);

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", id);

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    con.Close();
                }
                return 1;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                List<Employee> lstemployee = new List<Employee>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeID"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.City = rdr["City"].ToString();
                        lstemployee.Add(employee);
                    }
                    con.Close();
                }
                return lstemployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<City>> GetCities()
        {
            try
            {
                List<City> lstCity = new List<City>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetCityList", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                    while (rdr.Read())
                    {
                        City city = new City();

                        city.CityId = Convert.ToInt32(rdr["CityID"]);
                        city.CityName = rdr["CityName"].ToString();
                        lstCity.Add(city);
                    }
                    con.Close();
                }
                return lstCity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Employee> GetEmployeeData(int id)
        {
            try
            {
                Employee employee = new Employee();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                    while (rdr.Read())
                    {
                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeID"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.City = rdr["City"].ToString();
                    }
                }
                return employee;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@City", employee.City);

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
