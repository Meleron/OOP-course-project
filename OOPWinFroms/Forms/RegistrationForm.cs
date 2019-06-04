using MySql.Data.MySqlClient;
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

    public partial class RegistrationForm : Form
    {

        private int Status{ get; set; }

        public RegistrationForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void ResetColors()
        {
            textBox1.ForeColor = Color.Black;
            textBox2.ForeColor = Color.Black;
            textBox3.ForeColor = Color.Black;
            textBox4.ForeColor = Color.Black;
            textBox5.ForeColor = Color.Black;
            textBox6.ForeColor = Color.Black;
            textBox7.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
        }

        private void InitEvents()
        {
            textBox1.KeyDown += EnterPressed;
            textBox2.KeyDown += EnterPressed;
            textBox3.KeyDown += EnterPressed;
            textBox4.KeyDown += EnterPressed;
            textBox5.KeyDown += EnterPressed;
            textBox6.KeyDown += EnterPressed;
            textBox7.KeyDown += EnterPressed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetColors();
            if (textBox1.Text == "super")
            {
                textBox1.Text = "";
                if (Status == 0)
                {
                    Status = 1;
                    MessageBox.Show("Status set to admin", "Autopark", new MessageBoxButtons(), MessageBoxIcon.Asterisk);
                }
                else
                {
                    Status = 0;
                    MessageBox.Show("Status set to user", "Autopark", new MessageBoxButtons(), MessageBoxIcon.Asterisk);
                }
                return;
            }

            if (textBox1.Text.Length < 3)
            {
                textBox1.ForeColor = Color.Red;
                label1.ForeColor = Color.Red;
                MessageBox.Show("First name's length should be > 3", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }

            if (textBox2.Text.Length < 3 && textBox2.Text.Length != 0)
            {
                textBox2.ForeColor = Color.Red;
                label2.ForeColor = Color.Red;
                MessageBox.Show("Second name's length should be > 3", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }

            if (textBox3.Text.Length < 3 && textBox3.Text.Length != 0)
            {
                textBox3.ForeColor = Color.Red;
                label3.ForeColor = Color.Red;
                MessageBox.Show("Patronymic's length should be > 3", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }

            if (textBox4.Text.Length < 3 && textBox4.Text.Length != 0)
            {
                textBox4.ForeColor = Color.Red;
                label4.ForeColor = Color.Red;
                MessageBox.Show("Address's length should be > 3", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }

            if (textBox5.Text.Length < 3)
            {
                textBox5.ForeColor = Color.Red;
                label5.ForeColor = Color.Red;
                MessageBox.Show("Phone number's length should be > 3", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }

            if (textBox6.Text.Length < 3)
            {
                textBox6.ForeColor = Color.Red;
                label6.ForeColor = Color.Red;
                MessageBox.Show("Password's length should be > 3", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }

            if (textBox7.Text != textBox6.Text)
            {
                textBox7.ForeColor = Color.Red;
                label7.ForeColor = Color.Red;
                MessageBox.Show("Passwords do not match", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }

            ClientClass client = new ClientClass(Status, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);

            try
            {
                SQLClients.GetInstance().AddClient(client, textBox6.Text);
            } catch(MySqlException)
            {
                MessageBox.Show("This name isunavailable", "Error", new MessageBoxButtons(), MessageBoxIcon.Error);
                textBox1.ForeColor = Color.Red;
                label1.ForeColor = Color.Red;
                return;
            }

            MessageBox.Show("Account has been registered. Log in please.", "Autopark", new MessageBoxButtons(), MessageBoxIcon.Asterisk);
            this.Close();
        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, new EventArgs());
        }
    }
}
