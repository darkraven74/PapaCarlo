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
    public partial class EmployeesListForm : Form
    {
        DataGridViewCell cel00; 
        DataGridViewCell cel0;
        DataGridViewCell cel1;
        DataGridViewCell cel2;
        DataGridViewCell cel3;
        DataGridViewCell cel4;
        DataGridViewCell cel5;
        DataGridViewCell cel6;
        DataGridViewRow row;

        QueryEmployee queryEmpl;

        public EmployeesListForm()
        {
            InitializeComponent();

            queryEmpl = new QueryEmployee();

            this.Text = Properties.Resources.Employees;

            labelSearch.Text = Properties.Resources.Search;
            labelGroup.Text = Properties.Resources.Group;

            ArrayList lObj = new ArrayList();

            lObj.Add(new {Id = 0, PositionName = Properties.Resources.All});
            foreach (var item in queryEmpl.querySelectPositions())
            {
                lObj.Add(new {Id = item.Id, PositionName = item.Name} );
            }
            
            comboBoxGroups.DataSource = lObj;
            comboBoxGroups.ValueMember = "Id";
            comboBoxGroups.DisplayMember = "PositionName";

            buttonCreate.Text = Properties.Resources.Create;
            buttonEdit.Text = Properties.Resources.Edit;
            button1.Text = Properties.Resources.Delete;
            button2.Text = Properties.Resources.Refresh;


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewTextBoxColumn col00 = new DataGridViewTextBoxColumn();
            col00.HeaderText = Properties.Resources.ID; 
            
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

            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "";

            dataGridView1.Columns.Add(col00);
            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);
            dataGridView1.Columns.Add(col5);
            dataGridView1.Columns.Add(col6);
            dataGridView1.Columns[7].Visible = false;
            addGridView(queryEmpl.querySelectEmployees());


        }

        private void addGridView(List<EmployeeTable> et)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in et)
            {
                cel00 = new DataGridViewTextBoxCell(); 
                cel0 = new DataGridViewTextBoxCell();
                cel1 = new DataGridViewTextBoxCell();
                cel2 = new DataGridViewTextBoxCell();
                cel3 = new DataGridViewTextBoxCell();
                cel4 = new DataGridViewTextBoxCell();
                cel5 = new DataGridViewTextBoxCell();
                cel6 = new DataGridViewTextBoxCell();
                row = new DataGridViewRow();
                cel00.Value = item.employee.Id;
                cel0.Value = item.employee.Surname;
                cel1.Value = item.employee.Name;
                cel2.Value = item.employee.Patronymic;
                cel3.Value = item.employee.Login;
                cel4.Value = item.employee.Password;
                cel5.Value = item.position.Name;
                cel6.Value = item.position.Id;
                row.Cells.AddRange(cel00, cel0, cel1, cel2, cel3, cel4, cel5, cel6);
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            EmployeeEditForm f = new EmployeeEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Employee empl = new Employee();
          
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;

            empl.Id = (int)dataGridView1.Rows[selectedIndex].Cells[0].Value;
            empl.Surname=(string)dataGridView1.Rows[selectedIndex].Cells[1].Value;
            empl.Name = (string)dataGridView1.Rows[selectedIndex].Cells[2].Value;
            empl.Patronymic= (string)dataGridView1.Rows[selectedIndex].Cells[3].Value;
            empl.Login= (string)dataGridView1.Rows[selectedIndex].Cells[4].Value;
            empl.Password = (string)dataGridView1.Rows[selectedIndex].Cells[5].Value;
            empl.PositionId = (int)dataGridView1.Rows[selectedIndex].Cells[7].Value;

            EmployeeEditForm f = new EmployeeEditForm(empl);
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, EventArgs e)
        {
        }

        private void comboBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            addGridView(queryEmpl.querySelectEmployees((int)comboBoxGroups.SelectedValue));
           
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            MessageBox.Show(queryEmpl.queryDeleteEmployee((int)dataGridView1.Rows[selectedIndex].Cells[0].Value)+"");
            addGridView(queryEmpl.querySelectEmployees());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addGridView(queryEmpl.querySelectEmployees());
        }
    }
}
