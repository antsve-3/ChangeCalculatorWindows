namespace ChangeCalculatorWindows
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPrice = new System.Windows.Forms.TextBox();
            this.tbxPaid = new System.Windows.Forms.TextBox();
            this.btnChangeCalculation = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ange pris:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Betalt:";
            // 
            // tbxPrice
            // 
            this.tbxPrice.Location = new System.Drawing.Point(36, 45);
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.Size = new System.Drawing.Size(100, 20);
            this.tbxPrice.TabIndex = 2;
            this.tbxPrice.TextChanged += new System.EventHandler(this.tbxPrice_TextChanged);
            // 
            // tbxPaid
            // 
            this.tbxPaid.Location = new System.Drawing.Point(36, 93);
            this.tbxPaid.Name = "tbxPaid";
            this.tbxPaid.Size = new System.Drawing.Size(100, 20);
            this.tbxPaid.TabIndex = 3;
            this.tbxPaid.TextChanged += new System.EventHandler(this.tbxPaid_TextChanged);
            // 
            // btnChangeCalculation
            // 
            this.btnChangeCalculation.Location = new System.Drawing.Point(36, 128);
            this.btnChangeCalculation.Name = "btnChangeCalculation";
            this.btnChangeCalculation.Size = new System.Drawing.Size(100, 23);
            this.btnChangeCalculation.TabIndex = 4;
            this.btnChangeCalculation.Text = "Räkna ut växel";
            this.btnChangeCalculation.UseVisualStyleBackColor = true;
            this.btnChangeCalculation.Click += new System.EventHandler(this.btnChangeCalculation_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(299, 29);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(35, 13);
            this.lblOutput.TabIndex = 5;
            this.lblOutput.Text = "label3";
            this.lblOutput.Visible = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(33, 211);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(35, 13);
            this.lblError.TabIndex = 6;
            this.lblError.Text = "label3";
            this.lblError.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(36, 167);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Nollställ";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnChangeCalculation);
            this.Controls.Add(this.tbxPaid);
            this.Controls.Add(this.tbxPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Change Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxPrice;
        private System.Windows.Forms.TextBox tbxPaid;
        private System.Windows.Forms.Button btnChangeCalculation;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnClear;
    }
}

