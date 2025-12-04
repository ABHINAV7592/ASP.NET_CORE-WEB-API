using System.Data;
using System.Data.SqlClient;

namespace core_webapi.Model
{
    public class EmployeeDB
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-USLUAF59\SQLEXPRESS;database=aspcore;integrated security=true");
        public string InsertDB(emp_table objcls)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empna", objcls.emp_name);
                cmd.Parameters.AddWithValue("@empaddr", objcls.emp_address);
                cmd.Parameters.AddWithValue("@empsal", objcls.emp_salary);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Inserted Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        public List<emp_table> selectDB()
        {
            var list = new List<emp_table>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_selectall", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var o = new emp_table
                    {
                        emp_id = Convert.ToInt32(sdr["emp_id"]),
                        emp_name = sdr["emp_name"].ToString(),
                        emp_address = sdr["emp_address"].ToString(),
                        emp_salary = sdr["emp_salary"].ToString()
                    };
                    list.Add(o);

                }
                con.Close();
                return list;
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;

            }
        }
        public string deleteDB(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("OK....");
            }
            catch(Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
        public string updateprofile(int id,emp_table objcls)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_profileupdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", objcls.emp_id);
                cmd.Parameters.AddWithValue("@esal", objcls.emp_salary);
                cmd.Parameters.AddWithValue("@eaddr", objcls.emp_address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Updated Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();

            }
        }
    }
}
