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
using test_MVP.APITests.TestRunner;

namespace test_MVP.Views
{
    public interface IResultantView
    {
        IGridDataView GridDataView { get;}
        IDetailsPage DetailsPage { get;}
        void AttachPresenter(IResultantViewPresenter resultantViewPresenter);
        void UpdateRowId(int rowId);
    }
    public partial class ResultantView : UserControl,IResultantView
    {
        private IResultantViewPresenter presenter;
        Test_Mvp_ApiTests_Runner TestRunner;
        public ResultantView()
        {
            InitializeComponent();
        }
        private GridDataView gridDataView;
        private DetailsPage detailsPage;

        public IGridDataView GridDataView
        {
            get
            {
                return gridDataView;
            }
        }

        public IDetailsPage DetailsPage
        {
            get
            {
                return detailsPage;
            }
        }

        public void AttachPresenter(IResultantViewPresenter resultantViewPresenter)
        {
            presenter = resultantViewPresenter;
        }

        public void UpdateRowId(int rowId)
        {
            lblActive.Text ="Row Active :"+rowId;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            presenter.btnTrainClicked();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.ActivateTestMode();
            //invoke instance of API Test Runner
            TestRunner = new Test_Mvp_ApiTests_Runner(presenter.Link);
            TestRunner.RunTests();
            presenter.DeActivateTestMode();
            TestResults testResultsForm = new TestResults();
            testResultsForm.SetDataContent(TestRunner.GetTestResults());
            testResultsForm.Show();
            
        }
    }
}
