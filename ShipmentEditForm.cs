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

         int Id = -1;

         public ShipmentEditForm(int Id)
             : this()
        {
            this.Id = Id;
            addDataForUpdate();
        }

    public ShipmentEditForm()
        {
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

            ArrayList lObjPr = new ArrayList();

            foreach (var item in queryProd.querySelectProducts())
            {
                lObjPr.Add(new { Id = item.Id, Name = item.Name });
            }

            comboBox1.DataSource = lObjPr;

            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name"; 


            ArrayList lObj1 = new ArrayList();

            foreach (var item in queryStore.querySelectStorehouses())
            {
                lObj1.Add(new { Id = item.Id, StorehouseName = item.Name });
            }

            comboBox2.DataSource = lObj1;
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "StorehouseName";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ContractShipment c = new ContractShipment();
            c.StoreCellFromId = (int)comboBox3.SelectedValue;

            c.ProductId = (int)comboBox1.SelectedValue;
            c.Amount = Int32.Parse(textBox1.Text);
            c.Date = dateTimePicker1.Value.Date;
            if (Id == -1)
            {
                MessageBox.Show(query.queryAddContractShipment(c) + "");
            }
            else
            {
                c.Id = Id;
                MessageBox.Show(query.queryUpdateContractShipment(c) + "");
            } 
            this.Dispose();
        }

        private void addDataForUpdate()
        {
            ContractShipment c = query.queryFindContractShipmentById(Id);
            if (c == null) return;

            dateTimePicker1.Value = c.Date; 
            comboBox1.SelectedValue = c.ProductId;
            comboBox2.SelectedValue = c.StoreCellFromObj.StorehouseId;
            addStorageCells((int)comboBox2.SelectedValue, comboBox3);
            comboBox3.SelectedValue = c.StoreCellFromObj.Id;

            textBox1.Text = c.Amount+"";
        }

        private void addStorageCells(int storehouseIdSelected, ComboBox cb)
        {
            //int storehouseIdSelected = (int)comboBox2.SelectedValue;
            ArrayList lObj = new ArrayList();

            foreach (var item in queryStore.querySelectStoreCells(storehouseIdSelected))
            {
                lObj.Add(new { Id = item.storeCell.Id, DescriptionCell = item.storeCell.Description });
            }
            cb.DataSource = lObj;
            cb.ValueMember = "Id";
            cb.DisplayMember = "DescriptionCell";
            cb.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            addStorageCells((int)comboBox2.SelectedValue, comboBox3);
        }
    }
}
