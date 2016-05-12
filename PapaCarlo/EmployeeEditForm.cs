using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PapaCarloDBApp;
using System.Collections;

namespace PapaCarlo
{
    public partial class EmployeeEditForm : Form
    {
        QueryEmployee queryEmpl;
        Employee emplForUpdate;
        bool forUpdate = false;
        EmployeesListForm instance;

        public EmployeeEditForm(EmployeesListForm instance, Employee emplForUpdate)
            : this(instance)
        {
            this.emplForUpdate = emplForUpdate;
            this.forUpdate = true;
            addDataForUpdate();
        }

        public EmployeeEditForm(EmployeesListForm instance)
        {
            this.instance = instance;
            
            InitializeComponent();

            queryEmpl = new QueryEmployee();

            this.Text = Properties.Resources.Employee;
            label1.Text = Properties.Resources.Surname;
            label2.Text = Properties.Resources.Name;
            label3.Text = Properties.Resources.Patronymic;
            label4.Text = Properties.Resources.Login;
            label5.Text = Properties.Resources.Password;
            label6.Text = Properties.Resources.Group;

            ArrayList lObj = new ArrayList();

            foreach (var item in queryEmpl.querySelectPositions())
            {
                lObj.Add(new { Id = item.Id, PositionName = item.Name });
            }

            comboBox1.DataSource = lObj;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "PositionName";

            
            buttonOk.Text = Properties.Resources.Cancel;
            buttonCancel.Text = Properties.Resources.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
           
            this.Dispose();
        }

        private void addDataForUpdate()
        {
            textBox1.Text=emplForUpdate.Surname;
            textBox2.Text=emplForUpdate.Name;
            textBox3.Text = emplForUpdate.Patronymic;
            textBox4.Text = emplForUpdate.Login;
            textBox5.Text = emplForUpdate.Password;
            comboBox1.SelectedIndex=emplForUpdate.PositionId-1;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Surname = textBox1.Text;
            emp.Name = textBox2.Text;
            emp.Patronymic = textBox3.Text;
            emp.Login = textBox4.Text;
            emp.Password = textBox5.Text;
            emp.PositionId = (int)comboBox1.SelectedValue;
            if (!forUpdate)
            {
               queryEmpl.queryAddEmployee(emp);
            }
            else
            {
                emp.Id = emplForUpdate.Id;
              queryEmpl.queryUpdateEmployee(emp);
            }

            instance.refreshGrid();
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
