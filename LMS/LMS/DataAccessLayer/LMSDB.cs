using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace LMS.DataAccessLayer
{
    public class LMSDB
    {
        public SqlCommand OSC;
        public DataSet ODS = new DataSet();
        public static string SCS= System.Configuration.ConfigurationManager.ConnectionStrings["LMSDBConnectionString"].ConnectionString;
        public SqlConnection OCN = new SqlConnection(SCS);
        public SqlDataAdapter ODA;
    //    public SqlDataReader ODR;
        public DataTable ODT = new DataTable();

        public void OpenConnection()
        {
            try
            {
                OCN.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Connection Failed!! " + ex.Message.ToString() , "Class DB", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public void AddBook(int BookCode,string BookName, string BookAuthor, string BookPublisher, int BookPrice, string BookCategory,DateTime BookPuchaseDate)
        {
            try
            {
                OpenConnection();
                SqlCommand OSC = new SqlCommand("dbo.AddBook", OCN);
                OSC.CommandType = CommandType.StoredProcedure;
                OSC.Parameters.AddWithValue("@Book_Code", BookCode);
                OSC.Parameters.AddWithValue("@Book_Name", BookName);
                OSC.Parameters.AddWithValue("@Book_Author", BookAuthor);
                OSC.Parameters.AddWithValue("@Book_Publsiher", BookPublisher);
                OSC.Parameters.AddWithValue("@Book_Price", BookPrice);
                OSC.Parameters.AddWithValue("@Book_Category", BookCategory);
                OSC.Parameters.AddWithValue("@Book_PurchaseDate", BookPuchaseDate);
                OSC.ExecuteNonQuery();
                OCN.Close();
            }
            catch(Exception ex)
            {
                throw new Exception("Adding Book Error in Database");
            }
        }


        public void ExcecuteQuery(string strquery)
        {
            SqlCommand OSC = new SqlCommand(strquery, OCN);
            SqlDataAdapter ODA = new SqlDataAdapter(OSC);
            ODA.Fill(ODS);
            ODA.Fill(ODT);
            OCN.Close();

        }

        public void ExcecuteNonQuery(string strquery)
        {
            try
            {
                OCN.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Connection Failed!!", "Class DB", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            SqlCommand OSC = new SqlCommand(strquery, OCN);
            OSC.ExecuteNonQuery();
            OCN.Close();

        }

    }
}
