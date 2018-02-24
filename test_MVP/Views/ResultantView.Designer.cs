namespace test_MVP.Views
{
    partial class ResultantView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTrain = new System.Windows.Forms.Button();
            this.lblActive = new System.Windows.Forms.Label();
            this.detailsPage = new test_MVP.Views.DetailsPage();
            this.gridDataView = new test_MVP.Views.GridDataView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.gridDataView);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 234);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Yellow;
            this.panel2.Controls.Add(this.detailsPage);
            this.panel2.Location = new System.Drawing.Point(3, 249);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 237);
            this.panel2.TabIndex = 1;
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(120, 492);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(75, 23);
            this.btnTrain.TabIndex = 2;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(234, 497);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(79, 13);
            this.lblActive.TabIndex = 3;
            this.lblActive.Text = "No Row Active";
            // 
            // detailsPage
            // 
            this.detailsPage.BackColor = System.Drawing.Color.LightYellow;
            this.detailsPage.Location = new System.Drawing.Point(0, 0);
            this.detailsPage.Name = "detailsPage";
            this.detailsPage.Size = new System.Drawing.Size(322, 234);
            this.detailsPage.TabIndex = 0;
            // 
            // gridDataView
            // 
            this.gridDataView.Location = new System.Drawing.Point(0, 0);
            this.gridDataView.Name = "gridDataView";
            this.gridDataView.Size = new System.Drawing.Size(322, 240);
            this.gridDataView.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 492);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ResultantView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ResultantView";
            this.Size = new System.Drawing.Size(328, 528);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Button button1;
    }
}
