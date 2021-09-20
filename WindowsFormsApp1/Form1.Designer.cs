
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnInsertLinks = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnApplyPatternOptions = new System.Windows.Forms.Button();
            this.tbImagesPerSpoiler = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApplyPattern = new System.Windows.Forms.Button();
            this.tbPattern = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnChooseSource = new System.Windows.Forms.Button();
            this.btnCreateSamples = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnInsertLinks);
            this.tabPage1.Controls.Add(this.dataGridView1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnInsertLinks
            // 
            resources.ApplyResources(this.btnInsertLinks, "btnInsertLinks");
            this.btnInsertLinks.Name = "btnInsertLinks";
            this.btnInsertLinks.UseVisualStyleBackColor = true;
            this.btnInsertLinks.Click += new System.EventHandler(this.btnInsertLinks_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            // 
            // tabPage2
            // 
            this.tabPage2.AllowDrop = true;
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.btnApplyPatternOptions);
            this.tabPage2.Controls.Add(this.tbImagesPerSpoiler);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnApplyPattern);
            this.tabPage2.Controls.Add(this.tbPattern);
            this.tabPage2.Controls.Add(this.textBox1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnApplyPatternOptions
            // 
            resources.ApplyResources(this.btnApplyPatternOptions, "btnApplyPatternOptions");
            this.btnApplyPatternOptions.Name = "btnApplyPatternOptions";
            this.btnApplyPatternOptions.UseVisualStyleBackColor = true;
            this.btnApplyPatternOptions.Click += new System.EventHandler(this.btnApplyPatternOptions_Click);
            // 
            // tbImagesPerSpoiler
            // 
            resources.ApplyResources(this.tbImagesPerSpoiler, "tbImagesPerSpoiler");
            this.tbImagesPerSpoiler.Name = "tbImagesPerSpoiler";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnApplyPattern
            // 
            resources.ApplyResources(this.btnApplyPattern, "btnApplyPattern");
            this.btnApplyPattern.Name = "btnApplyPattern";
            this.btnApplyPattern.UseVisualStyleBackColor = true;
            this.btnApplyPattern.Click += new System.EventHandler(this.btnApplyPattern_Click);
            // 
            // tbPattern
            // 
            resources.ApplyResources(this.tbPattern, "tbPattern");
            this.tbPattern.Name = "tbPattern";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnChooseSource);
            this.tabPage3.Controls.Add(this.btnCreateSamples);
            this.tabPage3.Controls.Add(this.btnSort);
            this.tabPage3.Controls.Add(this.tbOutput);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnChooseSource
            // 
            resources.ApplyResources(this.btnChooseSource, "btnChooseSource");
            this.btnChooseSource.Name = "btnChooseSource";
            this.btnChooseSource.UseVisualStyleBackColor = true;
            this.btnChooseSource.Click += new System.EventHandler(this.btnChooseSource_Click);
            // 
            // btnCreateSamples
            // 
            resources.ApplyResources(this.btnCreateSamples, "btnCreateSamples");
            this.btnCreateSamples.Name = "btnCreateSamples";
            this.btnCreateSamples.UseVisualStyleBackColor = true;
            this.btnCreateSamples.Click += new System.EventHandler(this.btnCreateSamples_Click);
            // 
            // btnSort
            // 
            resources.ApplyResources(this.btnSort, "btnSort");
            this.btnSort.Name = "btnSort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // tbOutput
            // 
            resources.ApplyResources(this.tbOutput, "tbOutput");
            this.tbOutput.Name = "tbOutput";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.FileName = "Folder Selection.";
            this.openFileDialog1.ValidateNames = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.AddExtension = false;
            this.saveFileDialog1.ValidateNames = false;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnInsertLinks;
        private System.Windows.Forms.TextBox tbPattern;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnApplyPattern;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnCreateSamples;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnChooseSource;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnApplyPatternOptions;
        private System.Windows.Forms.TextBox tbImagesPerSpoiler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

