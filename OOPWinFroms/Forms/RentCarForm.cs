using OOPWinFroms.Cars;
using OOPWinFroms.People;
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
    public partial class RentCarForm : Form
    {
        ClientClass client;
        public RentCarForm(ClientClass client)
        {
            this.client = client;
            InitializeComponent();
            int lHeight = AutoParkService.GetAvailableCars().Count * 13 + 10;
            listBox1.DataSource = AutoParkService.GetAvailableCars();
            button1.Location = new Point(button1.Location.X, button1.Location.Y - (listBox1.Height - lHeight));
            listBox1.Height = lHeight;
            Height = lHeight + 150;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                RentService.AddNewRent(new RentClass(client, (CarClass)listBox1.SelectedItem));
                MessageBox.Show($"Car with id {((CarClass)listBox1.SelectedItem).CarId} was successfully rented", "Autopark");
                this.Close();
            }
        }
    }

}
