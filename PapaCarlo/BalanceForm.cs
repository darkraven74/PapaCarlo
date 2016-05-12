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
    public partial class BalanceForm : Form
    {
        QueryReports query; 

        DataGridViewCell cel0;
        DataGridViewCell cel1;
        DataGridViewCell cel2;
        DataGridViewCell cel3;
        DataGridViewCell cel4;
        DataGridViewRow row;

        public BalanceForm()
        {
            InitializeComponent();

            query = new QueryReports();

            this.Text = Properties.Resources.Balance;

            labelDate.Text = Properties.Resources.Date;

            searchStorehouseBox.Text = Properties.Resources.Storage;
            searchProductBox.Text = Properties.Resources.Good;

            checkBox1.Text = Properties.Resources.All;

            buttonRefresh.Text = Properties.Resources.Refresh;
            buttonSearch.Text = Properties.Resources.Search;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = Properties.Resources.Storage;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.Cell;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = Properties.Resources.Good;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = Properties.Resources.Count;

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = Properties.Resources.Date;

            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);

            addGridView(query.querySelectReportBalance());
          

        }

        private void addGridView(List<ReportBalanceTable> et)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in et)
            {
                cel0 = new DataGridViewTextBoxCell();
                cel1 = new DataGridViewTextBoxCell();
                cel2 = new DataGridViewTextBoxCell();
                cel3 = new DataGridViewTextBoxCell();
                cel4 = new DataGridViewTextBoxCell();
                row = new DataGridViewRow();

                cel0.Value = item.storehouse.Name;
                cel1.Value = item.storeCell.Description;
                cel2.Value = item.product.Name;
                cel3.Value = item.reportBalance.Amount;
                cel4.Value = item.reportBalance.Date;

                row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4);
                dataGridView1.Rows.Add(row);
            }
        }

        private void labelDate_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            addGridView(query.querySelectReportBalance(dateTimePicker1.Value.Date));

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                addGridView(query.querySelectReportBalance());
            }
            else
            {
                dateTimePicker1.Enabled = true;
                addGridView(query.querySelectReportBalance(dateTimePicker1.Value.Date));
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            string searchStorehouse = searchStorehouseBox.Text;
            string searchProduct = searchProductBox.Text;
            addGridView(query.querySelectReportBalanceBySearch(searchStorehouse, searchProduct));
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            searchStorehouseBox.Text = Properties.Resources.Storage;
            searchProductBox.Text = Properties.Resources.Good;
            addGridView(query.querySelectReportBalance());
        }
    }
}
