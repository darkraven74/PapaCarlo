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
    public partial class EmployeesListForm : Form
    {
        public EmployeesListForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Employees;

            labelSearch.Text = Properties.Resources.Search;
            labelGroup.Text = Properties.Resources.Group;
            comboBoxGroups.DataSource = new List<String> { Properties.Resources.All,
                Properties.Resources.Storekeeper, Properties.Resources.Accountant, Properties.Resources.Chief };
            buttonCreate.Text = Properties.Resources.Create;
            buttonEdit.Text = Properties.Resources.Edit;


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = Properties.Resources.Surname;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.Name;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = Properties.Resources.Patronymic;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = Properties.Resources.Login;

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = Properties.Resources.Password;

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = Properties.Resources.Group;
            
            
            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);
            dataGridView1.Columns.Add(col5);


            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
            DataGridViewCell cel1 = new DataGridViewTextBoxCell();
            DataGridViewCell cel2 = new DataGridViewTextBoxCell();
            DataGridViewCell cel3 = new DataGridViewTextBoxCell();
            DataGridViewCell cel4 = new DataGridViewTextBoxCell();
            DataGridViewCell cel5 = new DataGridViewTextBoxCell();
            DataGridViewRow row = new DataGridViewRow();
            cel0.Value = "Иванов";
            cel1.Value = "Иван";
            cel2.Value = "Иванович";
            cel3.Value = "i.ivanov";
            cel4.Value = "pass";
            cel5.Value = Properties.Resources.Chief;
            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            cel2 = new DataGridViewTextBoxCell();
            cel3 = new DataGridViewTextBoxCell();
            cel4 = new DataGridViewTextBoxCell();
            cel5 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "Петров";
            cel1.Value = "Петр";
            cel2.Value = "Петрович";
            cel3.Value = "p.petrov";
            cel4.Value = "password";
            cel5.Value = Properties.Resources.Accountant;
            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            cel2 = new DataGridViewTextBoxCell();
            cel3 = new DataGridViewTextBoxCell();
            cel4 = new DataGridViewTextBoxCell();
            cel5 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "Примеров";
            cel1.Value = "Пример";
            cel2.Value = "Примерович";
            cel3.Value = "p.primerov";
            cel4.Value = "12345";
            cel5.Value = Properties.Resources.Storekeeper;
            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5);
            dataGridView1.Rows.Add(row);

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            EmployeeEditForm f = new EmployeeEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EmployeeEditForm f = new EmployeeEditForm();
            f.ShowDialog();
        }
    }
}
