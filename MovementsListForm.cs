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
    public partial class MovementsListForm : Form
    {
        QueryContractMove query;

        DataGridViewCell cel0;
        DataGridViewCell cel1;
        DataGridViewCell cel2;
        DataGridViewCell cel3;
        DataGridViewCell cel4;
        DataGridViewCell cel5;
        DataGridViewCell cel6;
        DataGridViewRow row;

        public MovementsListForm()
        {
            InitializeComponent();

            query = new QueryContractMove();

            this.Text = Properties.Resources.Movements;

            labelSearch.Text = Properties.Resources.Search;
            labelDate.Text = Properties.Resources.Date;
            buttonCreate.Text = Properties.Resources.Create;
            buttonEdit.Text = Properties.Resources.Edit;
            checkBox1.Text = Properties.Resources.All;
            button1.Text = Properties.Resources.Delete;
            button2.Text = Properties.Resources.Refresh;

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
            col2.HeaderText = Properties.Resources.FromStorage;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = Properties.Resources.FromCell;

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = Properties.Resources.ToStorage;

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = Properties.Resources.ToCell;

            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = Properties.Resources.Good + " " + Properties.Resources.Amount;


            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);
            dataGridView1.Columns.Add(col5);
            dataGridView1.Columns.Add(col6);


            addGridView(query.querySelectContractsMove());
        }

        private void addGridView(List<ContractMoveTable> et)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in et)
            {
                cel0 = new DataGridViewTextBoxCell();
                cel1 = new DataGridViewTextBoxCell();
                cel2 = new DataGridViewTextBoxCell();
                cel3 = new DataGridViewTextBoxCell();
                cel4 = new DataGridViewTextBoxCell();
                cel5 = new DataGridViewTextBoxCell();
                cel6 = new DataGridViewTextBoxCell();
                row = new DataGridViewRow();

                cel0.Value = item.contractMove.Id;
                cel1.Value = item.contractMove.Date;
                cel2.Value = item.storehouseFrom.Name;
                cel3.Value = item.storeCellFrom.Description;
                cel4.Value = item.storehouseTo.Name;
                cel5.Value = item.storeCellTo.Description;
                cel6.Value = item.contractMove.ProductObj.Name + " " + item.contractMove.Amount;

                row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5, cel6);
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            MovementEditForm f = new MovementEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            int Id = (int)dataGridView1.Rows[selectedIndex].Cells[0].Value; 
            MovementEditForm f = new MovementEditForm(Id);
            f.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            addGridView(query.querySelectContractsMove(dateTimePicker1.Value.Date));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                addGridView(query.querySelectContractsMove());
            }
            else
            {
                dateTimePicker1.Enabled = true;
                addGridView(query.querySelectContractsMove(dateTimePicker1.Value.Date));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            MessageBox.Show(query.queryDeleteContractMove((int)dataGridView1.Rows[selectedIndex].Cells[0].Value) + "");
            addGridView(query.querySelectContractsMove());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addGridView(query.querySelectContractsMove());
            dateTimePicker1.Enabled = false;
            checkBox1.Checked = true;

        }
    }
}
