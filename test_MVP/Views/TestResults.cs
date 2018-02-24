using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_MVP.APITests.APITestFramework;

namespace test_MVP.Views
{
    public partial class TestResults : Form
    {
        public TestResults()
        {
            InitializeComponent();
            dataTestResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataTestResults.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataTestResults.AllowUserToOrderColumns = true;
            dataTestResults.AllowUserToResizeColumns = true;
        }

        public void SetDataContent(List<TestInfo> TestResults)
        {
            DataTable table = new DataTable();
            BindingFlags bindingFlags = BindingFlags.Public |
                             BindingFlags.NonPublic |
                             BindingFlags.Instance |
                             BindingFlags.Static;

            foreach (FieldInfo field in typeof(TestInfo).GetFields(bindingFlags))
            {
                if(field.Name!="ClassName")
                table.Columns.Add(field.Name);
            }
           foreach(TestInfo testResult in TestResults)
            {
                table.Rows.Add(testResult.MethodName, testResult.TestSuccess, testResult.TestSuccess ? "" : testResult.errorMessage);
            }
            dataTestResults.DataSource = table;
            
       }

        private void dataTestResults_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataTestResults.Rows.Count - 1; i++)
            {
                dataTestResults.Rows[i].Cells[1].Style.BackColor = dataTestResults.Rows[i].Cells[1].Value.ToString() == "True" ? Color.Green : Color.Red;
            }

        }
    }
}
