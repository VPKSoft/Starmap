namespace SMap
{
    partial class FormHTMLView
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbBrowserBack = new System.Windows.Forms.ToolStripButton();
            this.tsbBrowserForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbWebAddress = new System.Windows.Forms.TextBox();
            this.tsMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.tlpMain.SetColumnSpan(this.webBrowser, 2);
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 29);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(760, 496);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            // 
            // tsMain
            // 
            this.tsMain.CanOverflow = false;
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBrowserBack,
            this.tsbBrowserForward,
            this.toolStripSeparator1});
            this.tsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(64, 26);
            this.tsMain.TabIndex = 1;
            // 
            // tsbBrowserBack
            // 
            this.tsbBrowserBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBrowserBack.Image = global::SMap.Properties.Resources.Go_back;
            this.tsbBrowserBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBrowserBack.Name = "tsbBrowserBack";
            this.tsbBrowserBack.Size = new System.Drawing.Size(23, 23);
            this.tsbBrowserBack.Text = "Back";
            this.tsbBrowserBack.Click += new System.EventHandler(this.tsbBrowserBack_Click);
            // 
            // tsbBrowserForward
            // 
            this.tsbBrowserForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBrowserForward.Image = global::SMap.Properties.Resources.Go_forward;
            this.tsbBrowserForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBrowserForward.Name = "tsbBrowserForward";
            this.tsbBrowserForward.Size = new System.Drawing.Size(23, 23);
            this.tsbBrowserForward.Text = "Forward";
            this.tsbBrowserForward.Click += new System.EventHandler(this.tsbBrowserForward_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tsMain, 0, 0);
            this.tlpMain.Controls.Add(this.webBrowser, 0, 1);
            this.tlpMain.Controls.Add(this.tbWebAddress, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(766, 528);
            this.tlpMain.TabIndex = 2;
            // 
            // tbWebAddress
            // 
            this.tbWebAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWebAddress.Location = new System.Drawing.Point(67, 3);
            this.tbWebAddress.Name = "tbWebAddress";
            this.tbWebAddress.Size = new System.Drawing.Size(696, 20);
            this.tbWebAddress.TabIndex = 2;
            // 
            // FormHTMLView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 528);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormHTMLView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormHTMLView";
            this.Shown += new System.EventHandler(this.FormHTMLView_Shown);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbBrowserBack;
        private System.Windows.Forms.ToolStripButton tsbBrowserForward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox tbWebAddress;
    }
}