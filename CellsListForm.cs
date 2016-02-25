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
    public partial class CellsListForm : Form
    {
        public CellsListForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Cells;

            labelSearch.Text = Properties.Resources.Search;
            labelStorage.Text = Properties.Resources.Storage;
            comboBoxStorages.DataSource = new List<String> { Properties.Resources.All,
                "Склад 1", "Главный склад", "Склад в Пулково" };
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
            col0.HeaderText = Properties.Resources.Storage;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.Description;


            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);


            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
            DataGridViewCell cel1 = new DataGridViewTextBoxCell();
            DataGridViewRow row = new DataGridViewRow();
            cel0.Value = "Склад 1";
            cel1.Value = "ячейка для стали";
            row.Cells.AddRange(cel0, cel1);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "Главный склад";
            cel1.Value = "ячейка в углу";
            row.Cells.AddRange(cel0, cel1);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "Склад в Пулково";
            cel1.Value = "ячейка для всего";
            row.Cells.AddRange(cel0, cel1);
            dataGridView1.Rows.Add(row);


        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CellEditForm f = new CellEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            CellEditForm f = new CellEditForm();
            f.ShowDialog();
        }
    }
}
