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

        private ContractorsListForm getInstance()
        {
            return this;
        }

        public ContractorsListForm()
        {
            InitializeComponent();

            query= new QueryContractors();

            this.Text = Properties.Resources.Contractors;

            labelSearch.Text = Properties.Resources.Search;
            labelContractorType.Text = Properties.Resources.ContractorType;
          

            buttonCreate.Text = Properties.Resources.Create;
            buttonEdit.Text = Properties.Resources.Edit;
            buttonDelete.Text = Properties.Resources.Delete;
            buttonRefresh.Text = Properties.Resources.Refresh;
            buttonSearch.Text = Properties.Resources.Search;

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

           List<ObjectComboBox> lObj = new List<ObjectComboBox>();

           lObj.Add(new ObjectComboBox(0, Properties.Resources.All));
           lObj.Add(new ObjectComboBox(1, Properties.Resources.Customer));
           lObj.Add(new ObjectComboBox(2, Properties.Resources.Provider));

           comboBoxContractorType.DataSource = lObj;

           comboBoxContractorType.ValueMember = "Id";
           comboBoxContractorType.DisplayMember = "Name";

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
            ContractorEditForm f = new ContractorEditForm(getInstance());
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;

            int Id = (int)dataGridView1.Rows[selectedIndex].Cells[0].Value; 
            ContractorEditForm f = new ContractorEditForm(getInstance(), Id);
            f.ShowDialog();
        }

        private void comboBoxContractorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectComboBox obj = (ObjectComboBox)comboBoxContractorType.SelectedItem;
            List<Contractor> list = query.querySelectContractors(obj.Id);
           addGridView(list);
           // MessageBox.Show(comboBoxContractorType.SelectedIndex+"");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            query.queryDeleteContractor((int)dataGridView1.Rows[selectedIndex].Cells[0].Value);
            addGridView(query.querySelectContractors(0));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        public void refreshGrid()
        {
            addGridView(query.querySelectContractors(0));
        }

        private void search_Click(object sender, EventArgs e)
        {
             string name = searchNameBox.Text;
             ObjectComboBox obj = (ObjectComboBox)comboBoxContractorType.SelectedItem;
             if (obj.Id != 0)
             {
                 addGridView(query.querySelectContractorsBySearch(name, obj.Id));
             }
             else
             {
                 addGridView(query.querySelectContractorsBySearch(name));
             }
        }
    }
}
