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
    public partial class StoragesListForm : Form
    {
        QueryStore query;

        DataGridViewCell cel00;
        DataGridViewCell cel0;
        DataGridViewCell cel1;
        DataGridViewRow row;

        public StoragesListForm()
        {
            InitializeComponent();

            query = new QueryStore();

            this.Text = Properties.Resources.Storages;
            labelSearch.Text = Properties.Resources.Search;
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
            col1.HeaderText = Properties.Resources.Address;

            dataGridView1.Columns.Add(col00);
            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);

            addGridView(query.querySelectStorehouses());
        }

        private void addGridView(List<Storehouse> et)
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
                cel1.Value = item.Address;

                row.Cells.AddRange(cel00, cel0, cel1);
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            StorageEditForm f = new StorageEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;

            int Id = (int)dataGridView1.Rows[selectedIndex].Cells[0].Value; 
            StorageEditForm f = new StorageEditForm(Id);
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            MessageBox.Show(query.queryDeleteStorehouse((int)dataGridView1.Rows[selectedIndex].Cells[0].Value) + "");
            addGridView(query.querySelectStorehouses());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addGridView(query.querySelectStorehouses());
        }
    }
}
