using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_MVP.APITests.Attributes;

namespace test_MVP.APITests.Tests
{
    [ApiTest]
    class SlowTests
    {
        [ApiUseCase]
        public void TestMethod()
        {
            MessageBox.Show("New Method");
        }
    }
}
