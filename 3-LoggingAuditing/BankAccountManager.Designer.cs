namespace LoggingAuditing
{
    partial class BankAccountManager
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
            this.depositButton = new System.Windows.Forms.Button();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.amountTextbox = new System.Windows.Forms.TextBox();
            this.withdrawlButton = new System.Windows.Forms.Button();
            this.creditButton = new System.Windows.Forms.Button();
            this.feeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.logListbox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // depositButton
            // 
            this.depositButton.Location = new System.Drawing.Point(40, 151);
            this.depositButton.Name = "depositButton";
            this.depositButton.Size = new System.Drawing.Size(75, 23);
            this.depositButton.TabIndex = 0;
            this.depositButton.Text = "Deposit";
            this.depositButton.UseVisualStyleBackColor = true;
            this.depositButton.Click += new System.EventHandler(this.depositButton_Click);
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Location = new System.Drawing.Point(37, 40);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(35, 13);
            this.balanceLabel.TabIndex = 1;
            this.balanceLabel.Text = "label1";
            // 
            // amountTextbox
            // 
            this.amountTextbox.Location = new System.Drawing.Point(40, 125);
            this.amountTextbox.Name = "amountTextbox";
            this.amountTextbox.Size = new System.Drawing.Size(194, 20);
            this.amountTextbox.TabIndex = 2;
            // 
            // withdrawlButton
            // 
            this.withdrawlButton.Location = new System.Drawing.Point(40, 181);
            this.withdrawlButton.Name = "withdrawlButton";
            this.withdrawlButton.Size = new System.Drawing.Size(75, 23);
            this.withdrawlButton.TabIndex = 3;
            this.withdrawlButton.Text = "Withdrawl";
            this.withdrawlButton.UseVisualStyleBackColor = true;
            this.withdrawlButton.Click += new System.EventHandler(this.withdrawlButton_Click);
            // 
            // creditButton
            // 
            this.creditButton.Location = new System.Drawing.Point(40, 211);
            this.creditButton.Name = "creditButton";
            this.creditButton.Size = new System.Drawing.Size(75, 23);
            this.creditButton.TabIndex = 4;
            this.creditButton.Text = "Credit";
            this.creditButton.UseVisualStyleBackColor = true;
            this.creditButton.Click += new System.EventHandler(this.creditButton_Click);
            // 
            // feeButton
            // 
            this.feeButton.Location = new System.Drawing.Point(40, 241);
            this.feeButton.Name = "feeButton";
            this.feeButton.Size = new System.Drawing.Size(75, 23);
            this.feeButton.TabIndex = 5;
            this.feeButton.Text = "Fee";
            this.feeButton.UseVisualStyleBackColor = true;
            this.feeButton.Click += new System.EventHandler(this.feeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current Balance";
            // 
            // logListbox
            // 
            this.logListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logListbox.FormattingEnabled = true;
            this.logListbox.Location = new System.Drawing.Point(309, 40);
            this.logListbox.Name = "logListbox";
            this.logListbox.Size = new System.Drawing.Size(256, 277);
            this.logListbox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Log";
            // 
            // BankAccountManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 324);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logListbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.feeButton);
            this.Controls.Add(this.creditButton);
            this.Controls.Add(this.withdrawlButton);
            this.Controls.Add(this.amountTextbox);
            this.Controls.Add(this.balanceLabel);
            this.Controls.Add(this.depositButton);
            this.Name = "BankAccountManager";
            this.Text = "BankAccountManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button depositButton;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.TextBox amountTextbox;
        private System.Windows.Forms.Button withdrawlButton;
        private System.Windows.Forms.Button creditButton;
        private System.Windows.Forms.Button feeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox logListbox;
        private System.Windows.Forms.Label label1;

    }
}

