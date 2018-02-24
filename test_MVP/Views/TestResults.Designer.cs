namespace test_MVP.Views
{
    partial class TestResults
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
            this.dataTestResults = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataTestResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTestResults
            // 
            this.dataTestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTestResults.Location = new System.Drawing.Point(12, 62);
            this.dataTestResults.Name = "dataTestResults";
            this.dataTestResults.Size = new System.Drawing.Size(551, 408);
            this.dataTestResults.TabIndex = 0;
            this.dataTestResults.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataTestResults_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Test Results";
            // 
            // TestResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 517);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataTestResults);
            this.Name = "TestResults";
            this.Text = "TestResults";
            ((System.ComponentModel.ISupportInitialize)(this.dataTestResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataTestResults;
        private System.Windows.Forms.Label label1;
    }
}