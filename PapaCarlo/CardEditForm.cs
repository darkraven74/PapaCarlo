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
        CardsListForm instance;
        QueryProducts queryProd;

        public CardEditForm(CardsListForm instance, int Id) : this(instance)
        {
            this.Id = Id;
            addDataForUpdate();
        }

        public CardEditForm(CardsListForm instance)
        {
            this.instance = instance;
            InitializeComponent();

            query = new QueryTechnologicalCards();
            queryProd = new QueryProducts();

            this.Text = Properties.Resources.Card;
            label1.Text = Properties.Resources.Title;
            label2.Text = Properties.Resources.InputGoods;
            label3.Text = Properties.Resources.OutputGoods;
            label4.Text = Properties.Resources.Date;
            buttonCancel.Text = Properties.Resources.Cancel;
            labelAmount1.Text = Properties.Resources.Amount;
            labelAmount2.Text = Properties.Resources.Amount;
            buttonOK.Text = Properties.Resources.OK;

            List<ObjectComboBox> lObjPr1 = new List<ObjectComboBox>();

            foreach (var item in queryProd.querySelectProducts())
            {
                lObjPr1.Add(new ObjectComboBox(item.Id, item.Name));
            }

            comboBoxProductsImport.DataSource = lObjPr1;

            comboBoxProductsImport.ValueMember = "Id";
            comboBoxProductsImport.DisplayMember = "Name";

            List<ObjectComboBox> lObjPr2 = new List<ObjectComboBox>();

            foreach (var item in queryProd.querySelectProducts())
            {
                lObjPr2.Add(new ObjectComboBox(item.Id, item.Name));
            }

            comboBoxProductsExport.DataSource = lObjPr2;

            comboBoxProductsExport.ValueMember = "Id";
            comboBoxProductsExport.DisplayMember = "Name"; 
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            TechnologicalCard techCard = new TechnologicalCard();
            techCard.Title = textBox1.Text;
            techCard.Date=dateTimePicker1.Value.Date;
            List<ProductTechCard> productTechCardList = new List<ProductTechCard>();
            ObjectComboBox objPr1 = (ObjectComboBox)comboBoxProductsImport.SelectedItem;
            ProductTechCard product = new ProductTechCard();
            product.ProductId = objPr1.Id;
            int amount = 0;
            Int32.TryParse(textBoxAmountImport.Text, out amount);
            product.Amount = amount;
            product.Type = 1;
            productTechCardList.Add(product);

            product = new ProductTechCard();
            objPr1 = (ObjectComboBox)comboBoxProductsExport.SelectedItem;
            product.ProductId = objPr1.Id;
            amount = 0;
            Int32.TryParse(textBoxAmountExport.Text, out amount);
            product.Amount = amount;
            product.Type = 2;
            productTechCardList.Add(product);
            techCard.ProductTechCards = productTechCardList;
            
            if (Id == -1)
            {
                query.queryAddTechCard(techCard);
            }
            else
            {
                techCard.Id = Id;
                query.queryUpdateTechCard(techCard);
            }
            instance.refreshGrid();
            this.Dispose();
        }

        private void addDataForUpdate()
        {
            TechCardsTable c = query.queryFindTechCardById(Id);
            if (c == null) return;

            textBox1.Text = c.technologicalCard.Title;
            dateTimePicker1.Value = c.technologicalCard.Date;

            for (int i = 0; i < c.productTechCard.Count; i++){
                if (c.productTechCard[i].Type == 1)
                {
                    textBoxAmountImport.Text = c.productTechCard[i].Amount + "";
                    comboBoxProductsImport.SelectedValue = c.productTechCard[i].ProductId;
                }
                else
                {
                    textBoxAmountExport.Text = c.productTechCard[i].Amount + "";
                    comboBoxProductsExport.SelectedValue = c.productTechCard[i].ProductId;
                }
            }
               

        }
    }
}
