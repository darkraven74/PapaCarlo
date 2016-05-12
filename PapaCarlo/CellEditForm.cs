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
         CellsListForm instance;

         public CellEditForm(CellsListForm instance, int Id)
             : this(instance)
        {
            this.Id = Id;
            addDataForUpdate();
        }

         public CellEditForm(CellsListForm instance)
        {
            this.instance = instance;

            InitializeComponent();

            query = new QueryStore();

            this.Text = Properties.Resources.Cell;

            label1.Text = Properties.Resources.Storage;
            label2.Text = Properties.Resources.Description;

             List<ObjectComboBox> lObj = new List<ObjectComboBox>();

            foreach (var item in query.querySelectStorehouses())
            {
                lObj.Add(new ObjectComboBox(item.Id, item.Name));
            }

            comboBoxStorages.DataSource = lObj;
            comboBoxStorages.ValueMember = "Id";
            comboBoxStorages.DisplayMember = "Name";
     

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
            ObjectComboBox obj = (ObjectComboBox)comboBoxStorages.SelectedItem;
            c.StorehouseId = obj.Id;
            c.Description = textBox2.Text;
            if (Id == -1)
            {
                query.queryAddStoreCell(c);
            }
            else
            {
                c.Id = Id;
                query.queryUpdateStoreCell(c);
            }

            instance.refreshGrid();
            this.Dispose();
        }

        private void addDataForUpdate()
        {
            StoreCell c = query.queryFindStoreCellById(Id);
            if (c == null) return;

            textBox2.Text = c.Description;
            ObjectComboBox obj = (ObjectComboBox)comboBoxStorages.SelectedItem;
            comboBoxStorages.SelectedValue = c.StorehouseId;
        }
    }
}
