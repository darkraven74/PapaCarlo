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
    public partial class GoodEditForm : Form
    {
        public GoodEditForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Good;
            label1.Text = Properties.Resources.Title;
            label2.Text = Properties.Resources.ID;
            label3.Text = Properties.Resources.VendorCode;
            label4.Text = Properties.Resources.Description;
            label5.Text = Properties.Resources.Color;
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
