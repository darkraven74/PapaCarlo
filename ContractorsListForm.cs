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
    public partial class ContractorsListForm : Form
    {
        public ContractorsListForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Contractors;

            labelSearch.Text = Properties.Resources.Search;
            labelContractorType.Text = Properties.Resources.ContractorType;
            comboBoxContractorType.DataSource = new List<String> { Properties.Resources.All,
                Properties.Resources.Provider, Properties.Resources.Customer };
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
            col0.HeaderText = Properties.Resources.Title;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.ContractorType;


            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);


            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
            DataGridViewCell cel1 = new DataGridViewTextBoxCell();
            DataGridViewRow row = new DataGridViewRow();
            cel0.Value = "ООО Светлана";
            cel1.Value = Properties.Resources.Customer;
            row.Cells.AddRange(cel0, cel1);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "ИП Бобров";
            cel1.Value = Properties.Resources.Provider;
            row.Cells.AddRange(cel0, cel1);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "Компания деньга";
            cel1.Value = Properties.Resources.Customer;
            row.Cells.AddRange(cel0, cel1);
            dataGridView1.Rows.Add(row);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            ContractorEditForm f = new ContractorEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ContractorEditForm f = new ContractorEditForm();
            f.ShowDialog();
        }
    }
}
