namespace Brada3
{
    partial class Table_Choose
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
            this.listBox_Shlal = new System.Windows.Forms.ListBox();
            this.Listbox_Sea = new System.Windows.Forms.ListBox();
            this.ListBox_Restaurant = new System.Windows.Forms.ListBox();
            this.ListBox_Coffee = new System.Windows.Forms.ListBox();
            this.Lbl_Coffee = new System.Windows.Forms.Label();
            this.Lbl_Restaurant = new System.Windows.Forms.Label();
            this.Lbl_Shlal = new System.Windows.Forms.Label();
            this.Lbl_Sea = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox_Shlal
            // 
            this.listBox_Shlal.BackColor = System.Drawing.SystemColors.InfoText;
            this.listBox_Shlal.ForeColor = System.Drawing.SystemColors.Window;
            this.listBox_Shlal.FormattingEnabled = true;
            this.listBox_Shlal.Location = new System.Drawing.Point(22, 25);
            this.listBox_Shlal.Name = "listBox_Shlal";
            this.listBox_Shlal.Size = new System.Drawing.Size(66, 95);
            this.listBox_Shlal.TabIndex = 0;
            this.listBox_Shlal.Click += new System.EventHandler(this.listBox_Shlal_Click);
            this.listBox_Shlal.SelectedIndexChanged += new System.EventHandler(this.listBox_Shlal_SelectedIndexChanged);
            // 
            // Listbox_Sea
            // 
            this.Listbox_Sea.FormattingEnabled = true;
            this.Listbox_Sea.Location = new System.Drawing.Point(22, 154);
            this.Listbox_Sea.Name = "Listbox_Sea";
            this.Listbox_Sea.Size = new System.Drawing.Size(66, 95);
            this.Listbox_Sea.TabIndex = 1;
            this.Listbox_Sea.Click += new System.EventHandler(this.Listbox_Sea_Click);
            this.Listbox_Sea.SelectedIndexChanged += new System.EventHandler(this.Listbox_Sea_SelectedIndexChanged);
            // 
            // ListBox_Restaurant
            // 
            this.ListBox_Restaurant.BackColor = System.Drawing.SystemColors.InfoText;
            this.ListBox_Restaurant.ForeColor = System.Drawing.SystemColors.Window;
            this.ListBox_Restaurant.FormattingEnabled = true;
            this.ListBox_Restaurant.Location = new System.Drawing.Point(205, 154);
            this.ListBox_Restaurant.Name = "ListBox_Restaurant";
            this.ListBox_Restaurant.Size = new System.Drawing.Size(66, 95);
            this.ListBox_Restaurant.TabIndex = 2;
            this.ListBox_Restaurant.Click += new System.EventHandler(this.ListBox_Restaurant_Click);
            this.ListBox_Restaurant.SelectedIndexChanged += new System.EventHandler(this.ListBox_Restaurant_SelectedIndexChanged);
            // 
            // ListBox_Coffee
            // 
            this.ListBox_Coffee.FormattingEnabled = true;
            this.ListBox_Coffee.Location = new System.Drawing.Point(205, 40);
            this.ListBox_Coffee.Name = "ListBox_Coffee";
            this.ListBox_Coffee.Size = new System.Drawing.Size(66, 95);
            this.ListBox_Coffee.TabIndex = 3;
            this.ListBox_Coffee.Click += new System.EventHandler(this.ListBox_Coffee_Click);
            this.ListBox_Coffee.SelectedIndexChanged += new System.EventHandler(this.ListBox_Coffee_SelectedIndexChanged);
            // 
            // Lbl_Coffee
            // 
            this.Lbl_Coffee.AutoSize = true;
            this.Lbl_Coffee.Location = new System.Drawing.Point(205, 13);
            this.Lbl_Coffee.Name = "Lbl_Coffee";
            this.Lbl_Coffee.Size = new System.Drawing.Size(37, 13);
            this.Lbl_Coffee.TabIndex = 4;
            this.Lbl_Coffee.Text = "الكافيه";
            // 
            // Lbl_Restaurant
            // 
            this.Lbl_Restaurant.AutoSize = true;
            this.Lbl_Restaurant.Location = new System.Drawing.Point(217, 138);
            this.Lbl_Restaurant.Name = "Lbl_Restaurant";
            this.Lbl_Restaurant.Size = new System.Drawing.Size(42, 13);
            this.Lbl_Restaurant.TabIndex = 5;
            this.Lbl_Restaurant.Text = "المطعم";
            // 
            // Lbl_Shlal
            // 
            this.Lbl_Shlal.AutoSize = true;
            this.Lbl_Shlal.Location = new System.Drawing.Point(38, 9);
            this.Lbl_Shlal.Name = "Lbl_Shlal";
            this.Lbl_Shlal.Size = new System.Drawing.Size(40, 13);
            this.Lbl_Shlal.TabIndex = 6;
            this.Lbl_Shlal.Text = "الشلال";
            // 
            // Lbl_Sea
            // 
            this.Lbl_Sea.AutoSize = true;
            this.Lbl_Sea.Location = new System.Drawing.Point(53, 132);
            this.Lbl_Sea.Name = "Lbl_Sea";
            this.Lbl_Sea.Size = new System.Drawing.Size(29, 13);
            this.Lbl_Sea.TabIndex = 7;
            this.Lbl_Sea.Text = "البحر";
            // 
            // Table_Choose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(351, 274);
            this.Controls.Add(this.Lbl_Sea);
            this.Controls.Add(this.Lbl_Shlal);
            this.Controls.Add(this.Lbl_Restaurant);
            this.Controls.Add(this.Lbl_Coffee);
            this.Controls.Add(this.ListBox_Coffee);
            this.Controls.Add(this.ListBox_Restaurant);
            this.Controls.Add(this.Listbox_Sea);
            this.Controls.Add(this.listBox_Shlal);
            this.Name = "Table_Choose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Table_Choose";
            this.Load += new System.EventHandler(this.Table_Choose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Shlal;
        private System.Windows.Forms.ListBox Listbox_Sea;
        private System.Windows.Forms.ListBox ListBox_Restaurant;
        private System.Windows.Forms.ListBox ListBox_Coffee;
        private System.Windows.Forms.Label Lbl_Coffee;
        private System.Windows.Forms.Label Lbl_Restaurant;
        private System.Windows.Forms.Label Lbl_Shlal;
        private System.Windows.Forms.Label Lbl_Sea;
    }
}