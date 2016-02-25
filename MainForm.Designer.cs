namespace PapaCarlo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonEmployeesList = new System.Windows.Forms.Button();
            this.buttonStoragesList = new System.Windows.Forms.Button();
            this.buttonCellsList = new System.Windows.Forms.Button();
            this.buttonGoodsList = new System.Windows.Forms.Button();
            this.buttonContractorsList = new System.Windows.Forms.Button();
            this.buttonCardsList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEmployeesList
            // 
            this.buttonEmployeesList.Location = new System.Drawing.Point(13, 13);
            this.buttonEmployeesList.Name = "buttonEmployeesList";
            this.buttonEmployeesList.Size = new System.Drawing.Size(85, 23);
            this.buttonEmployeesList.TabIndex = 0;
            this.buttonEmployeesList.Text = "button1";
            this.buttonEmployeesList.UseVisualStyleBackColor = true;
            this.buttonEmployeesList.Click += new System.EventHandler(this.buttonEmployeesList_Click);
            // 
            // buttonStoragesList
            // 
            this.buttonStoragesList.Location = new System.Drawing.Point(13, 43);
            this.buttonStoragesList.Name = "buttonStoragesList";
            this.buttonStoragesList.Size = new System.Drawing.Size(85, 23);
            this.buttonStoragesList.TabIndex = 1;
            this.buttonStoragesList.Text = "button2";
            this.buttonStoragesList.UseVisualStyleBackColor = true;
            this.buttonStoragesList.Click += new System.EventHandler(this.buttonStoragesList_Click);
            // 
            // buttonCellsList
            // 
            this.buttonCellsList.Location = new System.Drawing.Point(13, 72);
            this.buttonCellsList.Name = "buttonCellsList";
            this.buttonCellsList.Size = new System.Drawing.Size(85, 23);
            this.buttonCellsList.TabIndex = 2;
            this.buttonCellsList.Text = "button3";
            this.buttonCellsList.UseVisualStyleBackColor = true;
            this.buttonCellsList.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonGoodsList
            // 
            this.buttonGoodsList.Location = new System.Drawing.Point(13, 101);
            this.buttonGoodsList.Name = "buttonGoodsList";
            this.buttonGoodsList.Size = new System.Drawing.Size(85, 23);
            this.buttonGoodsList.TabIndex = 3;
            this.buttonGoodsList.Text = "button4";
            this.buttonGoodsList.UseVisualStyleBackColor = true;
            this.buttonGoodsList.Click += new System.EventHandler(this.buttonGoodsList_Click);
            // 
            // buttonContractorsList
            // 
            this.buttonContractorsList.Location = new System.Drawing.Point(13, 130);
            this.buttonContractorsList.Name = "buttonContractorsList";
            this.buttonContractorsList.Size = new System.Drawing.Size(85, 23);
            this.buttonContractorsList.TabIndex = 4;
            this.buttonContractorsList.Text = "button5";
            this.buttonContractorsList.UseVisualStyleBackColor = true;
            this.buttonContractorsList.Click += new System.EventHandler(this.buttonContragentsList_Click);
            // 
            // buttonCardsList
            // 
            this.buttonCardsList.Location = new System.Drawing.Point(12, 159);
            this.buttonCardsList.Name = "buttonCardsList";
            this.buttonCardsList.Size = new System.Drawing.Size(85, 23);
            this.buttonCardsList.TabIndex = 5;
            this.buttonCardsList.Text = "button6";
            this.buttonCardsList.UseVisualStyleBackColor = true;
            this.buttonCardsList.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonCardsList);
            this.Controls.Add(this.buttonContractorsList);
            this.Controls.Add(this.buttonGoodsList);
            this.Controls.Add(this.buttonCellsList);
            this.Controls.Add(this.buttonStoragesList);
            this.Controls.Add(this.buttonEmployeesList);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEmployeesList;
        private System.Windows.Forms.Button buttonStoragesList;
        private System.Windows.Forms.Button buttonCellsList;
        private System.Windows.Forms.Button buttonGoodsList;
        private System.Windows.Forms.Button buttonContractorsList;
        private System.Windows.Forms.Button buttonCardsList;
    }
}