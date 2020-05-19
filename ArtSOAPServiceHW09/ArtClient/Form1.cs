using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gearhost.ArtService service = new gearhost.ArtService();
            List<gearhost.Art_Materials_n_Tool> artItems = service.GetAll().ToList();
            dataGridView1.DataSource = artItems;
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            String name = nameTextBox.Text.Trim();
            String category = categoryTextBox.Text.Trim();
            int price = int.Parse(priceTextBox.Text.Trim());
            String brand = brandTextBox.Text.Trim();

            gearhost.ArtService service = new gearhost.ArtService();

            gearhost.Art_Materials_n_Tool newArtItem = new gearhost.Art_Materials_n_Tool()
            {
                Code = 0,
                Name = name,
                Category = category,
                Price = price,
                Brand = brand
            };

            bool result = service.AddNewIntem(newArtItem);
            if (result)
            {
                MessageBox.Show("You have added a new art item to your database!!!");
                List<gearhost.Art_Materials_n_Tool> artItems = service.GetAll().ToList();
                dataGridView1.DataSource = artItems;
            }
            else
            {
                MessageBox.Show("Sorry, there is something wrong!!! Not successful!!!");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            gearhost.ArtService service = new gearhost.ArtService();

            String keyword = search.Text.Trim();
            List<gearhost.Art_Materials_n_Tool> artItems = service.Search(keyword).ToList();
            dataGridView1.DataSource = artItems;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            int code = int.Parse(codeTextBox.Text);
            String name = nameTextBox.Text.Trim();
            String category = categoryTextBox.Text.Trim();
            int price = int.Parse(priceTextBox.Text.Trim());
            String brand = brandTextBox.Text.Trim();

            gearhost.ArtService service = new gearhost.ArtService();

            gearhost.Art_Materials_n_Tool updatedItem = new gearhost.Art_Materials_n_Tool()
            {
                Code = code,
                Name = name,
                Category = category,
                Price = price,
                Brand = brand,
            };
            //MessageBox.Show(updatedItem.Code.ToString());
            //MessageBox.Show(updatedItem.Name);

            bool result = service.UpdateItem(updatedItem);
            if (result)
            {
                MessageBox.Show("You have updated a art item to your database!!!");
                List<gearhost.Art_Materials_n_Tool> artItems = service.GetAll().ToList();
                dataGridView1.DataSource = artItems;
            }
            else
            {
                MessageBox.Show("Sorry, there is something wrong!!! Not successful!!!");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            int code = int.Parse(codeTextBox.Text);

            gearhost.ArtService service = new gearhost.ArtService();

            string message = "Are you sure you want to delete this row?";
            string caption = "Delete Row";
            var res = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                MessageBox.Show("You have canceled!!!");
            }
            else //DialogResult.Yes
            {
                bool result = service.DeleteItem(code);
                if (result)
                {
                    MessageBox.Show("You have deleted a art item from your database!!!");
                    List<gearhost.Art_Materials_n_Tool> artItems = service.GetAll().ToList();
                    dataGridView1.DataSource = artItems;
                }
                else
                {
                    MessageBox.Show("Sorry, there is something wrong!!! Not successful!!!");
                }
            }

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                codeTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells["Code"].FormattedValue.ToString();
                nameTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                categoryTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells["Category"].FormattedValue.ToString();
                priceTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
                brandTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells["Brand"].FormattedValue.ToString();
            }
        }
    }
}
