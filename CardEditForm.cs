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
    public partial class CardEditForm : Form
    {
        public CardEditForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Card;
            label1.Text = Properties.Resources.Title;
            label2.Text = Properties.Resources.InputGoods;
            label3.Text = Properties.Resources.OutputGoods;
            label4.Text = Properties.Resources.ID;
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
