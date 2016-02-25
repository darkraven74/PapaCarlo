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
    public partial class CardsListForm : Form
    {
        public CardsListForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Cards;

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
            col1.HeaderText = Properties.Resources.InputGoods;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = Properties.Resources.OutputGoods;


            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);


            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
            DataGridViewCell cel1 = new DataGridViewTextBoxCell();
            DataGridViewCell cel2 = new DataGridViewTextBoxCell();
            DataGridViewRow row = new DataGridViewRow();
            cel0.Value = "Стул эконом (жесткий)";
            cel1.Value = "2 Брус, 4 Саморез";
            cel2.Value = "1 Стул эконом";
            row.Cells.AddRange(cel0, cel1, cel2);
            dataGridView1.Rows.Add(row);


            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            cel2 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "Табурет";
            cel1.Value = "1 Брус, 1 Клей";
            cel2.Value = "1 Табурет";
            row.Cells.AddRange(cel0, cel1, cel2);
            dataGridView1.Rows.Add(row);

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CardEditForm f = new CardEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            CardEditForm f = new CardEditForm();
            f.ShowDialog();
        }
    }
}
