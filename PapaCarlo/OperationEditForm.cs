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
    public partial class OperationEditForm : Form
    {
         QueryContractTechOperations query;

         int Id = -1;

         OperationsListForm instance;

         public OperationEditForm(OperationsListForm instance, int Id)
             : this(instance)
        {
            this.Id = Id;
            addDataForUpdate();
        }

         public OperationEditForm(OperationsListForm instance)
        {
             this.instance = instance;
             
             InitializeComponent();

            query = new QueryContractTechOperations();

            this.Text = Properties.Resources.Operation;
            label1.Text = Properties.Resources.ID;
            label2.Text = Properties.Resources.Date;
            label3.Text = Properties.Resources.Card;
            label4.Text = Properties.Resources.Count;
            buttonCancel.Text = Properties.Resources.Cancel;
            buttonOK.Text = Properties.Resources.OK;
        }

        private void addDataForUpdate()
        {
            ContractTechOperation c = query.queryFindContractTechOperationById(Id);
            if (c == null) return;

            dateTimePicker1.Value = c.Date;
            textBox1.Text = c.Id + "";
            textBox2.Text = c.TechCardId+"";
            textBox3.Text = c.Amount + "";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ContractTechOperation c = new ContractTechOperation();
            c.TechCardId =Int32.Parse(textBox2.Text);
            c.Amount = Int32.Parse(textBox3.Text);

            c.Date = dateTimePicker1.Value.Date;
            if (Id == -1)
            {
                query.queryAddContractTechOperation(c);
            }
            else
            {
                c.Id = Id;
                query.queryUpdateContractTechOperation(c);
            }
            instance.refreshGrid();
            this.Dispose();
        }
    }
}
