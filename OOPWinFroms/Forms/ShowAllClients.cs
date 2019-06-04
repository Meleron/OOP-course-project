using OOPWinFroms.Database;
using OOPWinFroms.People;
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
    public partial class ShowAllClients : Form
    {
        public ShowAllClients(ClientClass client)
        {
            InitializeComponent();
            int formHeight = ClientService.GetAllClients().Count * 13 + 10;
            listBox1.DataSource = ClientService.GetAllClients();
            button1.Location = new Point(button1.Location.X, button1.Location.Y - (listBox1.Height - formHeight));
            button2.Location = new Point(button2.Location.X, button2.Location.Y - (listBox1.Height - formHeight));
            button3.Location = new Point(button3.Location.X, button3.Location.Y - (listBox1.Height - formHeight));
            listBox1.Height = formHeight;
            Height = formHeight + 130;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientClass selectedClient = (ClientClass)listBox1.SelectedItem;
            string info = string.Format($"Id: {selectedClient.ClientId}" + Environment.NewLine + 
                $"Status: {(selectedClient.Status == 0 ? "User" : selectedClient.Status == 1 ? "Admin" : selectedClient.Status == 2 ? "Banned" : "Undefined")}" + Environment.NewLine + 
                $"First name: {selectedClient.FirstName}" + Environment.NewLine + 
                $"Second name: {selectedClient.SecondName}" + Environment.NewLine + 
                $"Patronymic: {selectedClient.Patronymic}" + Environment.NewLine +
                $"Address: {selectedClient.Address}" + Environment.NewLine + 
                $"Phone number: {selectedClient.PhoneNumber}");
            MessageBox.Show(info, "Autopark");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientClass selectedClient = (ClientClass)listBox1.SelectedItem;
            if (selectedClient.Status == 0)
            {
                selectedClient.Status = 2;
                MessageBox.Show($"'{selectedClient.FirstName}' with id '{selectedClient.ClientId}' was successfully banned", "Autopark", new MessageBoxButtons(), MessageBoxIcon.Asterisk);
            }
            else if(selectedClient.Status == 1)
            {
                MessageBox.Show("Unable to ban administrator", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }
            else if (selectedClient.Status == 2)
            {
                selectedClient.Status = 0;
                MessageBox.Show($"'{selectedClient.FirstName}' with id '{selectedClient.ClientId}' was successfully unbanned", "Autopark", new MessageBoxButtons(), MessageBoxIcon.Asterisk);
            }
            try
            {
                SQLClients.GetInstance().Update(selectedClient);
            }
            catch (Exception excp) { Console.WriteLine(excp.Message); }
            listBox1_SelectedIndexChanged(sender, new EventArgs());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((ClientClass)listBox1.SelectedItem).Status != 2)
            {
                button3.Text = "Ban";
            } else
            {
                button3.Text = "Unban";
            }
        }
    }
}
