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
    public partial class ContractorsListForm : Form
    {
        QueryContractors query;

        DataGridViewCell cel00;
        DataGridViewCell cel0;
        DataGridViewCell cel1;
        DataGridViewRow row;

        public ContractorsListForm()
        {
            InitializeComponent();

            query= new QueryContractors();

            this.Text = Properties.Resources.Contractors;

            labelSearch.Text = Properties.Resources.Search;
            labelContractorType.Text = Properties.Resources.ContractorType;
            comboBoxContractorType.DataSource = new List<String> { Properties.Resources.All,
                Properties.Resources.Customer, Properties.Resources.Provider };
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
            col0.HeaderText = Properties.Resources.Title;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.ContractorType;


            dataGridView1.Columns.Add(col00);
            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);

            addGridView(query.querySelectContractors(0));
        }

        private void addGridView(List<Contractor> et)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in et)
            {
                cel00 = new DataGridViewTextBoxCell();
                cel0 = new DataGridViewTextBoxCell();
                cel1 = new DataGridViewTextBoxCell();
                row = new DataGridViewRow();

                cel00.Value = item.Id;
                cel0.Value = item.Name;

                if (item.Type == 1)
                {
                    cel1.Value = Properties.Resources.Customer;
                }
                else
                {
                    cel1.Value = Properties.Resources.Provider;
                }

                row.Cells.AddRange(cel00, cel0, cel1);
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            ContractorEditForm f = new ContractorEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;

            int Id = (int)dataGridView1.Rows[selectedIndex].Cells[0].Value; 
            ContractorEditForm f = new ContractorEditForm(Id);
            f.ShowDialog();
        }

        private void comboBoxContractorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            addGridView(query.querySelectContractors(comboBoxContractorType.SelectedIndex));
           // MessageBox.Show(comboBoxContractorType.SelectedIndex+"");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            MessageBox.Show(query.queryDeleteContractor((int)dataGridView1.Rows[selectedIndex].Cells[0].Value) + "");
            addGridView(query.querySelectContractors(0));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addGridView(query.querySelectContractors(0));
        }
    }
}
