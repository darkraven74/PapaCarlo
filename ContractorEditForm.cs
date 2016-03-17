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

namespace PapaCarlo
{
    public partial class ContractorEditForm : Form
    {
        QueryContractors query; 
        int Id = -1;

        public ContractorEditForm(int Id) : this()
        {
            this.Id = Id;
            addDataForUpdate();
        }

        public ContractorEditForm()
        {
            InitializeComponent();

            query = new QueryContractors();

            this.Text = Properties.Resources.Contractor;

            label1.Text = Properties.Resources.ContractorType;
            label2.Text = Properties.Resources.Title;

            comboBox1.DataSource = new List<String> { Properties.Resources.Customer, Properties.Resources.Provider};

            buttonCancel.Text = Properties.Resources.Cancel;
            buttonOK.Text = Properties.Resources.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Contractor c = new Contractor();
            c.Name = textBox2.Text;
            c.Type = comboBox1.SelectedIndex + 1;
            if (Id == -1)
            {
                 MessageBox.Show(query.queryAddContractor(c)+"");
            }
            else
            {
                c.Id = Id;
                 MessageBox.Show(query.queryUpdateContractor(c)+"");
            }
            this.Dispose();
        }

        private void addDataForUpdate()
        {
            Contractor c = query.queryFindContractorById(Id);
            if (c == null) return;
            
            textBox2.Text = c.Name;
            comboBox1.SelectedIndex = c.Type - 1;
        }
    }
}
