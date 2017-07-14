namespace COMPGIS1
{
    partial class findLSwithMitProjects
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
            this.rbNotAssigned = new System.Windows.Forms.RadioButton();
            this.rbAssignedSpecific = new System.Windows.Forms.RadioButton();
            this.cbApplyToSelection = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboxProjects = new System.Windows.Forms.ComboBox();
            this.rbAssignedToAny = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rbNotAssigned
            // 
            this.rbNotAssigned.AutoSize = true;
            this.rbNotAssigned.Location = new System.Drawing.Point(32, 53);
            this.rbNotAssigned.Name = "rbNotAssigned";
            this.rbNotAssigned.Size = new System.Drawing.Size(189, 17);
            this.rbNotAssigned.TabIndex = 32;
            this.rbNotAssigned.Text = "Not Assigned to Mitigation Projects";
            this.rbNotAssigned.UseVisualStyleBackColor = true;
            this.rbNotAssigned.CheckedChanged += new System.EventHandler(this.rbAssignedSpecific_CheckedChanged);
            // 
            // rbAssignedSpecific
            // 
            this.rbAssignedSpecific.AutoSize = true;
            this.rbAssignedSpecific.Location = new System.Drawing.Point(32, 79);
            this.rbAssignedSpecific.Name = "rbAssignedSpecific";
            this.rbAssignedSpecific.Size = new System.Drawing.Size(214, 17);
            this.rbAssignedSpecific.TabIndex = 31;
            this.rbAssignedSpecific.Text = "Assigned to a Specific Mitigation Project";
            this.rbAssignedSpecific.UseVisualStyleBackColor = true;
            this.rbAssignedSpecific.CheckedChanged += new System.EventHandler(this.rbAssignedSpecific_CheckedChanged);
            // 
            // cbApplyToSelection
            // 
            this.cbApplyToSelection.AutoSize = true;
            this.cbApplyToSelection.Location = new System.Drawing.Point(32, 154);
            this.cbApplyToSelection.Name = "cbApplyToSelection";
            this.cbApplyToSelection.Size = new System.Drawing.Size(148, 17);
            this.cbApplyToSelection.TabIndex = 30;
            this.cbApplyToSelection.Text = "Apply to Current Selection";
            this.cbApplyToSelection.UseVisualStyleBackColor = true;
            this.cbApplyToSelection.CheckedChanged += new System.EventHandler(this.cbApplyToSelection_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(185, 184);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 29;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(266, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cboxProjects
            // 
            this.cboxProjects.FormattingEnabled = true;
            this.cboxProjects.Location = new System.Drawing.Point(51, 107);
            this.cboxProjects.Name = "cboxProjects";
            this.cboxProjects.Size = new System.Drawing.Size(290, 21);
            this.cboxProjects.TabIndex = 33;
            // 
            // rbAssignedToAny
            // 
            this.rbAssignedToAny.AutoSize = true;
            this.rbAssignedToAny.Checked = true;
            this.rbAssignedToAny.Location = new System.Drawing.Point(32, 26);
            this.rbAssignedToAny.Name = "rbAssignedToAny";
            this.rbAssignedToAny.Size = new System.Drawing.Size(190, 17);
            this.rbAssignedToAny.TabIndex = 34;
            this.rbAssignedToAny.TabStop = true;
            this.rbAssignedToAny.Text = "Assigned to Any Mitigation Projects";
            this.rbAssignedToAny.UseVisualStyleBackColor = true;
            this.rbAssignedToAny.CheckedChanged += new System.EventHandler(this.rbAssignedSpecific_CheckedChanged);
            // 
            // findLSwithMitProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 225);
            this.Controls.Add(this.rbAssignedToAny);
            this.Controls.Add(this.cboxProjects);
            this.Controls.Add(this.rbNotAssigned);
            this.Controls.Add(this.rbAssignedSpecific);
            this.Controls.Add(this.cbApplyToSelection);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "findLSwithMitProjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find: Line Sections with Mitigation Projects";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbNotAssigned;
        private System.Windows.Forms.RadioButton rbAssignedSpecific;
        private System.Windows.Forms.CheckBox cbApplyToSelection;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboxProjects;
        private System.Windows.Forms.RadioButton rbAssignedToAny;
    }
}