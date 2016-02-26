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
    public partial class SuppluContractEditForm : Form
    {
        public SuppluContractEditForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.SupplyContract;
            label1.Text = Properties.Resources.Contractor;
            label2.Text = Properties.Resources.Date;
            label3.Text = Properties.Resources.Goods;
            label4.Text = Properties.Resources.Number;
            buttonCancel.Text = Properties.Resources.Cancel;
            buttonOK.Text = Properties.Resources.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
