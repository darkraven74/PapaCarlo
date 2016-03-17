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
    public partial class StorageEditForm : Form
    {
        QueryStore query;

         int Id = -1;

         public StorageEditForm(int Id)
             : this()
        {
            this.Id = Id;
            addDataForUpdate();
        }

        public StorageEditForm()
        {
            InitializeComponent();

            query = new QueryStore();

            this.Text = Properties.Resources.Storage; 
            label1.Text = Properties.Resources.Title;
            label2.Text = Properties.Resources.Address;
            buttonCancel.Text = Properties.Resources.Cancel;
            buttonOK.Text = Properties.Resources.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Storehouse c = new Storehouse();
            c.Name = textBox1.Text;
            c.Address = textBox2.Text;

            if (Id == -1)
            {
                MessageBox.Show(query.queryAddStorehouse(c) + "");
            }
            else
            {
                c.Id = Id;
                MessageBox.Show(query.queryUpdateStorehouse(c) + "");
            }
            this.Dispose();
        }

        private void addDataForUpdate()
        {
            Storehouse c = query.queryFindStorehouseById(Id);
            if (c == null) return;

            textBox1.Text = c.Name;
            textBox2.Text = c.Address;
        }
    }
}
