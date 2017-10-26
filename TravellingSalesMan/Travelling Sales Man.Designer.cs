namespace TravellingSalesMan
{
    partial class Travelling_Sales_Man
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCities = new System.Windows.Forms.TextBox();
            this.ddStrategies = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ddCostFunctions = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMeb = new System.Windows.Forms.TextBox();
            this.lblCityError = new System.Windows.Forms.Label();
            this.lblMEBErr = new System.Windows.Forms.Label();
            this.lblResultMessage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Cities";
            // 
            // txtCities
            // 
            this.txtCities.Location = new System.Drawing.Point(323, 18);
            this.txtCities.Name = "txtCities";
            this.txtCities.Size = new System.Drawing.Size(195, 20);
            this.txtCities.TabIndex = 1;
            // 
            // ddStrategies
            // 
            this.ddStrategies.FormattingEnabled = true;
            this.ddStrategies.Items.AddRange(new object[] {
            "SIMP - Nearest Neighbour",
            "SOPH - Branch and Bound"});
            this.ddStrategies.Location = new System.Drawing.Point(323, 66);
            this.ddStrategies.Name = "ddStrategies";
            this.ddStrategies.Size = new System.Drawing.Size(195, 21);
            this.ddStrategies.TabIndex = 2;
            this.ddStrategies.SelectedIndexChanged += new System.EventHandler(this.ddStrategies_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search Strategy";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Compute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ddCostFunctions
            // 
            this.ddCostFunctions.FormattingEnabled = true;
            this.ddCostFunctions.Location = new System.Drawing.Point(323, 112);
            this.ddCostFunctions.Name = "ddCostFunctions";
            this.ddCostFunctions.Size = new System.Drawing.Size(195, 21);
            this.ddCostFunctions.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cost function";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "MEB";
            // 
            // txtMeb
            // 
            this.txtMeb.Location = new System.Drawing.Point(323, 164);
            this.txtMeb.Name = "txtMeb";
            this.txtMeb.Size = new System.Drawing.Size(195, 20);
            this.txtMeb.TabIndex = 0;
            // 
            // lblCityError
            // 
            this.lblCityError.AutoSize = true;
            this.lblCityError.Location = new System.Drawing.Point(320, 42);
            this.lblCityError.Name = "lblCityError";
            this.lblCityError.Size = new System.Drawing.Size(83, 13);
            this.lblCityError.TabIndex = 9;
            this.lblCityError.Text = "Enter valid input";
            // 
            // lblMEBErr
            // 
            this.lblMEBErr.AutoSize = true;
            this.lblMEBErr.Location = new System.Drawing.Point(320, 187);
            this.lblMEBErr.Name = "lblMEBErr";
            this.lblMEBErr.Size = new System.Drawing.Size(83, 13);
            this.lblMEBErr.TabIndex = 10;
            this.lblMEBErr.Text = "Enter valid input";
            // 
            // lblResultMessage
            // 
            this.lblResultMessage.AutoSize = true;
            this.lblResultMessage.Location = new System.Drawing.Point(323, 278);
            this.lblResultMessage.Name = "lblResultMessage";
            this.lblResultMessage.Size = new System.Drawing.Size(0, 13);
            this.lblResultMessage.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Output has been written to";
            this.label5.Visible = false;
            // 
            // Travelling_Sales_Man
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 495);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblResultMessage);
            this.Controls.Add(this.lblMEBErr);
            this.Controls.Add(this.lblCityError);
            this.Controls.Add(this.txtMeb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddCostFunctions);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddStrategies);
            this.Controls.Add(this.txtCities);
            this.Controls.Add(this.label1);
            this.Name = "Travelling_Sales_Man";
            this.Text = "Travelling Sales Man";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCities;
        private System.Windows.Forms.ComboBox ddStrategies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ddCostFunctions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMeb;
        private System.Windows.Forms.Label lblCityError;
        private System.Windows.Forms.Label lblMEBErr;
        private System.Windows.Forms.Label lblResultMessage;
        private System.Windows.Forms.Label label5;
    }
}

