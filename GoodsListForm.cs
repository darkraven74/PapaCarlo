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
    public partial class GoodsListForm : Form
    {
        public GoodsListForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Goods;

            labelSearch.Text = Properties.Resources.Search;
            labelColor.Text = Properties.Resources.Color;
            comboBoxColors.DataSource = new List<String> { Properties.Resources.All,
                "Бук", "Вишня", "Белый" };
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
            col1.HeaderText = Properties.Resources.ID;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = Properties.Resources.VendorCode;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = Properties.Resources.Description;

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = Properties.Resources.Color;

            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);


            DataGridViewCell cel0 = new DataGridViewTextBoxCell();
            DataGridViewCell cel1 = new DataGridViewTextBoxCell();
            DataGridViewCell cel2 = new DataGridViewTextBoxCell();
            DataGridViewCell cel3 = new DataGridViewTextBoxCell();
            DataGridViewCell cel4 = new DataGridViewTextBoxCell();
            DataGridViewRow row = new DataGridViewRow();
            cel0.Value = "Стул";
            cel1.Value = "001";
            cel2.Value = "00001";
            cel3.Value = "высокий";
            cel4.Value = "Белый";
            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            cel2 = new DataGridViewTextBoxCell();
            cel3 = new DataGridViewTextBoxCell();
            cel4 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "Стол";
            cel1.Value = "003";
            cel2.Value = "00002";
            cel3.Value = "на 5 персон";
            cel4.Value = "Белый";
            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            cel2 = new DataGridViewTextBoxCell();
            cel3 = new DataGridViewTextBoxCell();
            cel4 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "Брус";
            cel1.Value = "002";
            cel2.Value = "00032";
            cel3.Value = "34х46";
            cel4.Value = "Вишня";
            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4);
            dataGridView1.Rows.Add(row);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            GoodEditForm f = new GoodEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            GoodEditForm f = new GoodEditForm();
            f.ShowDialog();
        }
    }
}
