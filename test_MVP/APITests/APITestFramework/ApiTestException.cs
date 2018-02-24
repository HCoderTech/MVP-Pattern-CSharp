using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_MVP.APITests.APITestFramework
{
    class ApiTestException:Exception
    {
        private string error;

        public string ErrorMessage
        {
            get
            {
                return error;
            }

            set
            {
                error = value;
            }
        }

        public ApiTestException(string error):base(error)
        {
            ErrorMessage = error;
        }
    }
}
