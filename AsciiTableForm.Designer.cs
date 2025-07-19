namespace AsciiTablePro
{
    partial class AsciiTableForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView asciiDataGridView;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem columnsMenu;
        private System.Windows.Forms.ComboBox searchColumnComboBox;
        private System.Windows.Forms.ContextMenuStrip rowContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyCodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCharMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyDescMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.asciiDataGridView = new System.Windows.Forms.DataGridView();
            this.rowContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCharMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDescMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchColumnComboBox = new System.Windows.Forms.ComboBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.fontButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.columnsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.asciiDataGridView)).BeginInit();
            this.rowContextMenu.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // asciiDataGridView
            // 
            this.asciiDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.asciiDataGridView.ColumnHeadersHeight = 34;
            this.asciiDataGridView.ContextMenuStrip = this.rowContextMenu;
            this.asciiDataGridView.Location = new System.Drawing.Point(0, 161);
            this.asciiDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.asciiDataGridView.Name = "asciiDataGridView";
            this.asciiDataGridView.RowHeadersWidth = 62;
            this.asciiDataGridView.Size = new System.Drawing.Size(1508, 589);
            this.asciiDataGridView.TabIndex = 1;
            // 
            // rowContextMenu
            // 
            this.rowContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.rowContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCodeMenuItem,
            this.copyCharMenuItem,
            this.copyDescMenuItem});
            this.rowContextMenu.Name = "rowContextMenu";
            this.rowContextMenu.Size = new System.Drawing.Size(222, 100);
            // 
            // copyCodeMenuItem
            // 
            this.copyCodeMenuItem.Name = "copyCodeMenuItem";
            this.copyCodeMenuItem.Size = new System.Drawing.Size(221, 32);
            this.copyCodeMenuItem.Text = "Copy Code";
            this.copyCodeMenuItem.Click += new System.EventHandler(this.copyCodeMenuItem_Click);
            // 
            // copyCharMenuItem
            // 
            this.copyCharMenuItem.Name = "copyCharMenuItem";
            this.copyCharMenuItem.Size = new System.Drawing.Size(221, 32);
            this.copyCharMenuItem.Text = "Copy Character";
            this.copyCharMenuItem.Click += new System.EventHandler(this.copyCharMenuItem_Click);
            // 
            // copyDescMenuItem
            // 
            this.copyDescMenuItem.Name = "copyDescMenuItem";
            this.copyDescMenuItem.Size = new System.Drawing.Size(221, 32);
            this.copyDescMenuItem.Text = "Copy Description";
            this.copyDescMenuItem.Click += new System.EventHandler(this.copyDescMenuItem_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 33);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1508, 75);
            this.headerPanel.TabIndex = 3;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(1508, 75);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "ASCII Table Pro";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.White;
            this.controlPanel.Controls.Add(this.searchLabel);
            this.controlPanel.Controls.Add(this.searchTextBox);
            this.controlPanel.Controls.Add(this.searchColumnComboBox);
            this.controlPanel.Controls.Add(this.copyButton);
            this.controlPanel.Controls.Add(this.exportButton);
            this.controlPanel.Controls.Add(this.fontButton);
            this.controlPanel.Controls.Add(this.printButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(0, 108);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.controlPanel.Size = new System.Drawing.Size(1508, 56);
            this.controlPanel.TabIndex = 2;
            // 
            // searchLabel
            // 
            this.searchLabel.Location = new System.Drawing.Point(11, 15);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(62, 31);
            this.searchLabel.TabIndex = 0;
            this.searchLabel.Text = "Search:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.searchTextBox.Location = new System.Drawing.Point(73, 12);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(224, 34);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // searchColumnComboBox
            // 
            this.searchColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchColumnComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.searchColumnComboBox.Items.AddRange(new object[] {
            "All",
            "Symbol",
            "Description",
            "Code",
            "Hex",
            "Binary",
            "Octal",
            "Unicode",
            "HTML Number",
            "Category"});
            this.searchColumnComboBox.Location = new System.Drawing.Point(304, 12);
            this.searchColumnComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchColumnComboBox.Name = "searchColumnComboBox";
            this.searchColumnComboBox.Size = new System.Drawing.Size(112, 36);
            this.searchColumnComboBox.TabIndex = 2;
            this.searchColumnComboBox.SelectedIndexChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(428, 11);
            this.copyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(79, 34);
            this.copyButton.TabIndex = 3;
            this.copyButton.Text = "Copy";
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(518, 11);
            this.exportButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(79, 34);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Export";
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(608, 11);
            this.fontButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(79, 34);
            this.fontButton.TabIndex = 5;
            this.fontButton.Text = "Font";
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(698, 11);
            this.printButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(79, 34);
            this.printButton.TabIndex = 6;
            this.printButton.Text = "Print";
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnsMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1508, 33);
            this.menuStrip.TabIndex = 4;
            // 
            // columnsMenu
            // 
            this.columnsMenu.Name = "columnsMenu";
            this.columnsMenu.Size = new System.Drawing.Size(98, 29);
            this.columnsMenu.Text = "Columns";
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(65, 29);
            this.helpMenu.Text = "Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(164, 34);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // AsciiTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 750);
            this.Controls.Add(this.asciiDataGridView);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AsciiTableForm";
            this.Text = "ASCII Table Pro";
            ((System.ComponentModel.ISupportInitialize)(this.asciiDataGridView)).EndInit();
            this.rowContextMenu.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}