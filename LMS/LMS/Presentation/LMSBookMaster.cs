using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMS.BusinessLayer;

namespace LMS.Presentation
{
    public partial class LMSBookMaster : Form
    {
        public LMSBookMaster()
        {
            InitializeComponent();
        }
        
        private void LMSBookMaster_Load(object sender, EventArgs e)
        {
            LMSCategoryClass Category = new LMSCategoryClass();
            LMSBookClass Book = new LMSBookClass();
            Category.LoadCategory();
            cmbBookCategory.DisplayMember = "Category";
            cmbBookCategory.ValueMember = "Category";
            cmbBookCategory.DataSource = Category.ODS.Tables[0];

            // Update Grid
            Book.LoadBooks();
            grdBook.DataSource = Book.ODS.Tables[0]; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add New Book

            
            try
            {
                LMSBookClass Book = new LMSBookClass();
                Book.AddBook(Convert.ToInt16(txtBookCode.Text),
                                            txtBookName.Text,
                                            txtBookAuthor.Text,
                                            txtBookPublisher.Text,
                                            Convert.ToInt16(txtBookPrice.Text),
                                            cmbBookCategory.Text.ToString(),                                            
                                            DateTime.Now);
                Book.LoadBooks();

                grdBook.DataSource = Book.ODS.Tables[0];
                    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
}
