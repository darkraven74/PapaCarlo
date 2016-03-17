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
    public partial class GoodEditForm : Form
    {
         QueryProducts query;

         int Id = -1;

         public GoodEditForm(int Id)
             : this()
        {
            this.Id = Id;
            addDataForUpdate();
        }

        public GoodEditForm()
        {
            InitializeComponent();

            query = new QueryProducts();

            this.Text = Properties.Resources.Good;
            label2.Text = Properties.Resources.Title;
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
            Product c = new Product();
            c.Name = textBox2.Text;
            c.VendorCode = Int32.Parse(textBox3.Text);
            c.Description = textBox4.Text;
            c.Color = textBox5.Text;

            if (Id == -1)
            {
                MessageBox.Show(query.queryAddProduct(c) + "");
            }
            else
            {
                c.Id = Id;
                MessageBox.Show(query.queryUpdateProduct(c) + "");
            }
            this.Dispose();
        }

        private void addDataForUpdate()
        {
            Product c = query.queryFindProductById(Id);
            if (c == null) return;

            textBox2.Text = c.Name;
            textBox3.Text = c.VendorCode+"";
            textBox4.Text = c.Description;
            textBox5.Text = c.Color;
        }


       
    }
}
