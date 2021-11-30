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
    public partial class CategoryForm : Form
    {
        DBConnect dBCon = new DBConnect(); 
        public CategoryForm()
        {
            InitializeComponent();
        }
        private void getTable()
        {
            string selectQuerry = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(selectQuerry,dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_category.DataSource = table;
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO Category VALUES(" + textBox_id.Text + ",'" + textBox_name.Text + "','" + textBox_description.Text + "')";
                SqlCommand command = new SqlCommand(insertQuery,dBCon.GetCon());
                dBCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("category added successfully","Add Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dBCon.CloseCon();
                getTable();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            getTable();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_id.Text == "" || textBox_name.Text == "" || textBox_description.Text == "") 
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    string updateQuery = "UPDATE Category SET CatName'" + textBox_name.Text + "',CatDes='" + textBox_description.Text + "' WHERE CatId='"+textBox_id.Text + "' ";     
                    SqlCommand command = new SqlCommand(updateQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("category updated successfully", "update information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBCon.CloseCon();
                    getTable();
                    clear();              

                }
            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }



        private void label_exit_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DataGridView_category_Click(object sender, EventArgs e)
        {
            textBox_id.Text =DataGridView_category.SelectedRows[0].Cells[0].Value.ToString();
            textBox_name.Text = DataGridView_category.SelectedRows[0].Cells[1].Value.ToString();
            textBox_description.Text = DataGridView_category.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void clear()
        {
            textBox_id.Clear();
            textBox_name.Clear();
            textBox_description.Clear();
        }

        private void DataGridView_category_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "DELETE FROM Category WHERE CatId=" + textBox_id.Text + "";
                 SqlCommand command = new SqlCommand(deleteQuery, dBCon.GetCon());
                dBCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("category deleted successfully", "delete information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dBCon.CloseCon();
                getTable();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label_logout_MouseHover(object sender, EventArgs e)
        {
            label_logout.ForeColor = System.Drawing.Color.Tomato;
        }

        private void label_logout_MouseLeave(object sender, EventArgs e)
        {
            label_logout.ForeColor=Color.DimGray;
        }

        private void label_logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void button_product_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SellerForm seller = new SellerForm();
            seller.Show();
            this.Hide();
        }
    }
}
