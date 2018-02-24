using System.Windows.Forms;
using test_MVP.Presenters;
using test_MVP.Views;

namespace test_MVP
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            resultantViewPresenter = new ResultantViewPresenter(resultantView, eventAggregator);
            resultantView.AttachPresenter(resultantViewPresenter);
        }
        private ResultantView resultantView;
        private ResultantViewPresenter resultantViewPresenter;
        private EventAggregator.EventAggregator eventAggregator=new EventAggregator.EventAggregator();

        private void resultantView_Load(object sender, System.EventArgs e)
        {

        }
    }
}
