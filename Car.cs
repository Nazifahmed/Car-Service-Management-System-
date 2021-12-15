using ClassLibrary4.OProduct;
using ClassLibrary4.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Service
{
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            EProduct eProduct = new EProduct();
            
            eProduct.Name = txtName.Text;
            eProduct.Code = txtcode.Text;
            eProduct.Type = txttype.Text;
            eProduct.LicenseNo = txtLicense.Text;

            OProduct oProduct = new OProduct();
            int number = oProduct.Insert(eProduct);

            if (number >= 0)
            {
                MessageBox.Show("Successfully inserted");
            }
            else
            {
                MessageBox.Show("Not inserted");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            OProduct oProduct = new OProduct();
            SqlDataAdapter sqlDataAdapter = oProduct.show();
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            OProduct oProduct = new OProduct();
            SqlDataAdapter sqlDataAdapter = oProduct.search(txtSearch.Text);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EProduct eProduct = new EProduct();
            eProduct.Code = txtcode.Text;

            OProduct oProduct = new OProduct();
            int id = oProduct.Delete(eProduct);
            if (id != 0)
            {
                MessageBox.Show("Successfully deleted");
            }
            else
            {
                MessageBox.Show("Please Enter Code");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EProduct eProduct = new EProduct();
            eProduct.Name = txtName.Text;
            eProduct.Code = txtcode.Text;
            eProduct.Type = txttype.Text;
            eProduct.LicenseNo = txtLicense.Text;
            

            OProduct oProduct = new OProduct();
            int id = oProduct.Update(eProduct);
            if (id != 0)
            {
                MessageBox.Show("Successfully updated");
            }
            else
            {
                MessageBox.Show("Please Enter Code");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Customer().Show();
        }
    }
}
