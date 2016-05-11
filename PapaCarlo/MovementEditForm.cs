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
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Activities.Hosting;

namespace PapaCarlo
{
    public partial class MovementEditForm : Form
    {
         QueryContractMove query;
         QueryStore queryStore;
         QueryProducts queryProd;

         int Id = -1;
         int oldAm = 0;

         public MovementEditForm(int Id)
             : this()
        {
            this.Id = Id;
            addDataForUpdate();
        }

        public MovementEditForm()
        {
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

            ArrayList lObj1 = new ArrayList();

            foreach (var item in queryStore.querySelectStorehouses())
            {
                lObj1.Add(new { Id = item.Id, StorehouseName = item.Name });
            }

            ArrayList lObj3 = new ArrayList();

            foreach (var item in queryStore.querySelectStorehouses())
            {
                lObj3.Add(new { Id = item.Id, StorehouseName = item.Name });
            }

            comboBox1.DataSource = lObj1;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "StorehouseName";

            comboBox3.DataSource = lObj3;
            comboBox3.ValueMember = "Id";
            comboBox3.DisplayMember = "StorehouseName";


            ArrayList lObjPr = new ArrayList();

            foreach (var item in queryProd.querySelectProducts())
            {
                lObjPr.Add(new { Id = item.Id, Name = item.Name });
            }

            comboBox5.DataSource = lObjPr;

            comboBox5.ValueMember = "Id";
            comboBox5.DisplayMember = "Name"; 
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
           /* ContractMove c = new ContractMove();
            c.StoreCellFromId = (int)comboBox2.SelectedValue;
            c.StoreCellToId = (int)comboBox4.SelectedValue;

            c.ProductId = (int)comboBox5.SelectedValue;
            c.Amount =Int32.Parse(textBoxAmount.Text);
            
            c.Date = dateTimePicker1.Value.Date;
            */

            QueryContractShipment q = new QueryContractShipment();

            ContractShipment c = new ContractShipment();
            c.StoreCellFromId = (int)comboBox2.SelectedValue;

            c.ProductId = (int)comboBox5.SelectedValue;
            c.Amount = Int32.Parse(textBoxAmount.Text);
            c.Date = dateTimePicker1.Value.Date;

            int storeId = (int)comboBox1.SelectedValue;

            Dictionary<string, object> arguments = new Dictionary<string, object>();
            arguments.Add("query", q);
            arguments.Add("contr", c);
            arguments.Add("Id", -1);
            arguments.Add("storeId", storeId);
            arguments.Add("oldAmount", oldAm);
            arguments.Add("mov", 1);


            IDictionary<string, object> outputs = WorkflowInvoker.Invoke(new Shipment(), arguments);

            Console.WriteLine("status:  {0}", outputs["Result"]);
            if (!(bool)outputs["Result"])
            {
                MessageBox.Show("error");
                this.Dispose();
                return;
            }


            //***

            c.StoreCellFromId = (int)comboBox4.SelectedValue;

            c.Amount = -Int32.Parse(textBoxAmount.Text);

            storeId = (int)comboBox3.SelectedValue;

            arguments = new Dictionary<string, object>();
            arguments.Add("query", q);
            arguments.Add("contr", c);
            arguments.Add("Id", -1);
            arguments.Add("storeId", storeId);
            arguments.Add("oldAmount", -oldAm);
            arguments.Add("mov", 1);


            outputs = WorkflowInvoker.Invoke(new Shipment(), arguments);

            Console.WriteLine("status:  {0}", outputs["Result"]);
            if (!(bool)outputs["Result"])
            {
                MessageBox.Show("error");
                this.Dispose();
                return;
            }

            ContractMove cm = new ContractMove();

            cm.StoreCellFromId = (int)comboBox2.SelectedValue;
            cm.StoreCellToId = (int)comboBox4.SelectedValue;

            cm.ProductId = (int)comboBox5.SelectedValue;
            cm.Amount = Int32.Parse(textBoxAmount.Text);

            cm.Date = dateTimePicker1.Value.Date;


            if (Id == -1)
            {
                MessageBox.Show(query.queryAddContractMove(cm) + "");
            }
            else
            {
                cm.Id = Id;
                MessageBox.Show(query.queryUpdateContractMove(cm) + "");
            }
            this.Dispose();
        }

        private void addDataForUpdate()
        {
            ContractMove c = query.queryFindContractMoveById(Id);
            if (c == null) return;

            dateTimePicker1.Value=c.Date;
            comboBox1.SelectedValue = c.StoreCellFromObj.StorehouseId;
            addStorageCells((int)comboBox1.SelectedValue, comboBox2);
            comboBox2.SelectedValue = c.StoreCellFromId;
            comboBox3.SelectedValue = c.StoreCellToObj.StorehouseId;
            comboBox4.SelectedValue = c.StoreCellToId;
            addStorageCells((int)comboBox3.SelectedValue, comboBox4);
            comboBox5.SelectedValue = c.ProductId;
            textBoxAmount.Text = c.Amount+"";

            oldAm = c.Amount;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int storehouseIdSelected = (int)comboBox1.SelectedValue;
                addStorageCells(storehouseIdSelected, comboBox2);
            }
            catch (Exception ex) { }
        }

        private void addStorageCells(int storehouseIdSelected, ComboBox cb)
        {
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int storehouseIdSelected = (int)comboBox3.SelectedValue;
                addStorageCells(storehouseIdSelected, comboBox4);
            }
            catch (InvalidCastException ex) { }
        }

       
    }
}
