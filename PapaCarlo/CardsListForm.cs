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
    public partial class CardsListForm : Form
    {
        QueryTechnologicalCards query;

        DataGridViewCell cel0;
        DataGridViewCell cel1;
        DataGridViewCell cel2;
        DataGridViewCell cel3;
        DataGridViewCell cel4;
        DataGridViewRow row;

        private CardsListForm getInstance()
        {
            return this;
        }

        public CardsListForm()
        {
            InitializeComponent();

            query = new QueryTechnologicalCards();

            this.Text = Properties.Resources.Cards;

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

            searchNameBox.Text = Properties.Resources.Title;
            buttonSearch.Text = Properties.Resources.Search;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = Properties.Resources.ID; 
            
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.Title;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = Properties.Resources.InputGoods;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = Properties.Resources.OutputGoods;

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = Properties.Resources.Date;

    
            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);

            addGridView(query.querySelectTechCards());
         

        }

        private void addGridView(List<TechnologicalCard> et)
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

                cel1.Value = item.Title;
                string s1 = "", s2 = "";
                List<ProductAmountTable> listWithAmountProducts = query.querySelectTechCardProducts(item.Id);

                if (listWithAmountProducts.Count > 0)
                {
                    foreach (var item2 in listWithAmountProducts)
                    {
                        if (item2.type == 1)
                        {
                            s1 += item2.product.Name + " " + item2.amount + "; ";
                        }
                        else
                        {
                            s2 += item2.product.Name + " " + item2.amount + "; ";
                        }
                    }
                    cel2.Value = s1.Substring(0, s1.Length - 2);
                    cel3.Value = s2.Substring(0, s2.Length - 2);
                }
                cel0.Value = item.Id;
                cel4.Value = item.Date;
                row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4);
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CardEditForm f = new CardEditForm(getInstance());
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;

            int Id = (int)dataGridView1.Rows[selectedIndex].Cells[0].Value;

            CardEditForm f = new CardEditForm(getInstance(), Id);
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
          query.queryDeleteTechCard((int)dataGridView1.Rows[selectedIndex].Cells[0].Value);
            addGridView(query.querySelectTechCards());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void refreshGrid()
        {
            searchNameBox.Text = Properties.Resources.Title;
            addGridView(query.querySelectTechCards());
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string name = searchNameBox.Text; 
            addGridView(query.querySelectTechCardBySearch(name));
        }
    }
}
