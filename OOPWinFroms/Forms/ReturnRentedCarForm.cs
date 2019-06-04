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
    public partial class ReturnRentedCarForm : Form
    {

        ClientClass client;

        public ReturnRentedCarForm(ClientClass client)
        {
            this.client = client;
            InitializeComponent();
            int lHeight = RentService.GetRentsOfClient(client).Count * 13 + 10;
            listBox1.DataSource = RentService.GetRentsOfClient(client);
            button1.Location = new Point(button1.Location.X, button1.Location.Y - (listBox1.Height - lHeight));
            listBox1.Height = lHeight;
            Height = lHeight + 150;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                RentClass rent = RentService.GetRentByCarId(((RentClass)listBox1.SelectedItem).CurrentCar.CarId);
                RentService.RemoveRent(RentService.GetRentByCarId(((RentClass)listBox1.SelectedItem).CurrentCar.CarId));
                MessageBox.Show(string.Format($"Car with id {((RentClass)listBox1.SelectedItem).CurrentCar.CarId} was successfully returned"));
                this.Close();
                return;
            }
        }
    }
}
