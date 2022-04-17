namespace SMap
{
    partial class FormSelectLocation
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
            this.lbFindLocation = new System.Windows.Forms.Label();
            this.tbFindLocation = new System.Windows.Forms.TextBox();
            this.lbSelectLocation = new System.Windows.Forms.Label();
            this.cmbSelectLocation = new System.Windows.Forms.ComboBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.pbPickLocation = new System.Windows.Forms.PictureBox();
            this.lbMouseLatLon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPickLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFindLocation
            // 
            this.lbFindLocation.AutoSize = true;
            this.lbFindLocation.Location = new System.Drawing.Point(12, 15);
            this.lbFindLocation.Name = "lbFindLocation";
            this.lbFindLocation.Size = new System.Drawing.Size(79, 13);
            this.lbFindLocation.TabIndex = 0;
            this.lbFindLocation.Text = "Find a location:";
            // 
            // tbFindLocation
            // 
            this.tbFindLocation.Location = new System.Drawing.Point(97, 12);
            this.tbFindLocation.Name = "tbFindLocation";
            this.tbFindLocation.Size = new System.Drawing.Size(259, 20);
            this.tbFindLocation.TabIndex = 1;
            this.tbFindLocation.TextChanged += new System.EventHandler(this.tbFindLocation_TextChanged);
            // 
            // lbSelectLocation
            // 
            this.lbSelectLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSelectLocation.AutoSize = true;
            this.lbSelectLocation.Location = new System.Drawing.Point(370, 15);
            this.lbSelectLocation.Name = "lbSelectLocation";
            this.lbSelectLocation.Size = new System.Drawing.Size(89, 13);
            this.lbSelectLocation.TabIndex = 2;
            this.lbSelectLocation.Text = "Select a location:";
            // 
            // cmbSelectLocation
            // 
            this.cmbSelectLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSelectLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectLocation.FormattingEnabled = true;
            this.cmbSelectLocation.Location = new System.Drawing.Point(465, 12);
            this.cmbSelectLocation.Name = "cmbSelectLocation";
            this.cmbSelectLocation.Size = new System.Drawing.Size(295, 21);
            this.cmbSelectLocation.TabIndex = 3;
            this.cmbSelectLocation.SelectedIndexChanged += new System.EventHandler(this.cmbSelectLocation_SelectedIndexChanged);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(685, 620);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 21);
            this.btCancel.TabIndex = 34;
            this.btCancel.Text = "Cancel";
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(12, 620);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 21);
            this.btOK.TabIndex = 35;
            this.btOK.Text = "OK";
            // 
            // pbPickLocation
            // 
            this.pbPickLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPickLocation.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbPickLocation.Image = global::SMap.Properties.Resources.Gall_Stereographic_projection_SW_centered;
            this.pbPickLocation.Location = new System.Drawing.Point(12, 38);
            this.pbPickLocation.Name = "pbPickLocation";
            this.pbPickLocation.Size = new System.Drawing.Size(748, 576);
            this.pbPickLocation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPickLocation.TabIndex = 4;
            this.pbPickLocation.TabStop = false;
            this.pbPickLocation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPickLocation_MouseDown);
            this.pbPickLocation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPickLocation_MouseMove);
            // 
            // lbMouseLatLon
            // 
            this.lbMouseLatLon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMouseLatLon.AutoSize = true;
            this.lbMouseLatLon.Location = new System.Drawing.Point(94, 624);
            this.lbMouseLatLon.Name = "lbMouseLatLon";
            this.lbMouseLatLon.Size = new System.Drawing.Size(10, 13);
            this.lbMouseLatLon.TabIndex = 36;
            this.lbMouseLatLon.Text = "-";
            // 
            // FormSelectLocation
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(772, 653);
            this.Controls.Add(this.lbMouseLatLon);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.pbPickLocation);
            this.Controls.Add(this.cmbSelectLocation);
            this.Controls.Add(this.lbSelectLocation);
            this.Controls.Add(this.tbFindLocation);
            this.Controls.Add(this.lbFindLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSelectLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select your location";
            ((System.ComponentModel.ISupportInitialize)(this.pbPickLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFindLocation;
        private System.Windows.Forms.TextBox tbFindLocation;
        private System.Windows.Forms.Label lbSelectLocation;
        private System.Windows.Forms.ComboBox cmbSelectLocation;
        private System.Windows.Forms.PictureBox pbPickLocation;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Label lbMouseLatLon;
    }
}