using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_MVP.EventAggregator.Events
{
    public class GridRowSelectionChanged
    {
        public int rowId { get; set; }
    }
    public class TrainButtonClicked
    {
        public int rowId;
        public TrainButtonClicked(int id)
        {
            rowId = id;
        }
    }
    public class GridSelectionClear
    {

    }
    public class UpdateDetailsPageDetails
    {
        public string name;
        public string age;
        public string gender;
    }
    public class TrainingMode
    {
        public bool Active;
    }
}
