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
    public partial class BalancePredictionForm : Form
    {
        public BalancePredictionForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Predict;

            labelDate.Text = Properties.Resources.Date;
            labelStorage.Text = Properties.Resources.Storage;
            labelCell.Text = Properties.Resources.SupplyContract;
            labelGood.Text = Properties.Resources.Good;
            labelAggregate.Text = Properties.Resources.Aggregate;
            radioButton1.Text = Properties.Resources.Storage;
            radioButton2.Text = Properties.Resources.Good;



            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = Properties.Resources.SupplyContract;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = Properties.Resources.Storage;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = Properties.Resources.Good;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = Properties.Resources.Count;

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = Properties.Resources.Predict;


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
            cel0.Value = "01";
            cel1.Value = "Склад 1";
            cel2.Value = "Шкаф";
            cel3.Value = "3";
            cel4.Value = "5";
            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            cel2 = new DataGridViewTextBoxCell();
            cel3 = new DataGridViewTextBoxCell();
            cel4 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "02";
            cel1.Value = "Склад 1";
            cel2.Value = "Стол";
            cel3.Value = "1";
            cel4.Value = "2";
            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4);
            dataGridView1.Rows.Add(row);

            cel0 = new DataGridViewTextBoxCell();
            cel1 = new DataGridViewTextBoxCell();
            cel2 = new DataGridViewTextBoxCell();
            cel3 = new DataGridViewTextBoxCell();
            cel4 = new DataGridViewTextBoxCell();
            row = new DataGridViewRow();
            cel0.Value = "06";
            cel1.Value = "Склад 2";
            cel2.Value = "Стул";
            cel3.Value = "2";
            cel4.Value = "4";
            row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4);
            dataGridView1.Rows.Add(row);
        }
    }
}
