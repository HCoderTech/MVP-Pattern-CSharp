using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_MVP.EventAggregator;
using test_MVP.EventAggregator.Events;
using test_MVP.Views;

namespace test_MVP.Presenters
{
    public interface IDetailsPageViewObserver
    {
        
    }
    class DetailsPagePresenter : IDetailsPageViewObserver,
        ISubscriber<UpdateDetailsPageDetails>,
        ISubscriber<GridSelectionClear>
    {
        
        private IEventAggregator eventAggregator;
        private IDetailsPage view;

        public DetailsPagePresenter(IDetailsPage detailsPage, IEventAggregator eventAggregator)
        {
            this.view = detailsPage;
            this.eventAggregator = eventAggregator;
            this.view.AttachPresenter(this);
            this.eventAggregator.SubsribeEvent(this);
        }

        public void OnEventHandler(GridSelectionClear e)
        {
            view.ClearValues();
        }

        public void OnEventHandler(UpdateDetailsPageDetails e)
        {
            view.UpdateValues(e.name,e.age,e.gender);
        }

        
    }
}
