using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using LMS.DataAccessLayer;

namespace LMS.BusinessLayer
{
    class LMSCategoryClass
    {
        public LMSDB LMSDB = new LMSDB();
        public DataSet ODS = new DataSet();
        private string category;

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }

        }
        public void LoadCategory()
        {
            LMSDB.OpenConnection();
            string query = "Select Category from LMSCategory";
            SqlCommand OSC = new SqlCommand(query, LMSDB.OCN);
            //OSC.CommandText = query;
            SqlDataAdapter ODA = new SqlDataAdapter(OSC);
            //SqlDataReader ODR = OSC.ExecuteReader();

            SqlDataAdapter OSDD = new SqlDataAdapter();


            ODA.Fill(ODS);
        }
    }
}
