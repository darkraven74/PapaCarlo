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
    public partial class StoragesListForm : Form
    {
        public StoragesListForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Storages;
            labelSearch.Text = Properties.Resources.Search;
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
            col1.HeaderText = Properties.Resources.Address;

            
            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            

            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
            DataGridViewCell cel1 = new DataGridViewTextBoxCell();
            DataGridViewRow row = new DataGridViewRow();
            cel0.Value = "Склад 1";
            cel1.Value = "ул. Ленина, д. 54";
            row.Cells.AddRange(cel0, cel1);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "Главный склад";
            cel1.Value = "пр. Энгельса, д. 48";
            row.Cells.AddRange(cel0, cel1);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "Склад в Пулково";
            cel1.Value = "ш. Пулковское, д. 3";
            row.Cells.AddRange(cel0, cel1);
            dataGridView1.Rows.Add(row);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            StorageEditForm f = new StorageEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            StorageEditForm f = new StorageEditForm();
            f.ShowDialog();
        }
    }
}
