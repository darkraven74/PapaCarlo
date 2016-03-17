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
    public partial class SuppluEditForm : Form
    {
         QueryContractSupply query;
         QueryProducts queryProd;
         QueryContractors queryContractors;

         int Id = -1;

         public SuppluEditForm(int Id)
             : this()
        {
            this.Id = Id;
            addDataForUpdate();
        }

    
    public SuppluEditForm()
        {
            InitializeComponent();

            query = new QueryContractSupply();
            queryProd = new QueryProducts();
            queryContractors = new QueryContractors();

            this.Text = Properties.Resources.Supply;
            labelId.Text = Properties.Resources.SupplyContract;
            label2.Text = Properties.Resources.Date;
            label3.Text = Properties.Resources.Goods;
            label4.Text = Properties.Resources.Number;
            labelAmount.Text = Properties.Resources.Amount;
            labelWasReceived.Text = Properties.Resources.Received;
            labelContractors.Text = Properties.Resources.Contractor;

            buttonCancel.Text = Properties.Resources.Cancel;
            buttonOK.Text = Properties.Resources.OK;

            ArrayList lObjPr = new ArrayList();
            foreach (var item in queryProd.querySelectProducts())
            {
                lObjPr.Add(new { Id = item.Id, Name = item.Name });
            }

            comboBoxProducts.DataSource = lObjPr;
            comboBoxProducts.ValueMember = "Id";
            comboBoxProducts.DisplayMember = "Name";

            List<bool> lObjBool = new List<bool>{ true, false };
            comboBoxWasReceived.DataSource = lObjBool;

            ArrayList lObjContr = new ArrayList();
            foreach (var item in queryContractors.querySelectContractors(2))
            {
                lObjContr.Add(new { Id = item.Id, Name = item.Name });
            }

            comboBoxContractors.DataSource = lObjContr;
            comboBoxContractors.ValueMember = "Id";
            comboBoxContractors.DisplayMember = "Name";

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ContractSupply c = new ContractSupply();

            List<SupplyProduct> lsp = new List<SupplyProduct>();
            SupplyProduct sp=new SupplyProduct();  

            c.wasReceived = (bool)comboBoxWasReceived.SelectedValue;
            c.numberOfSupply =  Int32.Parse(textBox2.Text);
            c.ContractorId = (int)comboBoxContractors.SelectedValue;
            sp.ProductId = (int)comboBoxProducts.SelectedValue;
            sp.Amount = Int32.Parse(textBoxAmount.Text);
            lsp.Add(sp);
            c.SupplyProducts = lsp;
            c.Date = dateTimePicker1.Value.Date;
            if (Id == -1)
            {
                MessageBox.Show(query.queryAddContractSupply(c) + "");
            }
            else
            {
                c.Id = Id;
                MessageBox.Show(query.queryUpdateContractSupply(c) + "");
            }
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addDataForUpdate()
        {
            ContractSupply c = query.queryFindContractSupplyById(Id);
            if (c == null) return;

          /*  dateTimePicker1.Value = c.contractSupply.Date;
            if (c.productList[0].ProductObj != null && c.productList[0].Amount != null)
            {
                comboBoxProducts.SelectedValue = c.productList[0].ProductObj;
                textBoxAmount.Text = c.productList[0].Amount+"";
            }
           
            textBox2.Text = c.contractSupply.numberOfSupply+"";
            comboBoxWasReceived.SelectedValue = c.contractSupply.wasReceived;*/

            dateTimePicker1.Value = c.Date;
            if (c.SupplyProducts[0]!= null)
            {
                comboBoxProducts.SelectedValue = c.SupplyProducts[0].ProductId;
                textBoxAmount.Text = c.SupplyProducts[0].Amount + "";
            }
            textBox1.Text = c.Id+"";
            textBox2.Text = c.numberOfSupply + "";
            comboBoxContractors.SelectedValue = c.ContractorId;
            //comboBoxWasReceived.SelectedValue = c.wasReceived;
        }
    }
}
