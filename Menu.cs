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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        

        

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            Items i = new Items();
            i.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
//            this.Hide();
            Checks c = new Checks("","");
            c.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DailyOperations D = new DailyOperations();
            D.Show();
        }
        
        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        

        
    }
}
