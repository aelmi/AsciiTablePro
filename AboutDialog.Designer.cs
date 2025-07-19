namespace AsciiTablePro
{
    partial class AboutDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.LinkLabel labelReference;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel panelHeader;

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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelReference = new System.Windows.Forms.LinkLabel();
            this.okButton = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(25, 118, 210); // Blue
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 60;
            this.panelHeader.Controls.Add(this.labelTitle);
            // 
            // labelTitle
            // 
            this.labelTitle.Text = "ASCII Table Pro";
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDescription
            // 
            this.labelDescription.Text = "A modern, professional ASCII table viewer for Windows.\r\n\r\n" +
                "Features:\r\n" +
                "• Search, filter, copy, export, and print ASCII characters\r\n" +
                "• Customizable columns and fonts\r\n" +
                "• Color-coded, user-friendly interface\r\n\r\n" +
                "ASCII Table Pro helps you explore all 256 ASCII codes, including control and extended characters, with detailed info and Unicode/HTML references.";
            this.labelDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.labelDescription.BackColor = System.Drawing.Color.FromArgb(232, 245, 253); // Light blue
            this.labelDescription.Location = new System.Drawing.Point(20, 80);
            this.labelDescription.Size = new System.Drawing.Size(440, 160);
            this.labelDescription.AutoSize = false;
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // labelReference
            // 
            this.labelReference.Text = "Reference: ascii-code.com";
            this.labelReference.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.labelReference.LinkColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.labelReference.Location = new System.Drawing.Point(20, 250);
            this.labelReference.Size = new System.Drawing.Size(300, 23);
            this.labelReference.TabStop = true;
            this.labelReference.Links.Add(11, 14, "https://www.ascii-code.com/");
            this.labelReference.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelReference_LinkClicked);
            // 
            // okButton
            // 
            this.okButton.Text = "OK";
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.okButton.BackColor = System.Drawing.Color.FromArgb(76, 175, 80); // Green
            this.okButton.ForeColor = System.Drawing.Color.White;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(190, 290);
            this.okButton.Size = new System.Drawing.Size(100, 35);
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 350);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelReference);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About ASCII Table Pro";
            this.BackColor = System.Drawing.Color.White;
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}