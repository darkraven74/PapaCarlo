﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using PapaCarloDBApp;

namespace PapaCarlo
{
    public partial class CellsListForm : Form
    {
        QueryStore query;

        DataGridViewCell cel0;
        DataGridViewCell cel1;
        DataGridViewCell cel2;
        DataGridViewRow row;

        private CellsListForm getInstance()
        {
            return this;
        }

        public CellsListForm()
        {
            InitializeComponent();

            query = new QueryStore();

            this.Text = Properties.Resources.Cells;

            labelSearch.Text = Properties.Resources.Search;
            labelStorage.Text = Properties.Resources.Storage;


            searchCellIdBox.Text = Properties.Resources.ID;
            searchDescriptionBox.Text = Properties.Resources.Description;
            buttonSearch.Text = Properties.Resources.Search;

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

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = Properties.Resources.Storage;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.Description;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = Properties.Resources.ID;

            dataGridView1.Columns.Add(col0);
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);

            addGridView(query.querySelectStoreCells(0));

            List<ObjectComboBox> lObj = new List<ObjectComboBox>();

            lObj.Add(new ObjectComboBox(0, Properties.Resources.All));
            foreach (var item in query.querySelectStorehouses())
            {
                lObj.Add(new ObjectComboBox(item.Id, item.Name));
            }

            comboBoxStorages.DataSource = lObj;
            comboBoxStorages.ValueMember = "Id";
            comboBoxStorages.DisplayMember = "Name";
        }

        private void addGridView(List<StoreCellTable> et)
        {
            dataGridView1.Rows.Clear();
            DataTable table = new DataTable();
            foreach (var item in et)
            {
                cel0 = new DataGridViewTextBoxCell();
                cel1 = new DataGridViewTextBoxCell();
                cel2 = new DataGridViewTextBoxCell();
                row = new DataGridViewRow();

                cel2.Value = item.storehouse.Name;
                cel1.Value = item.storeCell.Description;
                cel0.Value = item.storeCell.Id;

                row.Cells.AddRange(cel0, cel1, cel2);
                dataGridView1.Rows.Add(row);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CellEditForm f = new CellEditForm(getInstance());
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;

            int Id = (int)dataGridView1.Rows[selectedIndex].Cells[0].Value; 
            CellEditForm f = new CellEditForm(getInstance(), Id);
            f.ShowDialog();
        }

        private void labelStorage_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxStorages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectComboBox obj = (ObjectComboBox)comboBoxStorages.SelectedItem;
            List<StoreCellTable> list = query.querySelectStoreCells(obj.Id);
            addGridView(list);
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSearch_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
           query.queryDeleteStoreCell((int)dataGridView1.Rows[selectedIndex].Cells[0].Value);
            addGridView(query.querySelectStoreCells(0));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        public void refreshGrid()
        {
            searchCellIdBox.Text = Properties.Resources.ID;
            searchDescriptionBox.Text = Properties.Resources.Description;
            addGridView(query.querySelectStoreCells(0));
        }

        private void CellsListForm_Load(object sender, EventArgs e)
        {

        }

        private void searchDescriptionBox_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string description = searchDescriptionBox.Text;
            int id = 0;
            bool isNumber = Int32.TryParse(searchCellIdBox.Text, out id);
            ObjectComboBox obj = (ObjectComboBox)comboBoxStorages.SelectedItem;
            if (obj.Id != 0)
            {
                addGridView(query.querySelectStoreCellsBySearch(description, id, obj.Id));
            }
            else
            {
                addGridView(query.querySelectStoreCellsBySearch(description, id));
            }
           
        }
    }
}
