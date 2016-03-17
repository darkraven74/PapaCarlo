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
    public partial class CardEditForm : Form
    {
        QueryTechnologicalCards query; 
        int Id = -1;

        public CardEditForm(int Id) : this()
        {
            this.Id = Id;
            addDataForUpdate();
        }

        public CardEditForm()
        {
            InitializeComponent();

            query = new QueryTechnologicalCards();

            this.Text = Properties.Resources.Card;
            label1.Text = Properties.Resources.Title;
            label2.Text = Properties.Resources.InputGoods;
            label3.Text = Properties.Resources.OutputGoods;
            label4.Text = Properties.Resources.Date;
            buttonCancel.Text = Properties.Resources.Cancel;
            buttonOK.Text = Properties.Resources.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            TechnologicalCard tc = new TechnologicalCard();
            tc.Title = textBox1.Text;
            tc.Date=dateTimePicker1.Value.Date;
            List<ProductTechCard> ptc = new List<ProductTechCard>();
            
            if (Id == -1)
            {
                MessageBox.Show(query.queryAddTechCard(tc,ptc) + "");
            }
            else
            {
                tc.Id = Id;
                MessageBox.Show(query.queryUpdateTechCard(tc, ptc) + "");
            }
            this.Dispose();
        }

        private void addDataForUpdate()
        {
            TechCardsTable c = query.queryFindTechCardById(Id);
            if (c == null) return;

            textBox1.Text = c.technologicalCard.Title;
            dateTimePicker1.Value = c.technologicalCard.Date;
        }
    }
}
