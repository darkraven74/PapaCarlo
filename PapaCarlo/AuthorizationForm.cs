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
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Authorization;
            labelLogin.Text = Properties.Resources.Login;
            labelPassword.Text = Properties.Resources.Password;
            textBoxLogin.Text = "user";
            textBoxPassword.Text = "1234";
            textBoxPassword.UseSystemPasswordChar = true;
            buttonEnter.Text = Properties.Resources.Enter;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            QueryEmployee pr = new QueryEmployee();
            Employee currentEmployee = pr.queryGetUserByCredentials(textBoxLogin.Text, textBoxPassword.Text)[0];

            LoginInfo.UserID = currentEmployee.Id;
            LoginInfo.Position = currentEmployee.PositionId;

            this.Visible = false;
            MainForm f = new MainForm();
            f.ShowDialog();
            this.Dispose();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
