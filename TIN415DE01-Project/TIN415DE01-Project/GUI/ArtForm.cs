using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TIN415DE01_Project.BLL;
using TIN415DE01_Project.DTO;
namespace TIN415DE01_Project.GUI
{
    public partial class ArtForm : Form
    {
        public ArtForm()
        {
            InitializeComponent();
        }

        private void ArtForm_Load(object sender, EventArgs e)
        {
            List<ArtItem> artItems = new ArtBUS().GetAll();
            dataGridView1.DataSource = artItems;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
        private void addButton_Click(object sender, EventArgs e)
        {
            String name = nameTextBox.Text.Trim();
            String category = categoryTextBox.Text.Trim();
            int price = int.Parse(priceTextBox.Text.Trim());
            String brand = brandTextBox.Text.Trim();
            ArtItem newArtItem = new ArtItem()
            {
                Code = 0,
                Name = name,
                Category = category,
                Price = price,
                Brand = brand
            };

            bool result = new ArtBUS().AddNewIntem(newArtItem);
            if (result)
            {
                MessageBox.Show("You have added a new art item to your database!!!");
                List<ArtItem> artItems = new ArtBUS().GetAll();
                dataGridView1.DataSource = artItems;
            }
            else
            {
                MessageBox.Show("Sorry, there is something wrong!!! Not successful!!!");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            String keyword = search.Text.Trim();
            List<ArtItem> artItems = new ArtBUS().Search(keyword);
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

            ArtItem updatedItem = new ArtItem()
            {
                Code = code,
                Name = name,
                Category = category,
                Price = price,
                Brand = brand,
            };
            //MessageBox.Show(updatedItem.Code.ToString());
            //MessageBox.Show(updatedItem.Name);

            bool result = new ArtBUS().UpdateItem(updatedItem);
            if (result)
            {
                MessageBox.Show("You have updated a art item to your database!!!");
                List<ArtItem> artItems = new ArtBUS().GetAll();
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

            string message = "Are you sure you want to delete this row?";
            string caption = "Delete Row";
            var res = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                MessageBox.Show("You have canceled!!!");
            }
            else //DialogResult.Yes
            {
                bool result = new ArtBUS().DeleteItem(code);
                if (result)
                {
                    MessageBox.Show("You have updated a art item to your database!!!");
                    List<ArtItem> artItems = new ArtBUS().GetAll();
                    dataGridView1.DataSource = artItems;
                }
                else
                {
                    MessageBox.Show("Sorry, there is something wrong!!! Not successful!!!");
                }
            }

        }

    }
}
