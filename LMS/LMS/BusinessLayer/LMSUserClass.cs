using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LMS.DataAccessLayer;
using LMS.Presentation;
using System.Data;
namespace LMS.BusinessLayer
{
    class LMSUserClass
    {
        DataAccessLayer.LMSDB LMSDB = new LMSDB();
        public bool ValidLogin;
        private string _userName = "";
        //public SqlDataReader ODR;
        public DataSet ODS = new DataSet();
        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _password = "";
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        

        
        



        public void LoadUsers()
        {
            LMSDB.OpenConnection();
            string query = "Select User_Name,User_Password from LMSUser";
            SqlCommand OSC = new SqlCommand(query, LMSDB.OCN);
            OSC.CommandText = query;
            SqlDataAdapter ODA = new SqlDataAdapter(OSC);
            //SqlDataReader ODR = OSC.ExecuteReader();

            ODA.Fill(ODS);


        }
        public void CheckPwd(string user, string pass)
        {
            _userName = user;
            _password = pass;
            if (_password == "")
            {
                throw new Exception("Please Enter Password");
            }
            else
            {

                LMSDB.ExcecuteQuery("Select * from LMSUser where User_Name='" + _userName.ToString() + "' AND User_Password='" + _password.ToString() + "'");
                if (LMSDB.ODT.Rows.Count == 1)
                {
                    ValidLogin = true;
                    LMSDB.ODT.Clear();
                    LMSDB.ODS.Clear();
                }
                else
                {
                    throw new Exception("Incorrect Password!!");
                    ValidLogin = false;
                }
            }


        }


    }
}
