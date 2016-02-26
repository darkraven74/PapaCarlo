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
    public partial class OperationEditForm : Form
    {
        public OperationEditForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Operation;
            label1.Text = Properties.Resources.ID;
            label2.Text = Properties.Resources.Date;
            label3.Text = Properties.Resources.Card;
            label4.Text = Properties.Resources.Count;
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
