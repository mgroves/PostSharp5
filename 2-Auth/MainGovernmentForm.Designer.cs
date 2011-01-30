namespace Auth
{
    partial class MainGovernmentForm
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
            this.formTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.allformsListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.submitFormButton = new System.Windows.Forms.Button();
            this.viewformButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formTextbox
            // 
            this.formTextbox.Location = new System.Drawing.Point(13, 55);
            this.formTextbox.Multiline = true;
            this.formTextbox.Name = "formTextbox";
            this.formTextbox.Size = new System.Drawing.Size(371, 201);
            this.formTextbox.TabIndex = 0;
            this.formTextbox.Text = "Put the form information here.  This would normally be a long sequence of individ" +
                "ual textboxes, dropdowns, etc.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fill out the form:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "All submitted forms:";
            // 
            // allformsListview
            // 
            this.allformsListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.allformsListview.FullRowSelect = true;
            this.allformsListview.Location = new System.Drawing.Point(16, 334);
            this.allformsListview.Name = "allformsListview";
            this.allformsListview.Size = new System.Drawing.Size(368, 149);
            this.allformsListview.TabIndex = 4;
            this.allformsListview.UseCompatibleStateImageBehavior = false;
            this.allformsListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "User";
            this.columnHeader2.Width = 150;
            // 
            // submitFormButton
            // 
            this.submitFormButton.Location = new System.Drawing.Point(402, 55);
            this.submitFormButton.Name = "submitFormButton";
            this.submitFormButton.Size = new System.Drawing.Size(75, 23);
            this.submitFormButton.TabIndex = 5;
            this.submitFormButton.Text = "Submit Form";
            this.submitFormButton.UseVisualStyleBackColor = true;
            this.submitFormButton.Click += new System.EventHandler(this.submitformButton_Click);
            // 
            // viewformButton
            // 
            this.viewformButton.Location = new System.Drawing.Point(402, 334);
            this.viewformButton.Name = "viewformButton";
            this.viewformButton.Size = new System.Drawing.Size(75, 23);
            this.viewformButton.TabIndex = 6;
            this.viewformButton.Text = "View";
            this.viewformButton.UseVisualStyleBackColor = true;
            this.viewformButton.Click += new System.EventHandler(this.viewformButton_Click);
            // 
            // MainGovernmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 495);
            this.Controls.Add(this.viewformButton);
            this.Controls.Add(this.submitFormButton);
            this.Controls.Add(this.allformsListview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.formTextbox);
            this.Name = "MainGovernmentForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox formTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView allformsListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button submitFormButton;
        private System.Windows.Forms.Button viewformButton;
    }
}

