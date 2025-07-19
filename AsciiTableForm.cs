using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace AsciiTablePro
{
    public partial class AsciiTableForm : Form
    {
        private List<AsciiEntry> asciiEntries;
        private PrintDocument printDocument;
        private int printRowIndex;

        public AsciiTableForm()
        {
            InitializeComponent();
            InitializeAsciiEntries();
            InitializeDataGridView();
            PopulateAsciiTable();
            InitializeColumnVisibilityMenu();
            ApplyLightTheme(); // Always use light theme
            InitializePrinting();
            searchColumnComboBox.SelectedIndex = 0; // Default to "All"
        }

        private void InitializeAsciiEntries()
        {
            asciiEntries = new List<AsciiEntry>();
            for (int i = 0; i < 256; i++)
            {
                asciiEntries.Add(AsciiEntry.Create(i));
            }
        }

        private void InitializeDataGridView()
        {
            asciiDataGridView.AutoGenerateColumns = false;
            asciiDataGridView.Columns.Clear();

            asciiDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Code", HeaderText = "Code", DataPropertyName = "Code", Width = 60 });
            asciiDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Hex", HeaderText = "Hex", DataPropertyName = "Hex", Width = 60 });
            asciiDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Binary", HeaderText = "Binary", DataPropertyName = "Binary", Width = 100 });
            asciiDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Octal", HeaderText = "Octal", DataPropertyName = "Octal", Width = 60 });
            asciiDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Char", HeaderText = "Symbol", DataPropertyName = "Char", Width = 80 });
            asciiDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unicode", HeaderText = "Unicode", DataPropertyName = "Unicode", Width = 80 });
            asciiDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "HtmlNumber", HeaderText = "HTML Number", DataPropertyName = "HtmlNumber", Width = 100 });
            asciiDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Description", DataPropertyName = "Description", Width = 200 });
            asciiDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Category", DataPropertyName = "Category", Width = 150 });

            asciiDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            asciiDataGridView.MultiSelect = false;
            asciiDataGridView.AllowUserToAddRows = false;
            asciiDataGridView.AllowUserToDeleteRows = false;
            asciiDataGridView.AllowUserToResizeRows = true;
            asciiDataGridView.AllowUserToOrderColumns = true;
            asciiDataGridView.RowHeadersVisible = false;
            asciiDataGridView.ReadOnly = true;
            asciiDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            asciiDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            asciiDataGridView.DefaultCellStyle.Font = new Font("Consolas", 10);
            asciiDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            asciiDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            asciiDataGridView.CellFormatting += AsciiDataGridView_CellFormatting;
            asciiDataGridView.ColumnHeaderMouseClick += AsciiDataGridView_ColumnHeaderMouseClick;
            asciiDataGridView.MouseDown += AsciiDataGridView_MouseDown;
        }

        private void PopulateAsciiTable()
        {
            asciiDataGridView.DataSource = null;
            asciiDataGridView.DataSource = asciiEntries;
        }

        private void AsciiDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (asciiDataGridView.Rows[e.RowIndex].DataBoundItem is AsciiEntry entry)
            {
                if (!entry.IsPrintable)
                {
                    asciiDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 244, 255); // very light blue
                    asciiDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                }
                else
                {
                    asciiDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    asciiDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string filter = searchTextBox.Text.ToLower();
            string selectedColumn = searchColumnComboBox.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedColumn))
                selectedColumn = "All";

            List<AsciiEntry> filtered;

            switch (selectedColumn)
            {
                case "Symbol":
                    filtered = asciiEntries.Where(a =>
                        !string.IsNullOrEmpty(a.Char) && a.Char.ToLower().Contains(filter)
                    ).ToList();
                    break;
                case "Description":
                    filtered = asciiEntries.Where(a =>
                        a.Description.ToLower().Contains(filter)
                    ).ToList();
                    break;
                case "Code":
                    filtered = asciiEntries.Where(a =>
                        a.Code.ToString().Contains(filter)
                    ).ToList();
                    break;
                case "Hex":
                    filtered = asciiEntries.Where(a =>
                        a.Hex.ToLower().Contains(filter)
                    ).ToList();
                    break;
                case "Binary":
                    filtered = asciiEntries.Where(a =>
                        a.Binary.Contains(filter)
                    ).ToList();
                    break;
                case "Octal":
                    filtered = asciiEntries.Where(a =>
                        a.Octal.Contains(filter)
                    ).ToList();
                    break;
                case "Unicode":
                    filtered = asciiEntries.Where(a =>
                        a.Unicode.ToLower().Contains(filter)
                    ).ToList();
                    break;
                default: // "All"
                    filtered = asciiEntries.Where(a =>
                        a.Code.ToString().Contains(filter) ||
                        a.Hex.ToLower().Contains(filter) ||
                        a.Binary.Contains(filter) ||
                        a.Octal.Contains(filter) ||
                        (!string.IsNullOrEmpty(a.Char) && a.Char.ToLower().Contains(filter)) ||
                        a.Unicode.ToLower().Contains(filter) ||
                        a.HtmlNumber.ToLower().Contains(filter) ||
                        a.Description.ToLower().Contains(filter) ||
                        a.Category.ToLower().Contains(filter) // <-- add this line
                    ).ToList();
                    break;
            }

            asciiDataGridView.DataSource = filtered;
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (asciiDataGridView.SelectedRows.Count > 0)
            {
                var row = asciiDataGridView.SelectedRows[0];
                var sb = new StringBuilder();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    sb.Append(cell.Value?.ToString());
                    sb.Append('\t');
                }
                Clipboard.SetText(sb.ToString().TrimEnd('\t'));
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.FileName = "AsciiTable.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToCsv(sfd.FileName);
                }
            }
        }

        private void ExportToCsv(string filePath)
        {
            var visibleColumns = asciiDataGridView.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
            using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Header
                sw.WriteLine(string.Join(",", visibleColumns.Select(c => $"\"{c.HeaderText}\"")));
                // Rows
                foreach (AsciiEntry entry in asciiDataGridView.DataSource as List<AsciiEntry>)
                {
                    var values = new List<string>();
                    foreach (var col in visibleColumns)
                    {
                        var val = entry.GetType().GetProperty(col.DataPropertyName).GetValue(entry, null)?.ToString();
                        values.Add($"\"{val}\"");
                    }
                    sw.WriteLine(string.Join(",", values));
                }
            }
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog())
            {
                fd.Font = asciiDataGridView.DefaultCellStyle.Font;
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    asciiDataGridView.DefaultCellStyle.Font = fd.Font;
                }
            }
        }

        //private void printButton_Click(object sender, EventArgs e)
        //{
        //    PrintPreviewDialog preview = new PrintPreviewDialog();
        //    preview.Document = printDocument;
        //    preview.Width = 1000;
        //    preview.Height = 700;
        //    printRowIndex = 0;
        //    preview.ShowDialog();
        //}

        private void printButton_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDlg = new PrintDialog())
            {
                printDlg.Document = printDocument;
                if (printDlg.ShowDialog() == DialogResult.OK)
                {
                    printRowIndex = 0;
                    printDocument.Print();
                }
            }
        }

        private void InitializePrinting()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int left = e.MarginBounds.Left;
            int top = e.MarginBounds.Top;
            int rowHeight = asciiDataGridView.RowTemplate.Height + 5;
            int colCount = asciiDataGridView.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            // Print headers
            int x = left;
            foreach (DataGridViewColumn col in asciiDataGridView.Columns)
            {
                if (!col.Visible) continue;
                e.Graphics.DrawString(col.HeaderText, new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, x, top);
                x += col.Width;
            }
            top += rowHeight;

            // Print rows
            while (printRowIndex < asciiDataGridView.Rows.Count)
            {
                x = left;
                DataGridViewRow row = asciiDataGridView.Rows[printRowIndex];
                foreach (DataGridViewColumn col in asciiDataGridView.Columns)
                {
                    if (!col.Visible) continue;
                    var val = row.Cells[col.Index].Value?.ToString();
                    e.Graphics.DrawString(val, asciiDataGridView.DefaultCellStyle.Font, Brushes.Black, x, top);
                    x += col.Width;
                }
                top += rowHeight;
                printRowIndex++;
                if (top > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            e.HasMorePages = false;
        }

        private void ApplyLightTheme()
        {
            this.BackColor = Color.White;
            headerPanel.BackColor = Color.FromArgb(25, 118, 210);
            titleLabel.ForeColor = Color.White;
            asciiDataGridView.BackgroundColor = Color.White;
            asciiDataGridView.DefaultCellStyle.BackColor = Color.White;
            asciiDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            asciiDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 118, 210);
            asciiDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            searchTextBox.BackColor = Color.White;
            searchTextBox.ForeColor = Color.Black;
            controlPanel.BackColor = Color.White;
        }

        private void AsciiDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string colName = asciiDataGridView.Columns[e.ColumnIndex].DataPropertyName;
            var data = asciiDataGridView.DataSource as List<AsciiEntry>;
            if (data == null) return;

            // Toggle sort direction
            bool ascending = asciiDataGridView.Tag as string != colName;
            asciiDataGridView.Tag = ascending ? colName : null;

            switch (colName)
            {
                case "Code":
                    asciiDataGridView.DataSource = ascending ? data.OrderBy(a => a.Code).ToList() : data.OrderByDescending(a => a.Code).ToList();
                    break;
                case "Hex":
                    asciiDataGridView.DataSource = ascending ? data.OrderBy(a => a.Hex).ToList() : data.OrderByDescending(a => a.Hex).ToList();
                    break;
                case "Binary":
                    asciiDataGridView.DataSource = ascending ? data.OrderBy(a => a.Binary).ToList() : data.OrderByDescending(a => a.Binary).ToList();
                    break;
                case "Octal":
                    asciiDataGridView.DataSource = ascending ? data.OrderBy(a => a.Octal).ToList() : data.OrderByDescending(a => a.Octal).ToList();
                    break;
                case "Char":
                    asciiDataGridView.DataSource = ascending ? data.OrderBy(a => a.Char).ToList() : data.OrderByDescending(a => a.Char).ToList();
                    break;
                case "Unicode":
                    asciiDataGridView.DataSource = ascending ? data.OrderBy(a => a.Unicode).ToList() : data.OrderByDescending(a => a.Unicode).ToList();
                    break;
                case "Description":
                    asciiDataGridView.DataSource = ascending ? data.OrderBy(a => a.Description).ToList() : data.OrderByDescending(a => a.Description).ToList();
                    break;
            }
        }

        private void InitializeColumnVisibilityMenu()
        {
            foreach (DataGridViewColumn col in asciiDataGridView.Columns)
            {
                var item = new ToolStripMenuItem(col.HeaderText) { Checked = true, Tag = col };
                item.CheckOnClick = true;
                item.CheckedChanged += (s, e) =>
                {
                    var c = (DataGridViewColumn)((ToolStripMenuItem)s).Tag;
                    c.Visible = ((ToolStripMenuItem)s).Checked;
                };
                columnsMenu.DropDownItems.Add(item);
            }
        }

        // Context Menu
        private void AsciiDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = asciiDataGridView.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    asciiDataGridView.ClearSelection();
                    asciiDataGridView.Rows[hit.RowIndex].Selected = true;
                }
            }
        }

        private void copyCodeMenuItem_Click(object sender, EventArgs e)
        {
            if (asciiDataGridView.SelectedRows.Count > 0)
            {
                var row = asciiDataGridView.SelectedRows[0];
                Clipboard.SetText(row.Cells["Code"].Value?.ToString());
            }
        }

        private void copyCharMenuItem_Click(object sender, EventArgs e)
        {
            if (asciiDataGridView.SelectedRows.Count > 0)
            {
                var row = asciiDataGridView.SelectedRows[0];
                Clipboard.SetText(row.Cells["Char"].Value?.ToString());
            }
        }

        private void copyDescMenuItem_Click(object sender, EventArgs e)
        {
            if (asciiDataGridView.SelectedRows.Count > 0)
            {
                var row = asciiDataGridView.SelectedRows[0];
                Clipboard.SetText(row.Cells["Description"].Value?.ToString());
            }
        }

        // About Dialog
        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new AboutDialog())
            {
                dlg.ShowDialog(this);
            }
        }
    }
}