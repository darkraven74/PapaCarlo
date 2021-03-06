﻿using System;
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
            buttonCardsList.Text = Properties.Resources.Cards;
           // buttonSupplyContracts.Text = Properties.Resources.SupplyContracts;
            buttonSupplyList.Text = Properties.Resources.Supplies;
            buttonMovementsList.Text = Properties.Resources.Movements;
            buttonShipmentsList.Text = Properties.Resources.Shipments;
            buttonOperationsList.Text = Properties.Resources.Operations;
            buttonBalance.Text = Properties.Resources.Balance;
            buttonPrediction.Text = Properties.Resources.Predict;
           
            this.Text = Properties.Resources.PapaCarlo;
            if (LoginInfo.Position == 1)//Начальник
            {
                SupplyListForm f = new SupplyListForm();
                f.ShowDialog();
            }
            else if (LoginInfo.Position == 2)//Бухгалтер
            {
                BalanceForm f = new BalanceForm();
                f.ShowDialog();
            }
            else if (LoginInfo.Position == 3)//Кладовщик
            {
                MovementsListForm f = new MovementsListForm();
                f.ShowDialog();
            }
            showButtonsForPosition();
            
        }

        private void showButtonsForPosition()
        {
            if (LoginInfo.Position == 1)//Начальник
            {
                buttonEmployeesList.Enabled = true;
                buttonStoragesList.Enabled = true;
                buttonCellsList.Enabled = true;
                buttonGoodsList.Enabled = true;
                buttonContractorsList.Enabled = true;
                buttonCardsList.Enabled = true;
                buttonSupplyList.Enabled = true;
                buttonMovementsList.Enabled = true;
                buttonShipmentsList.Enabled = true;
                buttonOperationsList.Enabled = true;
                buttonBalance.Enabled = true;
                buttonPrediction.Enabled = true;
            }
            else if (LoginInfo.Position == 2)//Бухгалтер
            {
                buttonEmployeesList.Enabled = true;
                buttonStoragesList.Enabled = true;
                buttonCellsList.Enabled = true;
                buttonGoodsList.Enabled = true;
                buttonContractorsList.Enabled = true;
                buttonCardsList.Enabled = true;
                buttonBalance.Enabled = true;
                buttonPrediction.Enabled = true;
            }
            else if (LoginInfo.Position == 3)//Кладовщик
            {
                buttonStoragesList.Enabled = true;
                buttonCellsList.Enabled = true;
                buttonCardsList.Enabled = true;
                buttonSupplyList.Enabled = true;
                buttonMovementsList.Enabled = true;
                buttonShipmentsList.Enabled = true;
                buttonOperationsList.Enabled = true;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            CardsListForm f = new CardsListForm();
            f.ShowDialog();
        }

        private void buttonSupplyContracts_Click(object sender, EventArgs e)
        {
            SupplyContractsListForm f = new SupplyContractsListForm();
            f.ShowDialog();
        }

        private void buttonSupplyList_Click(object sender, EventArgs e)
        {
            SupplyListForm f = new SupplyListForm();
            f.ShowDialog();
        }

        private void buttonMovementsList_Click(object sender, EventArgs e)
        {
            MovementsListForm f = new MovementsListForm();
            f.ShowDialog();
        }

        private void buttonShipmentsList_Click(object sender, EventArgs e)
        {
            ShipmentsListForm f = new ShipmentsListForm();
            f.ShowDialog();
        }

        private void buttonOperationsList_Click(object sender, EventArgs e)
        {
            OperationsListForm f = new OperationsListForm();
            f.ShowDialog();
        }

        private void buttonBalance_Click(object sender, EventArgs e)
        {
            BalanceForm f = new BalanceForm();
            f.ShowDialog();
        }

        private void buttonPrediction_Click(object sender, EventArgs e)
        {
            BalancePredictionForm f = new BalancePredictionForm();
            f.ShowDialog();
        }
    }
}
