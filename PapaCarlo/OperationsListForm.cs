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

namespace PapaCarlo
{
    public partial class OperationsListForm : Form
    {
        QueryContractTechOperations query;

        DataGridViewCell cel0;
        DataGridViewCell cel1;
        DataGridViewCell cel2;
        DataGridViewCell cel3;
        DataGridViewRow row;

        private OperationsListForm getInstance()
        {
            return this;
        }

        public OperationsListForm()
        {
            InitializeComponent();

            query = new QueryContractTechOperations();

            this.Text = Properties.Resources.Operations;

            labelSearch.Text = Properties.Resources.Search;
            labelDate.Text = Properties.Resources.Date;
            buttonCreate.Text = Properties.Resources.Create;
            buttonEdit.Text = Properties.Resources.Edit;
            checkBox1.Text = Properties.Resources.All;
            button1.Text = Properties.Resources.Delete;
            buttonRefresh.Text = Properties.Resources.Refresh;

            searchTechCardIdBox.Text = Properties.Resources.ID;
            buttonSearch.Text = Properties.Resources.Search;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = Properties.Resources.ID;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.Date;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = Properties.Resources.Card;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = Properties.Resources.Count;


            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);

            addGridView(query.querySelectOperations());

        }

        private void addGridView(List<ContractTechOperation> et)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in et)
            {
                cel0 = new DataGridViewTextBoxCell();
                cel1 = new DataGridViewTextBoxCell();
                cel2 = new DataGridViewTextBoxCell();
                cel3 = new DataGridViewTextBoxCell();
                row = new DataGridViewRow();

                cel0.Value = item.Id;
                cel1.Value = item.Date;
                cel2.Value = item.TechCardId;
                cel3.Value = item.Amount;

                row.Cells.AddRange(cel0, cel1, cel2, cel3);
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            OperationEditForm f = new OperationEditForm(getInstance());
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            int Id = (int)dataGridView1.Rows[selectedIndex].Cells[0].Value; 
            OperationEditForm f = new OperationEditForm(getInstance(), Id);
            f.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                addGridView(query.querySelectOperations());
            }
            else
            {
                dateTimePicker1.Enabled = true;
                addGridView(query.querySelectOperations(dateTimePicker1.Value.Date));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            query.queryDeleteContractTechOperation((int)dataGridView1.Rows[selectedIndex].Cells[0].Value);
            addGridView(query.querySelectOperations());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        public void refreshGrid()
        {
            searchTechCardIdBox.Text = Properties.Resources.ID;
            addGridView(query.querySelectOperations());
            dateTimePicker1.Enabled = false;
            checkBox1.Checked = true;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int techCardId = Convert.ToInt32(searchTechCardIdBox.Text);
                addGridView(query.querySelectOperationsBySearch(techCardId));
            }
            catch (Exception)
            {
            }
           
        }
    }
}
