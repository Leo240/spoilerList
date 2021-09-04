
namespace WindowsFormsApp1
{
    partial class ProgressDialogBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressDialogBox));
            this.lblMaximum = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblMaximum
            // 
            resources.ApplyResources(this.lblMaximum, "lblMaximum");
            this.lblMaximum.Name = "lblMaximum";
            this.lblMaximum.Click += new System.EventHandler(this.lblMaximum_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // ProgressDialogBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblMaximum);
            this.Name = "ProgressDialogBox";
            this.Load += new System.EventHandler(this.ProgressDialogBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblMaximum;
        public System.Windows.Forms.ProgressBar progressBar1;
    }
}