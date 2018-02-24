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
    class BasicTests
    {
        Linker link;
        [ApiClassInitialize]
        public void Initialize(Linker link)
        {
            this.link = link;
        }
        [ApiUseCase]
        public void Train_And_Untrain_Row3()
        {
            link.GridDataViewPresenter.CheckClicked();
            SimpleLog.Info("Check Clicked");
            link.GridDataViewPresenter.RowSelectionChanged(2);
            SimpleLog.Info("Row 3 Selected");
            link.ResultantViewPresenter.btnTrainClicked();
            SimpleLog.Info("Button Train Clicked");
            Assert.AreEqual(true, link.GridDataViewPresenter.isTrained(2));
            SimpleLog.Info("Assert is true for row 3 istrained.");
            link.GridDataViewPresenter.UnTrainClicked(2);
            SimpleLog.Info("row 3 untrained");
            Assert.AreEqual(false, link.GridDataViewPresenter.isTrained(2));
            SimpleLog.Info("Assert is false for row 3 istrained.");
        }
    }
}
