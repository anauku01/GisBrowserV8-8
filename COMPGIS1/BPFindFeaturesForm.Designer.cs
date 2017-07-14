namespace COMPGIS1
{
    partial class BPFindFeatureForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbApply = new System.Windows.Forms.CheckBox();
            this.gridFeatures = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridFeatures)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(245, 412);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(164, 412);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // cbApply
            // 
            this.cbApply.AutoSize = true;
            this.cbApply.Location = new System.Drawing.Point(12, 416);
            this.cbApply.Name = "cbApply";
            this.cbApply.Size = new System.Drawing.Size(148, 17);
            this.cbApply.TabIndex = 3;
            this.cbApply.Text = "Apply to Current Selection";
            this.cbApply.UseVisualStyleBackColor = true;
            // 
            // gridFeatures
            // 
            this.gridFeatures.AllowUserToAddRows = false;
            this.gridFeatures.AllowUserToDeleteRows = false;
            this.gridFeatures.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.gridFeatures.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridFeatures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFeatures.Location = new System.Drawing.Point(12, 12);
            this.gridFeatures.Name = "gridFeatures";
            this.gridFeatures.ReadOnly = true;
            this.gridFeatures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFeatures.Size = new System.Drawing.Size(308, 394);
            this.gridFeatures.TabIndex = 33;
            // 
            // BPFindFeatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 447);
            this.Controls.Add(this.gridFeatures);
            this.Controls.Add(this.cbApply);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "BPFindFeatureForm";
            this.Text = "Find Features";
            this.Load += new System.EventHandler(this.BPFindFeatureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridFeatures)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cbApply;
        private System.Windows.Forms.DataGridView gridFeatures;
    }
}