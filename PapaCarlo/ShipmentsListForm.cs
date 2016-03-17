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
    public partial class ShipmentsListForm : Form
    {
        QueryContractShipment query;

        DataGridViewCell cel0;
        DataGridViewCell cel1;
        DataGridViewCell cel2;
        DataGridViewCell cel3;
        DataGridViewCell cel4;
        DataGridViewRow row;

        public ShipmentsListForm()
        {
            InitializeComponent();

            query = new QueryContractShipment();

            this.Text = Properties.Resources.Shipments;

            labelSearch.Text = Properties.Resources.Search;
            labelDate.Text = Properties.Resources.Date;
            buttonCreate.Text = Properties.Resources.Create;
            buttonEdit.Text = Properties.Resources.Edit;
            button1.Text = Properties.Resources.Delete;
            button2.Text = Properties.Resources.Refresh;

            checkBox1.Text = Properties.Resources.All;


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
            col4.HeaderText = Properties.Resources.Good+" "+Properties.Resources.Amount;


            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);


            addGridView(query.querySelectContractsShipment());
        }

        private void addGridView(List<ContractShipmentTable> et)
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

                cel0.Value = item.contractShipment.Id;
                cel1.Value = item.contractShipment.Date;
                cel2.Value = item.storehouseFrom.Name;
                cel3.Value = item.storeCellFrom.Description;
                cel4.Value = item.contractShipment.ProductObj.Name+" "+ item.contractShipment.Amount;

                row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4);
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            ShipmentEditForm f = new ShipmentEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            int Id = (int)dataGridView1.Rows[selectedIndex].Cells[0].Value; 
            ShipmentEditForm f = new ShipmentEditForm(Id);
            f.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                addGridView(query.querySelectContractsShipment());
            }
            else
            {
                dateTimePicker1.Enabled = true;
                addGridView(query.querySelectContractsShipment(dateTimePicker1.Value.Date));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            MessageBox.Show(query.queryDeleteContractShipment((int)dataGridView1.Rows[selectedIndex].Cells[0].Value) + "");
            addGridView(query.querySelectContractsShipment());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addGridView(query.querySelectContractsShipment());
            dateTimePicker1.Enabled = false;
            checkBox1.Checked = true;
        }
    }
}
