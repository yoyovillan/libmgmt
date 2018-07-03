using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using LMS.BusinessLayer;
using LMS.DataAccessLayer;

namespace LMS
{
    public partial class LMSFLogin : Form
    {
        LMSDB LMSDB = new LMSDB();

        public LMSFLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LMSFLogin_Load(object sender, EventArgs e)
        {
            
            //Load UserList to cmbUser
            //LMSDB.ExcecuteQuery("Select User_Name,User_Password from LMSUser");
            
            try
            {
                LMSUserClass User = new LMSUserClass();
                User.LoadUsers();
                cmbUser.DisplayMember = "User_Name";
                cmbUser.ValueMember = "User_Name";
                cmbUser.DataSource = User.ODS.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error Loading Users...\n" + ex.Message.ToString());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BusinessLayer.LMSUserClass User = new LMSUserClass();
            
            try
            {
                User.CheckPwd(cmbUser.SelectedValue.ToString(), txtPassword.Text.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "LMS");
            }
            if (User.ValidLogin == true)
            {
            //    MessageBox.Show("Welcome to LMS");
                LMS.Presentation.LMSMainMdi Main = new Presentation.LMSMainMdi();
                Main.Show();
                this.Hide();
                /*
                LMS.Presentation.LMSMainMdi Sub = new Presentation.LMSMainMdi();
                LMSBookClass NN = new LMSBookClass();
                Block Statement;
                */
            }
                

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }
    }
}
