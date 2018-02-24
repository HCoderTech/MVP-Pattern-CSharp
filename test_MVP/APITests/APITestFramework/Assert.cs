using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_MVP.APITests.APITestFramework
{
    public static class Assert
    {
        public static void AreEqual(object expected,object actual)
        {
            if (!expected.Equals(actual))
                throw new ApiTestException("Both are not equal.Expected :"+expected.ToString()+" Actual:"+actual.ToString());
        }
    }
}
