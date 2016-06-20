using System;
using System.Data;
using System.Data.SqlClient;

namespace Wellizon
{
    class DAOCustomer
    {
        SqlConnection con = new SqlConnection("server=DungTA;database=CustomerDB;uid=sa;pwd=123456");
        
        public DataTable getData()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From CustomerDetails", con);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        public int Insert(CustomerInfo cusInfo)
        {
            try
            {
                SqlCommand comd = new SqlCommand();
                comd.Connection = con;
                comd.CommandText = "Insert Into CustomerDetails Values(@CustName, @CustAge, @CustAddress, @CustEMail, @Problem, @Status, @Date, @DateSolved)";
                comd.Parameters.AddWithValue("@CustName", cusInfo.CustName);
                comd.Parameters.AddWithValue("@CustAge", cusInfo.CustAge);
                comd.Parameters.AddWithValue("@CustAddress", cusInfo.CustAddress);
                comd.Parameters.AddWithValue("@CustEMail", cusInfo.CustEMail);
                comd.Parameters.AddWithValue("@Problem", cusInfo.Problem);
                comd.Parameters.AddWithValue("@Status", cusInfo.Status);
                comd.Parameters.AddWithValue("@Date", cusInfo.Date);
                comd.Parameters.AddWithValue("@DateSolved", cusInfo.DateSolved);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                return comd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
        public int Update(CustomerInfo cusInfo)
        {
            try
            {
                SqlCommand comd = new SqlCommand();
                comd.Connection = con;
                comd.CommandText = "Update CustomerDetails"
                + " Set CustName = @CustName, CustAge = @CustAge, CustAddress = @CustAddress, CustEMail = @CustEMail,"
                + " Problem = @Problem, Status = @Status, Date = @Date, DateSolved = @DateSolved"
                +" Where CustomerID = @CustomerID";
                comd.Parameters.AddWithValue("@CustomerID", cusInfo.CustomerID);
                comd.Parameters.AddWithValue("@CustName", cusInfo.CustName);
                comd.Parameters.AddWithValue("@CustAge", cusInfo.CustAge);
                comd.Parameters.AddWithValue("@CustAddress", cusInfo.CustAddress);
                comd.Parameters.AddWithValue("@CustEMail", cusInfo.CustEMail);
                comd.Parameters.AddWithValue("@Problem", cusInfo.Problem);
                comd.Parameters.AddWithValue("@Status", cusInfo.Status);
                comd.Parameters.AddWithValue("@Date", cusInfo.Date);
                comd.Parameters.AddWithValue("@DateSolved", cusInfo.DateSolved);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                return comd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
        public int Delete(int CustomerID)
        {
            try
            {
                SqlCommand comd = new SqlCommand();
                comd.Connection = con;
                comd.CommandText = "Delete From CustomerDetails Where CustomerID = @CustID";
                comd.Parameters.AddWithValue("@CustID", CustomerID);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                return comd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
            
        }
    }
}
