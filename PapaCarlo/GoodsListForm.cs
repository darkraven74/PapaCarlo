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

        private GoodsListForm getInstance()
        {
            return this;
        }

        public GoodsListForm()
        {
            InitializeComponent();

            query = new QueryProducts();

            this.Text = Properties.Resources.Goods;

            labelSearch.Text = Properties.Resources.Search;
            labelColor.Text = Properties.Resources.Color;
           
            buttonCreate.Text = Properties.Resources.Create;
            buttonEdit.Text = Properties.Resources.Edit;
            button1.Text = Properties.Resources.Delete;
            buttonRefresh.Text = Properties.Resources.Refresh;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ScrollBars = ScrollBars.Both;

            searchNameBox.Text = Properties.Resources.Title;
            searchArticleBox.Text = Properties.Resources.VendorCode;
            searchDescriptionBox.Text = Properties.Resources.Description;
            buttonSearch.Text = Properties.Resources.Search;

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
          
            List<ObjectComboBox> lObj = new List<ObjectComboBox>();

            lObj.Add(new ObjectComboBox(0, Properties.Resources.All));

            int i = 1;
            foreach (string item in query.querySelectAllColors())
            {
                lObj.Add(new ObjectComboBox(i, item));
                i++;
            }
            comboBoxColors.DataSource = lObj;
            comboBoxColors.ValueMember = "Id";
            comboBoxColors.DisplayMember = "Name";

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
            GoodEditForm f = new GoodEditForm(getInstance());
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            int Id = (int)dataGridView1.Rows[selectedIndex].Cells[0].Value; 
            GoodEditForm f = new GoodEditForm(getInstance(), Id);
            f.ShowDialog();
        }

        private void comboBoxColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectComboBox obj = (ObjectComboBox)comboBoxColors.SelectedItem;

            if (obj.Id!=0)
            {
                addGridView(query.querySelectProducts(obj.Name));
            }
            else
            {
                addGridView(query.querySelectProducts());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            query.queryDeleteProduct((int)dataGridView1.Rows[selectedIndex].Cells[0].Value);
            addGridView(query.querySelectProducts());
        }

       
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        public void refreshGrid(){
            searchNameBox.Text = Properties.Resources.Title;
            searchArticleBox.Text = Properties.Resources.VendorCode;
            searchDescriptionBox.Text = Properties.Resources.Description;

            addGridView(query.querySelectProducts());
            comboBoxColors.SelectedIndex = 0;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string name = searchNameBox.Text;
            string description = searchDescriptionBox.Text;
            ObjectComboBox obj = (ObjectComboBox)comboBoxColors.SelectedItem;
            int article = 0;
            string color = "";
            try
            {
                if (obj.Id != 0)
                {
                    color = obj.Name;
                }
                    bool ifNumber = Int32.TryParse(searchArticleBox.Text.ToString(), out article);
                    if (!ifNumber)
                    {
                        addGridView(query.querySelectProductsBySearch(name, description, color));
                    }
                    else
                    {
                        addGridView(query.querySelectProductsBySearch(name, article, description, color));
                    }
               
            }
            catch(Exception){
            }
        }
    }
}
