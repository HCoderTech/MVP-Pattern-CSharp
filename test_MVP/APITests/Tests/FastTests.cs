using SimpleLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_MVP.APITests.APITestFramework;
using test_MVP.APITests.Attributes;

namespace test_MVP.APITests.Tests
{
    [ApiTest]
    class FastTests
    {
        Linker link;
        [ApiClassInitialize]
        public void Initialize(Linker link)
        {
            this.link = link;
        }
        [ApiUseCase]
        public void Train_And_Untrain_Row2()
        {
            link.GridDataViewPresenter.CheckClicked();
            SimpleLog.Info("Check Clicked");
            link.GridDataViewPresenter.RowSelectionChanged(1);
            SimpleLog.Info("Row 2 Selected");
            link.ResultantViewPresenter.btnTrainClicked();
            SimpleLog.Info("Button Train Clicked");
            Assert.AreEqual(true, link.GridDataViewPresenter.isTrained(1));
            SimpleLog.Info("Assert is true for row 1 istrained.");
            link.GridDataViewPresenter.UnTrainClicked(1);
            SimpleLog.Info("row 2 untrained");
            Assert.AreEqual(false, link.GridDataViewPresenter.isTrained(1));
            SimpleLog.Info("Assert is false for row 2 istrained.");
        }
        [ApiUseCase]
        public void Train_And_Untrain_Row1()
        {
            link.GridDataViewPresenter.CheckClicked();
            SimpleLog.Info("Check Clicked");
            link.GridDataViewPresenter.RowSelectionChanged(0);
            SimpleLog.Info("Row 1 Selected");
            link.ResultantViewPresenter.btnTrainClicked();
            SimpleLog.Info("Button Train Clicked");
            Assert.AreEqual(true, link.GridDataViewPresenter.isTrained(0));
            SimpleLog.Info("Assert is true for row 1 istrained.");
            link.GridDataViewPresenter.UnTrainClicked(1);
            SimpleLog.Info("row 1 untrained");
            Assert.AreEqual(false, link.GridDataViewPresenter.isTrained(0));
            SimpleLog.Info("Assert is false for row 1 istrained.");
        }
    }
}
