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
    public partial class SupplyListForm : Form
    {
        QueryContractSupply query;

        DataGridViewCell cel0;
        DataGridViewCell cel1;
        DataGridViewCell cel2;
        DataGridViewCell cel3;
        DataGridViewCell cel4;
        DataGridViewRow row;

        public SupplyListForm()
        {
            InitializeComponent();

            query = new QueryContractSupply();

            this.Text = Properties.Resources.Supplies;

            labelSearch.Text = Properties.Resources.Search;
            labelDate.Text = Properties.Resources.Date;
            buttonCreate.Text = Properties.Resources.Create;
            buttonEdit.Text = Properties.Resources.Edit;
            checkBox2.Text = Properties.Resources.All;
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
            col0.HeaderText = Properties.Resources.SupplyContract;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.Date;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = Properties.Resources.Goods;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = Properties.Resources.Number;

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = Properties.Resources.Contractor;


            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);

            addGridView(query.querySelectContractsSupply());

        }

        private void addGridView(List<ContractSupplyTable> et)
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

                cel0.Value = item.contractSupply.Id;
                cel1.Value = item.contractSupply.Date;
                string s = "";
                List<ProductAmountTable> listWithAmountProducts = query.querySelectContractsSupplyProducts(item.contractSupply.Id);
               
                foreach (var item2 in listWithAmountProducts)
                {
                    s += item2.product.Name + " " + item2.amount + "; ";
                }
                cel2.Value = s.Substring(0, s.Length - 2);
                cel3.Value = item.contractSupply.numberOfSupply;
                cel4.Value = item.contractor.Name;

                row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4);
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            SuppluEditForm f = new SuppluEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
           int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            int Id = (int)dataGridView1.Rows[selectedIndex].Cells[0].Value; 
            SuppluEditForm f = new SuppluEditForm(Id);
            f.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            addGridView(query.querySelectContractsSupply(dateTimePicker1.Value.Date));
           // MessageBox.Show(dateTimePicker1.Value.Date+"");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                addGridView(query.querySelectContractsSupply());
            }
            else
            {
                dateTimePicker1.Enabled = true;
                addGridView(query.querySelectContractsSupply(dateTimePicker1.Value.Date));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            MessageBox.Show(query.queryDeleteContractSupply((int)dataGridView1.Rows[selectedIndex].Cells[0].Value) + "");
            addGridView(query.querySelectContractsSupply());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addGridView(query.querySelectContractsSupply());
            dateTimePicker1.Enabled = false;
            checkBox1.Checked = true;
        }
    }
}
