using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Service_ADO_database
{
    public class EmployeeOperation
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string connectionStr = "data source = (localdb)\\MSSQLLocalDB; initial catalog=EmployeeManagement;integrated security = true ";
            con = new SqlConnection(connectionStr);
        }
        //To Add Employee details    
        public bool AddEmployee(Employee obj)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("AddEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", obj.Name);
                com.Parameters.AddWithValue("@City", obj.City);
                com.Parameters.AddWithValue("@Address", obj.Address);
                con.Open();
                int i = com.ExecuteNonQuery(); //Execute and return the num of records added
                con.Close();
                if (i != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        //To Update Employee details    
        public bool UpdateEmployee(Employee obj)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("UpdateEmployee", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", obj.EmpId);
                com.Parameters.AddWithValue("@Name", obj.Name);
                com.Parameters.AddWithValue("@City", obj.City);
                com.Parameters.AddWithValue("@Address", obj.Address);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        //To view employee details with generic list     
        public List<Employee> GetAllEmployees()
        {
            try
            {
                connection();
                List<Employee> EmpList = new List<Employee>();


                SqlCommand com = new SqlCommand("GetAllEmployees", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {

                    EmpList.Add(

                        new Employee
                        {

                            EmpId = Convert.ToInt32(dr["Empld"]),
                            Name = Convert.ToString(dr["Name"]),
                            City = Convert.ToString(dr["City"]),
                            Address = Convert.ToString(dr["Address"])
                        }
                        );
                }

                return EmpList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public bool DeleteEmployee(int Id)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("DeleteEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void exuctedorNot(bool data)
        {
            if (data)
            {
                Console.WriteLine("Code executed");
                return;
            }
            Console.WriteLine("Something went wrong");
        }
        public void DisplayAllData()
        {
            try
            {
                // EmployeeOperation employeeDataAccess = new EmployeeOperation(); // Replace with your actual class name

                List<Employee> employees = GetAllEmployees();

                foreach (Employee data in employees)
                {
                    Console.WriteLine($"Emp: {data.EmpId}");
                    Console.WriteLine($"Name: {data.Name}");
                    Console.WriteLine($"City: {data.City}");
                    Console.WriteLine($"Address: {data.Address}");
                    Console.WriteLine("$$$");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


    }
}
