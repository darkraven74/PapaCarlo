using System;
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
    public partial class CellEditForm : Form
    {
        QueryStore query;

         int Id = -1;

         public CellEditForm(int Id)
             : this()
        {
            this.Id = Id;
            addDataForUpdate();
        }

        public CellEditForm()
        {
            InitializeComponent();

            query = new QueryStore();

            this.Text = Properties.Resources.Cell;

            label1.Text = Properties.Resources.Storage;
            label2.Text = Properties.Resources.Description;

            ArrayList lObj = new ArrayList();

            foreach (var item in query.querySelectStorehouses())
            {
                lObj.Add(new { Id = item.Id, StorehouseName = item.Name });
            }

            comboBox1.DataSource = lObj;

            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "StorehouseName"; ;

            buttonCancel.Text = Properties.Resources.Cancel;
            buttonOK.Text = Properties.Resources.OK;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            StoreCell c = new StoreCell();
            c.StorehouseId = (int)comboBox1.SelectedValue;
            c.Description = textBox2.Text;
            if (Id == -1)
            {
                MessageBox.Show(query.queryAddStoreCell(c) + "");
            }
            else
            {
                c.Id = Id;
                MessageBox.Show(query.queryUpdateStoreCell(c) + "");
            }
            this.Dispose();
        }

        private void addDataForUpdate()
        {
            StoreCell c = query.queryFindStoreCellById(Id);
            if (c == null) return;

            textBox2.Text = c.Description;
            comboBox1.SelectedValue = c.StorehouseId;
        }
    }
}
