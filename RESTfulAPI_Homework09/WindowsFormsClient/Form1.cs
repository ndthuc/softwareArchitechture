using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using WindowsFormsClient.DTO;
using Newtonsoft.Json;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string domain = "http://tin415de01.gear.host/";

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            String res = client.DownloadString(domain + "api/arts");
            List<ArtItem> artItems = JsonConvert.DeserializeObject<List<ArtItem>>(res);
            dataGridView1.DataSource = artItems;
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            ArtItem newItem = new ArtItem
            {
                Code = 0,
                Name = nameTextBox.Text.Trim(),
                Category = categoryTextBox.Text.Trim(),
                Price = Int32.Parse(priceTextBox.Text.Trim()),
                Brand = brandTextBox.Text.Trim()
            };

            String data = JsonConvert.SerializeObject(newItem);

            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String res = client.UploadString(domain + "api/arts", "POST", data);
            if (res != null)
            {
                String res2 = client.DownloadString(domain + "api/arts");
                List<ArtItem> artItems = JsonConvert.DeserializeObject<List<ArtItem>>(res2);
                MessageBox.Show("Add Successful!!!");
                dataGridView1.DataSource = artItems;
            }
            else
            {
                MessageBox.Show("Add Fail!!!");
            }
        }


        private void updateButton_Click(object sender, EventArgs e)
        {
            int code = Int32.Parse(codeTextBox.Text);
            ArtItem updatedItem = new ArtItem
            {
                Code = code,
                Name = nameTextBox.Text.Trim(),
                Category = categoryTextBox.Text.Trim(),
                Price = Int32.Parse(priceTextBox.Text.Trim()),
                Brand = brandTextBox.Text.Trim()
            };

            String data = JsonConvert.SerializeObject(updatedItem);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String res = client.UploadString(domain + "api/arts/" + code, "PUT", data);
            if (res != null)
            {
                String res2 = client.DownloadString(domain + "api/arts");
                List<ArtItem> artItems = JsonConvert.DeserializeObject<List<ArtItem>>(res2);
                MessageBox.Show("Update Successful!!!");
                dataGridView1.DataSource = artItems;
            }
            else
            {
                MessageBox.Show("Update Fail!!!");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int code = Int32.Parse(codeTextBox.Text);

            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String message = "Are you sure you want to delete this row?";
            String caption = "Delete Row";
            var confirm = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No)
            {
                MessageBox.Show("You have canceled!!!");
            }
            else
            {
                String res = client.UploadString(domain + "api/arts/" + code, "DELETE", String.Empty);
                if (res != null)
                {
                    String res2 = client.DownloadString(domain + "api/arts");
                    List<ArtItem> artItems = JsonConvert.DeserializeObject<List<ArtItem>>(res2);
                    MessageBox.Show("Delete Successful!!!");
                    dataGridView1.DataSource = artItems;
                }
                else
                {
                    MessageBox.Show("Delete Fail!!!");
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            String keyword = search.Text.Trim();
            String res = "";
            WebClient client = new WebClient();
            if (keyword.Length > 0)
            {
                res = client.DownloadString(domain + "api/arts/search/" + keyword);
            }
            else
            {
                res = client.DownloadString(domain + "api/arts");
            }

            List<ArtItem> artItems = JsonConvert.DeserializeObject<List<ArtItem>>(res);
            dataGridView1.DataSource = artItems;
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
