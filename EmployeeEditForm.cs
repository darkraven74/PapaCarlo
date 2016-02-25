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
    public partial class EmployeeEditForm : Form
    {
        public EmployeeEditForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Employee;
            label1.Text = Properties.Resources.Surname;
            label2.Text = Properties.Resources.Name;
            label3.Text = Properties.Resources.Patronymic;
            label4.Text = Properties.Resources.Login;
            label5.Text = Properties.Resources.Password;
            label6.Text = Properties.Resources.Group;
            
            comboBox1.DataSource = new List<String> { Properties.Resources.Storekeeper,
                Properties.Resources.Accountant, Properties.Resources.Chief };

            buttonCancel.Text = Properties.Resources.Cancel;
            buttonOK.Text = Properties.Resources.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
