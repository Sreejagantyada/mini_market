using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mini_MarketManagement_System
{
    public partial class LoginForm : Form
    {
        DBConnect dBCon = new DBConnect();
        public static string sellerName;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Yellow;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox_password.Clear();
            textBox_username.Clear();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == "" || textBox_username.Text == "")
            {
                MessageBox.Show("Please Enter Username and Password", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (combobox_role.SelectedIndex > -1)
                {
                    if (combobox_role.SelectedItem.ToString() == "ADMIN")
                    {
                        if (textBox_username.Text == "Admin" && textBox_password.Text == "Admin123")
                        {
                            ProductForm productForm = new ProductForm();
                            productForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If you are Admin,Please Enter the correct Id and Password", "Miss Id", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        string SelectQuery = "SELECT * FROM Seller WHERE SellerName='" + textBox_username.Text + "'AND SellerPass='" + textBox_password.Text + "'";
                        SqlDataAdapter adapter = new SqlDataAdapter(SelectQuery,dBCon.GetCon());
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            sellerName = textBox_username.Text;
                            SellingForm selling = new SellingForm();
                            selling.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Role", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void combobox_role_MouseEnter(object sender, EventArgs e)
        {
            
        }
    }

}
