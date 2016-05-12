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
    public partial class ShipmentEditForm : Form
    {
         QueryContractShipment query;
         QueryStore queryStore;
         QueryProducts queryProd;

         ShipmentsListForm instance;

         int Id = -1;

         public ShipmentEditForm( ShipmentsListForm instance, int Id)
             : this(instance)
        {
            this.Id = Id;
            addDataForUpdate();
        }

         public ShipmentEditForm(ShipmentsListForm instance)
        {
            this.instance = instance;
            InitializeComponent();

            query = new QueryContractShipment();
            queryStore = new QueryStore();
            queryProd = new QueryProducts();

            this.Text = Properties.Resources.Shipment;
            label1.Text = Properties.Resources.Good;
            label2.Text = Properties.Resources.Date;
            label3.Text = Properties.Resources.FromStorage;
            label4.Text = Properties.Resources.FromCell;
            label5.Text = Properties.Resources.Amount;
            buttonCancel.Text = Properties.Resources.Cancel;
            buttonOK.Text = Properties.Resources.OK;

            List<ObjectComboBox> lObj3 = new List<ObjectComboBox>();

            foreach (var item in queryStore.querySelectStorehouses())
            {
                lObj3.Add(new ObjectComboBox(item.Id, item.Name));
            }

            comboBoxStorehouses.DataSource = lObj3;
            comboBoxStorehouses.ValueMember = "Id";
            comboBoxStorehouses.DisplayMember = "Name";

            List<ObjectComboBox> lObjPr = new List<ObjectComboBox>();

            foreach (var item in queryProd.querySelectProducts())
            {
                lObjPr.Add(new ObjectComboBox(item.Id, item.Name));
            }

            comboBoxProducts.DataSource = lObjPr;

            comboBoxProducts.ValueMember = "Id";
            comboBoxProducts.DisplayMember = "Name"; 
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ContractShipment c = new ContractShipment();
            ObjectComboBox obj2 = (ObjectComboBox)comboBoxCells.SelectedItem;
            c.StoreCellFromId = obj2.Id;

            ObjectComboBox objPr = (ObjectComboBox)comboBoxProducts.SelectedItem;
            c.ProductId = objPr.Id;
            int amount = 0;
            Int32.TryParse(textBox1.Text, out amount);
            c.Amount = amount;
            c.Date = dateTimePicker1.Value.Date;
            if (Id == -1)
            {
                query.queryAddContractShipment(c);
            }
            else
            {
                c.Id = Id;
               query.queryUpdateContractShipment(c);
            }
            instance.refreshGrid();
            this.Dispose();
        }

        private void addDataForUpdate()
        {
            ContractShipment c = query.queryFindContractShipmentById(Id);
            if (c == null) return;

            dateTimePicker1.Value = c.Date; 
            comboBoxProducts.SelectedValue = c.ProductId;
            comboBoxStorehouses.SelectedValue = c.StoreCellFromObj.StorehouseId;
            addStorageCells((int)comboBoxStorehouses.SelectedValue, comboBoxCells);
            comboBoxCells.SelectedValue = c.StoreCellFromObj.Id;

            textBox1.Text = c.Amount+"";
        }

        private void addStorageCells(int storehouseIdSelected, ComboBox cb)
        {
            List<ObjectComboBox> lObj = new List<ObjectComboBox>();

            foreach (var item in queryStore.querySelectStoreCells(storehouseIdSelected))
            {
                lObj.Add(new ObjectComboBox(item.storeCell.Id, item.storeCell.Description));
            }

            cb.DataSource = lObj;
            cb.ValueMember = "Id";
            cb.DisplayMember = "Name";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectComboBox obj = (ObjectComboBox)comboBoxStorehouses.SelectedItem;
            int storehouseIdSelected = obj.Id;
            addStorageCells(storehouseIdSelected, comboBoxCells);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
