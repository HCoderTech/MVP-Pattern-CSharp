using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_MVP.Presenters;

namespace test_MVP.Views
{
    public interface IGridDataView
    {
        void AttachPresenter(IGridDataViewObserver presenter);
        void ChangeColorOfRow(int rowId,bool trained);
        void ClearRowselection();
        void SelectCell(int rowIndex, int columnIndex);
        string GetName(int rowIndex);
        string GetAge(int rowIndex);
        string GetGender(int rowIndex);
        bool AskUser(string message, string caption,bool trainMode=false);
        bool isTrained(int rowIndex);
    }
    public partial class GridDataView : UserControl,IGridDataView
    {
        private IGridDataViewObserver presenter;
        public GridDataView()
        {
            InitializeComponent();
            this.dataGrid.Rows.Add("Hewitt","24","Male");
            this.dataGrid.Rows.Add("Arun", "24", "Male");
            this.dataGrid.Rows.Add("Aruna", "23", "Female");
           
        }
        public void AttachPresenter(IGridDataViewObserver observer)
        {
            presenter = observer;
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            presenter.RowSelectionChanged(e.RowIndex);
            }


        public void ChangeColorOfRow(int rowId,bool trained)
        {
            Color TrainStatus = trained ? Color.Green : Color.Red;
            this.dataGrid.Rows[rowId].Cells[0].Style.BackColor = TrainStatus;
            this.dataGrid.Rows[rowId].Cells[1].Style.BackColor = TrainStatus;
            this.dataGrid.Rows[rowId].Cells[2].Style.BackColor = TrainStatus;
        }

       

        private void dataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            presenter.SelectCell(e.RowIndex, e.ColumnIndex);
            
            
            if (e.Button == MouseButtons.Right)
            {
                dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ContextMenuStrip = dataGridMenu;
            }
        }
        #region.......Actual View Update Methods......
        public void ClearRowselection()
        {
           dataGrid.ClearSelection();
        }

        public void SelectCell(int rowIndex, int columnIndex)
        {
            dataGrid.CurrentCell = dataGrid.Rows[rowIndex].Cells[columnIndex];
            dataGrid.Rows[rowIndex].Selected = true;
           
        }
        public string GetName(int rowIndex)
        {
            return dataGrid.Rows[rowIndex].Cells["RealName"].Value.ToString();
        }
        public string GetAge(int rowIndex)
        {
            return dataGrid.Rows[rowIndex].Cells["Age"].Value.ToString();
        }
        public string GetGender(int rowIndex)
        {
            return dataGrid.Rows[rowIndex].Cells["Gender"].Value.ToString();
            
        }
        public int GetCurrentRow()
        {
            return dataGrid.CurrentCell.RowIndex;
        }
        public int GetCurrentColumn()
        {
            return dataGrid.CurrentCell.ColumnIndex;
        }
        public bool AskUser(string message,string caption,bool trainmode=false)
        {
            if (trainmode)
                return true;
            else
            {
                return AskUser(message,caption);
            }
        }
        public bool AskUser(string message,string caption)
        {
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            return result == DialogResult.OK;
        }
        public bool isTrained(int rowIndex)
        {
            DataTable table = getDatafromGrid();
            return Convert.ToBoolean(table.Rows[rowIndex].Field<string>("trainStatus"));
        }
        public DataTable getDatafromGrid()
        {
            DataTable table = new DataTable("Data");
            table.Columns.Add("name");
            table.Columns.Add("age");
            table.Columns.Add("gender");
            table.Columns.Add("trainStatus");
            foreach(DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Cells[0].Value != null) { 
                bool TrainStatus = row.Cells[0].Style.BackColor == Color.Green ? true:false;
                table.Rows.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), TrainStatus);
                }
            }
            return table;
        }
        #endregion

        private void untrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.UnTrainClicked(GetCurrentRow());
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            presenter.CheckClicked();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            presenter.ClearRowSelection();
        }
    }
}
