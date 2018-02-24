using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_MVP.APITests.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    class ApiUseCase:Attribute
    {
        public string UseCaseDescription { get; set;}
    }
    [AttributeUsage(AttributeTargets.Class)]
    class ApiTest :Attribute
    {
        public string TestDescription { get; set;}
    }

    class ApiClassInitialize : Attribute
    {
        public string Description { get; set; }
    }
}
