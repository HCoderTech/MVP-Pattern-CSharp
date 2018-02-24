namespace test_MVP.Views
{
    partial class GridDataView
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
            this.components = new System.ComponentModel.Container();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.RealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.dataGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.untrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.dataGridMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RealName,
            this.Age,
            this.Gender});
            this.dataGrid.Location = new System.Drawing.Point(3, 3);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(329, 150);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            this.dataGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGrid_CellMouseDown);
            // 
            // RealName
            // 
            this.RealName.HeaderText = "Name";
            this.RealName.Name = "RealName";
            // 
            // Age
            // 
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            this.Gender.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Gender.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(41, 182);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(90, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(207, 182);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // dataGridMenu
            // 
            this.dataGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.untrainToolStripMenuItem});
            this.dataGridMenu.Name = "dataGridMenu";
            this.dataGridMenu.Size = new System.Drawing.Size(114, 26);
            // 
            // untrainToolStripMenuItem
            // 
            this.untrainToolStripMenuItem.Name = "untrainToolStripMenuItem";
            this.untrainToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.untrainToolStripMenuItem.Text = "Untrain";
            this.untrainToolStripMenuItem.Click += new System.EventHandler(this.untrainToolStripMenuItem_Click);
            // 
            // GridDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.dataGrid);
            this.Name = "GridDataView";
            this.Size = new System.Drawing.Size(335, 240);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.dataGridMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.ContextMenuStrip dataGridMenu;
        private System.Windows.Forms.ToolStripMenuItem untrainToolStripMenuItem;
    }
}
