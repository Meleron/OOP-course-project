using OOPWinFroms.Cars;
using OOPWinFroms.Finances;
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
    public partial class WorkForm : Form
    {
        private ClientClass client;
        public WorkForm(ClientClass client)
        {
            this.client = client;
            InitializeComponent();
            Text = string.Format("User: " + client.FirstName);
            if (client.Status == 0)
                IsUser();
            else
                IsAdmin();
        }

        private void IsUser()
        {
            Height = 215;
            button4.Visible = false;
            button5.Visible = false;
        }

        private void IsAdmin()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AutoParkService.GetAvailableCars().Count == 0)
            {
                MessageBox.Show("No cars are available for renting now", "Autopark");
                return;
            }
            else
            {
                this.Hide();
                RentCarForm rc = new RentCarForm(client);
                rc.Closed += (s, args) => this.Show();
                rc.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<RentClass> rentsOfClient = RentService.GetRentsOfClient(client);
            if (rentsOfClient.Count == 0)
            {
                MessageBox.Show("You have no rents", "Autopark");
                return;
            }
            else
            {
                this.Hide();
                ReturnRentedCarForm rrc = new ReturnRentedCarForm(client);
                rrc.Closed += (s, args) => this.Show();
                rrc.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Good bye, " + client.FirstName, "Autopark");
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowCarsListForm scl = new ShowCarsListForm();
            scl.Closed += (s, args) => this.Show();
            scl.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowAllClients scl = new ShowAllClients(client);
            scl.Closed += (s, args) => this.Show();
            scl.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (TransactionService.Transactions.Count == 0)
            {
                MessageBox.Show("There are no transactions", "Autopark");
            }
            else
            {
                this.Hide();
                ShowAllTransactions str = new ShowAllTransactions();
                str.FormClosed += (s, args) => this.Show();
                str.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowRentsListForm srl = new ShowRentsListForm();
            srl.FormClosed += (s, args) => this.Show();
            srl.Show();
        }
    }
}
