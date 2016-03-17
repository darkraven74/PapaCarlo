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
using System.Collections;

namespace PapaCarlo
{
    public partial class GoodsListForm : Form
    {
        QueryProducts query;

        DataGridViewCell cel0;
        DataGridViewCell cel1;
        DataGridViewCell cel2;
        DataGridViewCell cel3;
        DataGridViewCell cel4;
        DataGridViewRow row;

        public GoodsListForm()
        {
            InitializeComponent();

            query = new QueryProducts();

            this.Text = Properties.Resources.Goods;

            labelSearch.Text = Properties.Resources.Search;
            labelColor.Text = Properties.Resources.Color;
            ArrayList lObj = new ArrayList();

            lObj.Add(Properties.Resources.All);
            foreach (string item in query.querySelectAllColors())
            {
                lObj.Add(item);
            }
            comboBoxColors.DataSource = lObj;
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

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = Properties.Resources.ID;
            
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.Title;

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

            addGridView(query.querySelectProducts());
        }

        private void addGridView(List<Product> et)
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

                cel0.Value = item.Id;
                cel1.Value = item.Name;
                cel2.Value = item.VendorCode;
                cel3.Value = item.Description;
                cel4.Value = item.Color;

                row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4);
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            GoodEditForm f = new GoodEditForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            int Id = (int)dataGridView1.Rows[selectedIndex].Cells[0].Value; 
            GoodEditForm f = new GoodEditForm(Id);
            f.ShowDialog();
        }

        private void comboBoxColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxColors.SelectedValue.Equals(Properties.Resources.All))
            {
                addGridView(query.querySelectProducts((string)comboBoxColors.SelectedValue));
            }
            else
            {
                addGridView(query.querySelectProducts());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            MessageBox.Show(query.queryDeleteProduct((int)dataGridView1.Rows[selectedIndex].Cells[0].Value) + "");
            addGridView(query.querySelectProducts());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addGridView(query.querySelectProducts());
        }
    }
}
