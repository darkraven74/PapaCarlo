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
    public partial class SupplyContractsListForm : Form
    {
        public SupplyContractsListForm()
        {
            InitializeComponent();

            this.Text = Properties.Resources.SupplyContracts;

            labelSearch.Text = Properties.Resources.Search;
            labelDate.Text = Properties.Resources.Date;
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
            col0.HeaderText = Properties.Resources.Contractor;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.Date;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = Properties.Resources.Goods;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = Properties.Resources.Number;

          


            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);


            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
            DataGridViewCell cel1 = new DataGridViewTextBoxCell();
            DataGridViewCell cel2 = new DataGridViewTextBoxCell();
            DataGridViewCell cel3 = new DataGridViewTextBoxCell();
            DataGridViewRow row = new DataGridViewRow();
            cel0.Value = "ООО Светлана";
            cel1.Value = "02.01.2016";
            cel2.Value = "1 Брус, 2 Шуруп";
            cel3.Value = "001";
            row.Cells.AddRange(cel0, cel1, cel2, cel3);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            cel2 = new DataGridViewTextBoxCell();
            cel3 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "ООО Светлана";
            cel1.Value = "05.07.2016";
            cel2.Value = "1 Брус";
            cel3.Value = "002";
            row.Cells.AddRange(cel0, cel1, cel2, cel3);
            dataGridView1.Rows.Add(row);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            SuppluContractEditForm f = new SuppluContractEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            SuppluContractEditForm f = new SuppluContractEditForm();
            f.ShowDialog();
        }
    }
}
