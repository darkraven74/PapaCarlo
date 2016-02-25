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
    public partial class ContractorEditForm : Form
    {
        public ContractorEditForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Contractor;

            label1.Text = Properties.Resources.ContractorType;
            label2.Text = Properties.Resources.Title;

            comboBox1.DataSource = new List<String> { Properties.Resources.Provider, Properties.Resources.Customer };

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
