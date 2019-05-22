using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Brada3
{
    public partial class Table_Choose : Form
    {
        //BradaDataContext Brada = new BradaDataContext();
        BradaDataClassesDataContext Brada = new BradaDataClassesDataContext();

        public Table_Choose()
        {
            InitializeComponent();
        }

        

        private void Table_Choose_Load(object sender, EventArgs e)
        {
            var shalal = Brada.TBL_Numbers.Where(s => s.TBLPlace_ID == 2).Select(s =>s.Numbers);
            listBox_Shlal.DataSource = shalal;

            var Sea = Brada.TBL_Numbers.Where(s => s.TBLPlace_ID == 3).Select(s => s.Numbers).ToList();
            Listbox_Sea.DataSource = Sea;

            var Restaurant= Brada.TBL_Numbers.Where(s => s.TBLPlace_ID == 4).Select(s => s.Numbers).ToList();
            ListBox_Restaurant.DataSource = Restaurant;

            var Coffee = Brada.TBL_Numbers.Where(s => s.TBLPlace_ID == 5).Select(s => s.Numbers).ToList();
            ListBox_Coffee.DataSource = Coffee;
           

           
        }

        private void ListBox_Coffee_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.Hide();
            //Checks c = new Checks(ListBox_Coffee.SelectedItem.ToString(),Lbl_Coffee.Text);
            //c.Show();
        }

        private void ListBox_Restaurant_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.Hide();
            //Checks c = new Checks(ListBox_Restaurant.SelectedItem.ToString(),Lbl_Restaurant.Text);
            //c.Show();
        }

        private void Listbox_Sea_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.Hide();
            //Checks c = new Checks(Listbox_Sea.SelectedItem.ToString(),Lbl_Sea.Text);
            //c.Show();
        }

        private void listBox_Shlal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.Hide();
            //Checks c = new Checks(listBox_Shlal.SelectedItem.ToString(),Lbl_Shlal.Text);
            //c.Show();
        }

        private void ListBox_Coffee_Click(object sender, EventArgs e)
        {
            this.Hide();
            Checks c = new Checks(ListBox_Coffee.SelectedItem.ToString(), Lbl_Coffee.Text);
            c.Show();
        }

        private void ListBox_Restaurant_Click(object sender, EventArgs e)
        {
            this.Hide();
            Checks c = new Checks(ListBox_Restaurant.SelectedItem.ToString(), Lbl_Restaurant.Text);
            c.Show();
        }

        private void Listbox_Sea_Click(object sender, EventArgs e)
        {
            this.Hide();
            //var x = listBox_Shlal.SelectedIndex;
            //var name=Brada.TBL_Numbers.Where(s=>s.TBL_ID)
            Checks c = new Checks(Listbox_Sea.SelectedItem.ToString(), Lbl_Sea.Text);
            c.Show();
        }

        private void listBox_Shlal_Click(object sender, EventArgs e)
        {
            this.Hide();
            Checks c = new Checks(listBox_Shlal.SelectedItem.ToString(), Lbl_Shlal.Text);
            c.Show();
        }
    }
}
