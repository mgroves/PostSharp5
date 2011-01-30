namespace Caching
{
    partial class CarDealership
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
            this.makemodelDropdown = new System.Windows.Forms.ComboBox();
            this.yearDropdown = new System.Windows.Forms.ComboBox();
            this.bluebookButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBluebookValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // makemodelDropdown
            // 
            this.makemodelDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makemodelDropdown.FormattingEnabled = true;
            this.makemodelDropdown.Location = new System.Drawing.Point(28, 49);
            this.makemodelDropdown.Name = "makemodelDropdown";
            this.makemodelDropdown.Size = new System.Drawing.Size(174, 21);
            this.makemodelDropdown.TabIndex = 0;
            // 
            // yearDropdown
            // 
            this.yearDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearDropdown.FormattingEnabled = true;
            this.yearDropdown.Location = new System.Drawing.Point(28, 89);
            this.yearDropdown.Name = "yearDropdown";
            this.yearDropdown.Size = new System.Drawing.Size(121, 21);
            this.yearDropdown.TabIndex = 1;
            // 
            // bluebookButton
            // 
            this.bluebookButton.Location = new System.Drawing.Point(28, 144);
            this.bluebookButton.Name = "bluebookButton";
            this.bluebookButton.Size = new System.Drawing.Size(121, 23);
            this.bluebookButton.TabIndex = 2;
            this.bluebookButton.Text = "Get Blue Book Value";
            this.bluebookButton.UseVisualStyleBackColor = true;
            this.bluebookButton.Click += new System.EventHandler(this.bluebookButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Make and Model";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Year";
            // 
            // txtBluebookValue
            // 
            this.txtBluebookValue.Location = new System.Drawing.Point(26, 243);
            this.txtBluebookValue.Name = "txtBluebookValue";
            this.txtBluebookValue.ReadOnly = true;
            this.txtBluebookValue.Size = new System.Drawing.Size(138, 20);
            this.txtBluebookValue.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Blue Book Value";
            // 
            // CarDealership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 344);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBluebookValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bluebookButton);
            this.Controls.Add(this.yearDropdown);
            this.Controls.Add(this.makemodelDropdown);
            this.Name = "CarDealership";
            this.Text = "CarDealership";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox makemodelDropdown;
        private System.Windows.Forms.ComboBox yearDropdown;
        private System.Windows.Forms.Button bluebookButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBluebookValue;
        private System.Windows.Forms.Label label3;
    }
}

