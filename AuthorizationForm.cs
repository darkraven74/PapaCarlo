using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapaCarlo
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Authorization;
            labelLogin.Text = Properties.Resources.Login;
            labelPassword.Text = Properties.Resources.Password;
            labelGroup.Text = Properties.Resources.Group;
            textBoxLogin.Text = "login";
            textBoxPassword.Text = "password";
            textBoxPassword.UseSystemPasswordChar = true;
            buttonEnter.Text = Properties.Resources.Enter;
            comboBox1.DataSource = new List<String> { Properties.Resources.Storekeeper,
                Properties.Resources.Accountant, Properties.Resources.Chief };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
