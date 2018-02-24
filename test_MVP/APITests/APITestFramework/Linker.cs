using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_MVP.Presenters;

namespace test_MVP.APITests.APITestFramework
{
   public class Linker
    {
        IDetailsPageViewObserver detailsPagePresenter;
        IGridDataViewObserver gridDataViewPresenter;
        IResultantViewPresenter resultantViewPresenter;
            public Linker(IDetailsPageViewObserver detailsPagePresenter, IGridDataViewObserver gridDataViewPresenter,IResultantViewPresenter resultantViewPresenter)
            {
            this.DetailsPagePresenter = detailsPagePresenter;
            this.GridDataViewPresenter = gridDataViewPresenter;
            this.ResultantViewPresenter = resultantViewPresenter;
            }

        public IDetailsPageViewObserver DetailsPagePresenter
        {
            get
            {
                return detailsPagePresenter;
            }

            set
            {
                detailsPagePresenter = value;
            }
        }

        public IGridDataViewObserver GridDataViewPresenter
        {
            get
            {
                return gridDataViewPresenter;
            }

            set
            {
                gridDataViewPresenter = value;
            }
        }

        public IResultantViewPresenter ResultantViewPresenter
        {
            get
            {
                return resultantViewPresenter;
            }

            set
            {
                resultantViewPresenter = value;
            }
        }
    }
}
