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
    public partial class CellEditForm : Form
    {
        public CellEditForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Cell;

            label1.Text = Properties.Resources.Storage;
            label2.Text = Properties.Resources.Description;

            comboBox1.DataSource = new List<String> { "Склад 1",
                "Главный склад", "Склад в Пулково" };

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
