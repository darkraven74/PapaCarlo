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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            buttonEmployeesList.Text = Properties.Resources.Employees;
            buttonStoragesList.Text = Properties.Resources.Storages;
            buttonCellsList.Text = Properties.Resources.Cells;
            buttonGoodsList.Text = Properties.Resources.Goods;
            buttonContractorsList.Text = Properties.Resources.Contractors;
            AuthorizationForm form = new AuthorizationForm();
            form.ShowDialog();
            this.Text = Properties.Resources.PapaCarlo;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonEmployeesList_Click(object sender, EventArgs e)
        {
            EmployeesListForm f = new EmployeesListForm();
            f.ShowDialog();
        }

        private void buttonStoragesList_Click(object sender, EventArgs e)
        {
            StoragesListForm f = new StoragesListForm();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CellsListForm f = new CellsListForm();
            f.ShowDialog();
        }

        private void buttonGoodsList_Click(object sender, EventArgs e)
        {
            GoodsListForm f = new GoodsListForm();
            f.ShowDialog();
        }

        private void buttonContragentsList_Click(object sender, EventArgs e)
        {
            ContractorsListForm f = new ContractorsListForm();
            f.ShowDialog();
        }
    }
}
