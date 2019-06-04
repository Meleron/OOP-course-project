using OOPWinFroms.Renting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPWinFroms.Forms
{
    public partial class ShowRentsListForm : Form
    {
        public ShowRentsListForm()
        {
            InitializeComponent();
            listBox1.DataSource = RentService.Rent;
            int formHeight = RentService.Rent.Count * 13 + 10;
            button1.Location = new Point(button1.Location.X, button1.Location.Y - (listBox1.Height - formHeight));
            listBox1.Height = formHeight > 300 ? 300 : formHeight;
            formHeight += 150;
            Height = formHeight > 400 ? 400 : formHeight;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
