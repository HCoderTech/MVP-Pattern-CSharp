using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_MVP.EventAggregator;
using test_MVP.EventAggregator.Events;
using test_MVP.Models;
using test_MVP.Views;

namespace test_MVP.Presenters
{
    public interface IGridDataViewObserver
    {
        void RowSelectionChanged(int rowId);
        void ClearRowSelection();
        void SelectCell(int rowIndex, int columnIndex);
        void UnTrainClicked(int rowIndex);
        void CheckClicked();
        bool isTrained(int rowIndex);
    }
    class GridDataViewPresenter : IGridDataViewObserver,ISubscriber<TrainButtonClicked>,
        ISubscriber<GridSelectionClear>,ISubscriber<TrainingMode>

    {
        private int activeRowID = 0;
        private IEventAggregator eventAggregator;
        private Student student;
        private IGridDataView view;
        private bool trainMode = false;
        public GridDataViewPresenter(IGridDataView view,IEventAggregator eventAggregator)
        {
            this.view = view;
            this.eventAggregator = eventAggregator;
            eventAggregator.SubsribeEvent(this);
            this.view.AttachPresenter(this);
        }
        public void RowSelectionChanged(int rowId)
        {
            SetActiveRegionAndRaiseEvent(rowId);
        }

        private void SetActiveRegionAndRaiseEvent(int value)
        {
            activeRowID = value;
            student = new Student() { Name =view.GetName(activeRowID), Age = view.GetAge(activeRowID), Gender = view.GetGender(activeRowID) };
            Raise_RowIDChangedEvent();
        }

        private void Raise_RowIDChangedEvent()
        {
            eventAggregator.PublishEvent(new GridRowSelectionChanged { rowId = activeRowID});
            eventAggregator.PublishEvent(new UpdateDetailsPageDetails() { name=view.GetName(activeRowID),age=view.GetAge(activeRowID),gender=view.GetGender(activeRowID)});
        }

        public void OnEventHandler(TrainButtonClicked e)
        {
            view.ChangeColorOfRow(e.rowId,true);
        }

        public void ClearRowSelection()
        {
            eventAggregator.PublishEvent(new GridSelectionClear());
        }

        public void OnEventHandler(GridSelectionClear e)
        {
            view.ClearRowselection();
        }

        public void SelectCell(int rowIndex, int columnIndex)
        {
            view.SelectCell(rowIndex,columnIndex);
            eventAggregator.PublishEvent(new GridRowSelectionChanged { rowId=rowIndex });
            eventAggregator.PublishEvent(new UpdateDetailsPageDetails { name = view.GetName(rowIndex), age = view.GetAge(rowIndex), gender = view.GetGender(rowIndex) });
        }

        public void UnTrainClicked(int rowIndex)
        {
            view.ChangeColorOfRow(rowIndex,false);
            //false signifies untrain
        }

        public void CheckClicked()
        {
            view.AskUser("The Person is Qualified","Info",trainMode);
        }

        public bool isTrained(int rowIndex)
        {
            return view.isTrained(rowIndex);
        }

        public void OnEventHandler(TrainingMode e)
        {
            trainMode=e.Active;
        }
    }
}
