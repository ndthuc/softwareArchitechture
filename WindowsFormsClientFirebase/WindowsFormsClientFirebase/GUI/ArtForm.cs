using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsClientFirebase.BLL;
using WindowsFormsClientFirebase.DTO;

namespace WindowsFormsClientFirebase.GUI
{
    public partial class ArtForm : Form
    {
        public ArtForm()
        {
            InitializeComponent();
        }

        private void ArtForm_Load(object sender, EventArgs e)
        {
            new ArtBUS().ListenFirebase(dataGridView1);
        }

        private void dataGridView1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        //choose dataGridView1_CellClick_1 or dataGridView1_SelectionChanged to GetDetails

        //private async void dataGridView1_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count > 0)
        //    {
        //        int code = int.Parse(dataGridView1.SelectedRows[0].Cells["Code"].Value.ToString());
        //        //Book book = await new BookBUS1().GetDetails(code);
        //        ArtItem artItem = await new ArtBUS().GetDetails(code);
        //        if (artItem != null)
        //        {
        //            codeTextBox.Text = artItem.Code.ToString();
        //            nameTextBox.Text = artItem.Name.ToString();
        //            categoryTextBox.Text = artItem.Category.ToString();
        //            priceTextBox.Text = artItem.Price.ToString();
        //            brandTextBox.Text = artItem.Brand.ToString();
        //        }
        //    }
        //}

        private async void searchButton_Click(object sender, EventArgs e)
        {
            String keyword = label1.Text.Trim();
            //List<Book> books = await new BookBUS1().Search(keyword);
            List<ArtItem> books = await new ArtBUS().Search(keyword);
            dataGridView1.BeginInvoke(new MethodInvoker(delegate { dataGridView1.DataSource = books; })); // set asynchronous datasource
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            ArtItem newItem = new ArtItem()
            {
                Code = int.Parse(codeTextBox.Text.Trim()),
                Name = nameTextBox.Text.Trim(),
                Category = categoryTextBox.Text.Trim(),
                Price = int.Parse(priceTextBox.Text.Trim()),
                Brand = brandTextBox.Text.Trim()
            };
            //bool result = await new BookBUS1().AddNew(newBook);
            bool result = await new ArtBUS().AddNew(newItem);
            if (!result) MessageBox.Show("SORRY BABY !!!");
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            ArtItem updatedItem = new ArtItem()
            {
                Code = int.Parse(codeTextBox.Text.Trim()),
                Name = nameTextBox.Text.Trim(),
                Category = categoryTextBox.Text.Trim(),
                Price = int.Parse(priceTextBox.Text.Trim()),
                Brand = brandTextBox.Text.Trim()
            };
            //bool result = await new BookBUS1().Update(newBook);
            bool result = await new ArtBUS().Update(updatedItem);
            if (!result) MessageBox.Show("SORRY BABY !!!");
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE ?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int code = int.Parse(codeTextBox.Text);
                //bool result = await new BookBUS1().Delete(code);
                bool result = await new ArtBUS().Delete(code);
                if (!result) MessageBox.Show("SORRY BABY !!!");
            }
        }
    }
}
