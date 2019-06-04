using OOPWinFroms.Cars;
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
    public partial class ShowCarsListForm : Form
    {
        public ShowCarsListForm()
        {
            InitializeComponent();
            int formHeight = AutoParkService.GetAllCars().Count * 13 + 10;
            listBox1.DataSource = AutoParkService.GetAllCars();
            button1.Location = new Point(button1.Location.X, button1.Location.Y - (listBox1.Height - formHeight));
            listBox1.Height = formHeight;
            Height = formHeight + 130;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
