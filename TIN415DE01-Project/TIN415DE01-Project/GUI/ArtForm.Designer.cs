namespace TIN415DE01_Project.GUI
{
    partial class ArtForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.brandTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.artBrand = new System.Windows.Forms.Label();
            this.artPrice = new System.Windows.Forms.Label();
            this.artCategory = new System.Windows.Forms.Label();
            this.artName = new System.Windows.Forms.Label();
            this.artCode = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.keyword = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.updateButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.brandTextBox);
            this.groupBox1.Controls.Add(this.priceTextBox);
            this.groupBox1.Controls.Add(this.categoryTextBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.codeTextBox);
            this.groupBox1.Controls.Add(this.artBrand);
            this.groupBox1.Controls.Add(this.artPrice);
            this.groupBox1.Controls.Add(this.artCategory);
            this.groupBox1.Controls.Add(this.artName);
            this.groupBox1.Controls.Add(this.artCode);
            this.groupBox1.Location = new System.Drawing.Point(29, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 196);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(486, 144);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(91, 37);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(486, 90);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(91, 39);
            this.updateButton.TabIndex = 11;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(486, 33);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(91, 39);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // brandTextBox
            // 
            this.brandTextBox.Location = new System.Drawing.Point(86, 161);
            this.brandTextBox.Name = "brandTextBox";
            this.brandTextBox.Size = new System.Drawing.Size(378, 20);
            this.brandTextBox.TabIndex = 9;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(86, 129);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(378, 20);
            this.priceTextBox.TabIndex = 8;
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(86, 97);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(378, 20);
            this.categoryTextBox.TabIndex = 7;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(86, 66);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(378, 20);
            this.nameTextBox.TabIndex = 6;
            // 
            // codeTextBox
            // 
            this.codeTextBox.Enabled = false;
            this.codeTextBox.Location = new System.Drawing.Point(86, 34);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(378, 20);
            this.codeTextBox.TabIndex = 5;
            // 
            // artBrand
            // 
            this.artBrand.AutoSize = true;
            this.artBrand.Location = new System.Drawing.Point(15, 161);
            this.artBrand.Name = "artBrand";
            this.artBrand.Size = new System.Drawing.Size(35, 13);
            this.artBrand.TabIndex = 4;
            this.artBrand.Text = "Brand";
            // 
            // artPrice
            // 
            this.artPrice.AutoSize = true;
            this.artPrice.Location = new System.Drawing.Point(15, 129);
            this.artPrice.Name = "artPrice";
            this.artPrice.Size = new System.Drawing.Size(31, 13);
            this.artPrice.TabIndex = 3;
            this.artPrice.Text = "Price";
            // 
            // artCategory
            // 
            this.artCategory.AutoSize = true;
            this.artCategory.Location = new System.Drawing.Point(15, 100);
            this.artCategory.Name = "artCategory";
            this.artCategory.Size = new System.Drawing.Size(49, 13);
            this.artCategory.TabIndex = 2;
            this.artCategory.Text = "Category";
            // 
            // artName
            // 
            this.artName.AutoSize = true;
            this.artName.Location = new System.Drawing.Point(15, 66);
            this.artName.Name = "artName";
            this.artName.Size = new System.Drawing.Size(35, 13);
            this.artName.TabIndex = 1;
            this.artName.Text = "Name";
            // 
            // artCode
            // 
            this.artCode.AutoSize = true;
            this.artCode.Location = new System.Drawing.Point(15, 34);
            this.artCode.Name = "artCode";
            this.artCode.Size = new System.Drawing.Size(32, 13);
            this.artCode.TabIndex = 0;
            this.artCode.Text = "Code";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.searchButton);
            this.groupBox2.Controls.Add(this.search);
            this.groupBox2.Controls.Add(this.keyword);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(29, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(597, 214);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Art Materials and Tools";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(486, 22);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(91, 37);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(86, 30);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(378, 20);
            this.search.TabIndex = 2;
            // 
            // keyword
            // 
            this.keyword.AutoSize = true;
            this.keyword.Location = new System.Drawing.Point(15, 33);
            this.keyword.Name = "keyword";
            this.keyword.Size = new System.Drawing.Size(48, 13);
            this.keyword.TabIndex = 1;
            this.keyword.Text = "Keyword";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(562, 133);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ArtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 473);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ArtForm";
            this.Text = "ArtForm";
            this.Load += new System.EventHandler(this.ArtForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label artBrand;
        private System.Windows.Forms.Label artPrice;
        private System.Windows.Forms.Label artCategory;
        private System.Windows.Forms.Label artName;
        private System.Windows.Forms.Label artCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Label keyword;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox brandTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox codeTextBox;
    }
}