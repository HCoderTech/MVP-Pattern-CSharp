using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_MVP.APITests.APITestFramework;
using test_MVP.EventAggregator;
using test_MVP.EventAggregator.Events;
using test_MVP.Views;

namespace test_MVP.Presenters
{
    public interface IResultantViewPresenter
    {
        Linker Link { get; }
        void btnTrainClicked();
        void ActivateTestMode();
        void DeActivateTestMode();
    }
    class ResultantViewPresenter : ISubscriber<GridRowSelectionChanged>,IResultantViewPresenter
    {
        private IResultantView view;
        private IEventAggregator eventAggregator;
        private IGridDataViewObserver gridDataViewPresenter;
        private IDetailsPageViewObserver detailsPagePresenter;
        private int activeRow;
        public Linker link;

        public Linker Link
        {
            get
            {
                return link;
            }
        }

        public ResultantViewPresenter(IResultantView paramView,IEventAggregator paramEventAggregator)
        {
            view = paramView;
            eventAggregator = paramEventAggregator;
            InitializePresenter();
            link = new Linker(detailsPagePresenter, gridDataViewPresenter, this);
        }
        private void InitializeChildPresenters()
        {
            gridDataViewPresenter = new GridDataViewPresenter(this.view.GridDataView, eventAggregator);
            detailsPagePresenter = new DetailsPagePresenter(this.view.DetailsPage, eventAggregator);
        }

        public void InitializePresenter()
        {
            view.AttachPresenter(this);
            eventAggregator.SubsribeEvent(this);
            InitializeChildPresenters();
        }
        public void OnEventHandler(GridRowSelectionChanged e)
        {
            System.IO.File.AppendAllText(@"D:\text.txt", "EventHandler for GridRowSelectionChanged on ResultantViewPresenter updating activeRowId on ResultantViewPresenter and updating rowId on it's view(Label Active Row)." + Environment.NewLine);
            activeRow = e.rowId;
            view.UpdateRowId(e.rowId);
        }

        public void btnTrainClicked()
        {
            eventAggregator.PublishEvent(new TrainButtonClicked(activeRow));
        }

        public void ActivateTestMode()
        {
            eventAggregator.PublishEvent(new TrainingMode() { Active = true });
        }

        public void DeActivateTestMode()
        {
            eventAggregator.PublishEvent(new TrainingMode() { Active = false });
        }
    }
}
