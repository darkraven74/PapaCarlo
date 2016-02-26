﻿using System;
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
    public partial class MovementEditForm : Form
    {
        public MovementEditForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Movement;
            label1.Text = Properties.Resources.ID;
            label2.Text = Properties.Resources.Date;
            label3.Text = Properties.Resources.FromStorage;
            label4.Text = Properties.Resources.FromCell;
            label6.Text = Properties.Resources.ToStorage;
            label5.Text = Properties.Resources.ToCell;
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