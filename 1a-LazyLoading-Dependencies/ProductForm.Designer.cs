namespace WindowsFormsApplication1
{
    partial class ProductForm
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
            this._logListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _logListBox
            // 
            this._logListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logListBox.FormattingEnabled = true;
            this._logListBox.Location = new System.Drawing.Point(0, 0);
            this._logListBox.Name = "_logListBox";
            this._logListBox.Size = new System.Drawing.Size(425, 328);
            this._logListBox.TabIndex = 2;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 328);
            this.Controls.Add(this._logListBox);
            this.Name = "ProductForm";
            this.Text = "Lazy Loading of Dependencies";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _logListBox;

    }
}

