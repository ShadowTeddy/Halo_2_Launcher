namespace Halo_2_Launcher.Forms
{
    partial class Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Update));
            this.UpdateProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.ProgressLabel = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.DetailsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateProgressBar
            // 
            this.UpdateProgressBar.Location = new System.Drawing.Point(23, 63);
            this.UpdateProgressBar.Name = "UpdateProgressBar";
            this.UpdateProgressBar.Size = new System.Drawing.Size(447, 23);
            this.UpdateProgressBar.Style = MetroFramework.MetroColorStyle.Blue;
            this.UpdateProgressBar.TabIndex = 0;
            this.UpdateProgressBar.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.ProgressLabel.Location = new System.Drawing.Point(476, 61);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(67, 25);
            this.ProgressLabel.TabIndex = 1;
            this.ProgressLabel.Tag = "{0}/100";
            this.ProgressLabel.Text = "100/100";
            this.ProgressLabel.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.DetailsRichTextBox);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 92);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(520, 111);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // DetailsRichTextBox
            // 
            this.DetailsRichTextBox.BackColor = System.Drawing.Color.Gray;
            this.DetailsRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DetailsRichTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsRichTextBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.DetailsRichTextBox.Location = new System.Drawing.Point(1, 1);
            this.DetailsRichTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.DetailsRichTextBox.Name = "DetailsRichTextBox";
            this.DetailsRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.DetailsRichTextBox.Size = new System.Drawing.Size(516, 107);
            this.DetailsRichTextBox.TabIndex = 2;
            this.DetailsRichTextBox.Text = "";
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(566, 226);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.UpdateProgressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Update";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Checking For Updates";
            this.Load += new System.EventHandler(this.Update_Load);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        public MetroFramework.Controls.MetroProgressBar UpdateProgressBar;
        public MetroFramework.Controls.MetroLabel ProgressLabel;
        public System.Windows.Forms.RichTextBox DetailsRichTextBox;
    }
}