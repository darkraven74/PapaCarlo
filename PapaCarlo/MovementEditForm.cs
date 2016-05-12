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
    public partial class MovementEditForm : Form
    {
         QueryContractMove query;
         QueryStore queryStore;
         QueryProducts queryProd;
         MovementsListForm instance;

         int Id = -1;

         public MovementEditForm(int Id, MovementsListForm instance)
             : this(instance)
        {
            this.Id = Id;
            addDataForUpdate();
        }

        public MovementEditForm(MovementsListForm instance)
        {
            this.instance = instance;
            InitializeComponent();

            query = new QueryContractMove();
            queryStore = new QueryStore();
            queryProd = new QueryProducts();

            this.Text = Properties.Resources.Movement;
            label1.Text = Properties.Resources.Good;
            label7.Text = Properties.Resources.Amount;
            label2.Text = Properties.Resources.Date;
            label3.Text = Properties.Resources.FromStorage;
            label4.Text = Properties.Resources.FromCell;
            label6.Text = Properties.Resources.ToStorage;
            label5.Text = Properties.Resources.ToCell;
            buttonCancel.Text = Properties.Resources.Cancel;
            buttonOK.Text = Properties.Resources.OK;

            List<ObjectComboBox> lObj1 = new List<ObjectComboBox>();

            foreach (var item in queryStore.querySelectStorehouses())
            {
                lObj1.Add(new ObjectComboBox(item.Id, item.Name));
            }

            comboBoxStorehouseFrom.DataSource = lObj1;
            comboBoxStorehouseFrom.ValueMember = "Id";
            comboBoxStorehouseFrom.DisplayMember = "Name";

            List<ObjectComboBox> lObj3 = new List<ObjectComboBox>();

            foreach (var item in queryStore.querySelectStorehouses())
            {
                lObj3.Add(new ObjectComboBox(item.Id, item.Name));
            }

            comboBoxStorehouseTo.DataSource = lObj3;
            comboBoxStorehouseTo.ValueMember = "Id";
            comboBoxStorehouseTo.DisplayMember = "Name";

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
            ContractMove c = new ContractMove();
            ObjectComboBox obj2 = (ObjectComboBox)comboBoxCellFrom.SelectedItem;
            c.StoreCellFromId = obj2.Id;
            ObjectComboBox obj4 = (ObjectComboBox)comboBoxCellTo.SelectedItem;
            c.StoreCellToId = obj4.Id;

            ObjectComboBox objPr = (ObjectComboBox)comboBoxProducts.SelectedItem;
            c.ProductId = objPr.Id;
            c.Amount =Int32.Parse(textBoxAmount.Text);
            
            c.Date = dateTimePicker1.Value.Date;
            if (Id == -1)
            {
                query.queryAddContractMove(c);
            }
            else
            {
                c.Id = Id;
                query.queryUpdateContractMove(c);
            }
            instance.refreshGrid();
            this.Dispose();
        }

        private void addDataForUpdate()
        {
            ContractMove c = query.queryFindContractMoveById(Id);
            if (c == null) return;

            dateTimePicker1.Value=c.Date;
            comboBoxStorehouseFrom.SelectedValue = c.StoreCellFromObj.StorehouseId;
            addStorageCells((int)comboBoxStorehouseFrom.SelectedValue, comboBoxCellFrom);
            comboBoxCellFrom.SelectedValue = c.StoreCellFromId;
            comboBoxStorehouseTo.SelectedValue = c.StoreCellToObj.StorehouseId;
            comboBoxCellTo.SelectedValue = c.StoreCellToId;
            addStorageCells((int)comboBoxStorehouseTo.SelectedValue, comboBoxCellTo);
            comboBoxProducts.SelectedValue = c.ProductId;
            textBoxAmount.Text = c.Amount+"";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectComboBox obj = (ObjectComboBox)comboBoxStorehouseFrom.SelectedItem;
            int storehouseIdSelected = obj.Id;
            addStorageCells(storehouseIdSelected, comboBoxCellFrom);
          
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
            
            cb.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
             ObjectComboBox obj = (ObjectComboBox)comboBoxStorehouseTo.SelectedItem;
             int storehouseIdSelected = obj.Id;
             addStorageCells(storehouseIdSelected, comboBoxCellTo);
           
        }

       
    }
}
