using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LMS.DataAccessLayer;
using System.Data.SqlClient;


namespace LMS.BusinessLayer
{
    class LMSBookClass
    {
        public LMSDB LMSDB = new LMSDB();
        public DataSet ODS = new DataSet();

        

        public int _BookCode { get; set; }
        public string _BookName { get; set; }
        public string _BookAuthor { get; set; }
        public int _BookPrice { get; set; }
        public DateTime _BookPurchaseDate { get; set; }
        public DateTime _BookIssueDate { get; set; }
        public int _BookStudentCode { get; set; }
        public bool _BookPresent { get; set; }
        public string _BookCategory { get; set; }
        public string _BookPublisher { get; set; }


        public void LoadBooks()
        {
            LMSDB.OpenConnection();
            string query = "SELECT [Book_Code],[Book_Name],[Book_Author],[Book_Publisher],[Book_Price],[Book_Category],[Book_PurchaseDate],[Book_IssueDate],[Book_StudentCode],[Book_Present]From [dbo].[LMSBook]";
            SqlCommand OSC = new SqlCommand(query, LMSDB.OCN);
            //OSC.CommandText = query;
            SqlDataAdapter ODA = new SqlDataAdapter(OSC);
            //SqlDataReader ODR = OSC.ExecuteReader();

            ODA.Fill(ODS);
            LMSDB.OCN.Close();
        }

        public void AddBook(int BookCode, string BookName, string BookAuthor, string BookPublisher, int BookPrice, string BookCategory, DateTime BookPuchaseDate)
        {
            if (BookCode.ToString() == "")
                throw new Exception("BookCode Field is Required");
            else if(BookName.Trim().ToString() == "")
                throw new Exception("BookName is Required");
            else
            {
                LMSDB.AddBook(BookCode, BookName, BookAuthor, BookPublisher, BookPrice, BookCategory, BookPuchaseDate);
            }
            
            
        }

        
    

    }

}
