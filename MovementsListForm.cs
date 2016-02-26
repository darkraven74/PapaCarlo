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
    public partial class MovementsListForm : Form
    {
        public MovementsListForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Movements;

            labelSearch.Text = Properties.Resources.Search;
            labelDate.Text = Properties.Resources.Date;
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
            col0.HeaderText = Properties.Resources.ID;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.Date;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = Properties.Resources.FromStorage;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = Properties.Resources.FromCell;

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = Properties.Resources.ToStorage;

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = Properties.Resources.ToCell;


            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);
            dataGridView1.Columns.Add(col5);


            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
            DataGridViewCell cel1 = new DataGridViewTextBoxCell();
            DataGridViewCell cel2 = new DataGridViewTextBoxCell();
            DataGridViewCell cel3 = new DataGridViewTextBoxCell();
            DataGridViewCell cel4 = new DataGridViewTextBoxCell();
            DataGridViewCell cel5 = new DataGridViewTextBoxCell();
            DataGridViewRow row = new DataGridViewRow();
            cel0.Value = "01";
            cel1.Value = "20.02.2012";
            cel2.Value = "Склад 1";
            cel3.Value = "01";
            cel4.Value = "Склад 1";
            cel5.Value = "02";
            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            cel2 = new DataGridViewTextBoxCell();
            cel3 = new DataGridViewTextBoxCell();
            cel4 = new DataGridViewTextBoxCell();
            cel5 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "05";
            cel1.Value = "24.01.2015";
            cel2.Value = "Склад 2";
            cel3.Value = "03";
            cel4.Value = "Склад 1";
            cel5.Value = "01";
            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            cel2 = new DataGridViewTextBoxCell();
            cel3 = new DataGridViewTextBoxCell();
            cel4 = new DataGridViewTextBoxCell();
            cel5 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "03";
            cel1.Value = "24.04.2015";
            cel2.Value = "Склад 3";
            cel3.Value = "03";
            cel4.Value = "Склад 1";
            cel5.Value = "02";
            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5);
            dataGridView1.Rows.Add(row);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            MovementEditForm f = new MovementEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            MovementEditForm f = new MovementEditForm();
            f.ShowDialog();
        }
    }
}
