using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TIN415DE01_HomeworkW04_3tiers_3layers.BLL;
using TIN415DE01_HomeworkW04_3tiers_3layers.DTO;

namespace TIN415DE01_HomeworkW04_3tiers_3layers
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Art_Materials_n_Tool> artItems = new ArtBUS().GetAll();
                GridView1.DataSource = artItems;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            codeTextBox.Text = GridView1.SelectedRow.Cells[1].Text;
            nameTextBox.Text = GridView1.SelectedRow.Cells[2].Text;
            categoryTextBox.Text = GridView1.SelectedRow.Cells[3].Text;
            priceTextBox.Text = GridView1.SelectedRow.Cells[4].Text;
            brandTextBox.Text = GridView1.SelectedRow.Cells[5].Text;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            String keyword = keywordTextBox.Text.Trim();
            List<Art_Materials_n_Tool> artItems = new ArtBUS().Search(keyword);
            GridView1.DataSource = artItems;
            GridView1.DataBind();
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            String name = nameTextBox.Text.Trim();
            String category = categoryTextBox.Text.Trim();
            int price = Int32.Parse(priceTextBox.Text.Trim());
            string brand = brandTextBox.Text.Trim();

            Art_Materials_n_Tool newArtItem = new Art_Materials_n_Tool()
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
                List<Art_Materials_n_Tool> artItems = new ArtBUS().GetAll();
                GridView1.DataSource = artItems;
                GridView1.DataBind();
            }
            else
            {
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            int code = Int32.Parse(codeTextBox.Text);
            String name = nameTextBox.Text.Trim();
            String category = categoryTextBox.Text.Trim();
            int price = Int32.Parse(priceTextBox.Text.Trim());
            string brand = brandTextBox.Text.Trim();

            Art_Materials_n_Tool updatedArtItem = new Art_Materials_n_Tool()
            {
                Code = code,
                Name = name,
                Category = category,
                Price = price,
                Brand = brand
            };

            bool result = new ArtBUS().UpdateItem(updatedArtItem);

            if (result)
            {
                List<Art_Materials_n_Tool> artItems = new ArtBUS().GetAll();
                GridView1.DataSource = artItems;
                GridView1.DataBind();
            }
            else
            {
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            int code = Int32.Parse(codeTextBox.Text);
            bool result = new ArtBUS().DeleteItem(code);

            if (result)
            {
                List<Art_Materials_n_Tool> artItems = new ArtBUS().GetAll();
                GridView1.DataSource = artItems;
                GridView1.DataBind();
            }
            else
            {
            }
        }
    }
}