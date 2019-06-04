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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            //ClientService.AddNewClient(new ClientClass(487, 0, "Danik", "+1234567"));
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox2.ForeColor = Color.Black;
            if (textBox1.Text.Length < 3 || textBox1.Text.Length > 15)
            {
                textBox1.ForeColor = Color.Red;
                MessageBox.Show("Incorrect login length", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (textBox2.Text.Length < 3 || textBox2.Text.Length > 15)
                {
                    textBox2.ForeColor = Color.Red;
                    MessageBox.Show("Incorrect password length", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                    return;
                }
            }
            
            ClientClass client = SQLClients.GetInstance().Search(textBox1.Text);
            if(client != null)
            {
                if (textBox2.Text == SQLClients.GetInstance().GetPassword(textBox1.Text))
                {
                    if(client.Status == 2)
                    {
                        MessageBox.Show("Your account was banned!", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                        return;
                    }
                    this.Hide();
                    new WorkForm(client).Show();
                }
                else
                {
                    MessageBox.Show("Incorrect password", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Incorrect login", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
            }

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                button1_Click(sender, new EventArgs());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegistrationForm rf = new RegistrationForm();
            rf.FormClosed += (s, args) => this.Show();
            rf.Show();
        }
    }
}
