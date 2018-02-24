using SimpleLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_MVP.APITests.APITestFramework;
using test_MVP.APITests.Attributes;

namespace test_MVP.APITests.TestRunner
{
    class Test_Mvp_ApiTests_Runner
    {
        Linker link;
        List<TestInfo> TestResults;
        public Test_Mvp_ApiTests_Runner(Linker link)
        {
            this.link = link;
            MessageBox.Show(link.GetHashCode().ToString());
            TestResults = new List<TestInfo>();
        }

        public void RunTests()
        {
            SimpleLog.SetLogDir("D:\\test",true);
            var classes = GetClassTypesWith<ApiTest>(true);
            SimpleLog.Info("API Testing started....");
            foreach (var type in classes)
            {
                SimpleLog.Info("UseCases in class "+type.Name+" is invoked");
                object classInstance = type.Assembly.CreateInstance(type.FullName);
                var InitializeMethods = type.GetMethods().Where(m => m.GetCustomAttributes(typeof(ApiClassInitialize), false).Length > 0).ToArray();
                foreach (var testmethod in InitializeMethods)
                {
                    object[] obj = new object[] { link };
                    testmethod.Invoke(classInstance, obj);
                }
                var methods = type.GetMethods().Where(m => m.GetCustomAttributes(typeof(ApiUseCase), false).Length > 0).ToArray();
                foreach (var testmethod in methods)
                {
                    SimpleLog.Info("Usecase " + testmethod.Name + " is invoked");
                    TestInfo testinfo = new TestInfo();
                    try
                    {
                        testinfo.ClassName = classInstance.GetType().ToString();
                        testinfo.MethodName = testmethod.Name;
                        testmethod.Invoke(classInstance, null);
                        testinfo.TestSuccess = true;
                        SimpleLog.Info("Usecase Successfully completed");
                    }
                    catch(TargetInvocationException e)
                    {
                        SimpleLog.Info("Usecase Failed");
                        testinfo.TestSuccess = false;
                        testinfo.errorMessage = e.InnerException.Message;
                        SimpleLog.Log(e.InnerException);
                    }catch(Exception e)
                    {
                        SimpleLog.Info("Usecase Failed");
                        testinfo.TestSuccess = false;
                        testinfo.errorMessage = e.Message;
                        SimpleLog.Log(e);
                    }
                    TestResults.Add(testinfo);
                }
             
            }
            SimpleLog.ShowLogFile();
        }

        public List<TestInfo> GetTestResults()
        {
            return TestResults;
        }
        public static IEnumerable<Type> GetClassTypesWith<TAttribute>(bool inherit) where TAttribute : Attribute
        {
            var output = new List<Type>();

            var assembly = Assembly.GetExecutingAssembly();

           
                var assembly_types = assembly.GetTypes();

                foreach (var type in assembly_types)
                {
                    if (type.IsDefined(typeof(TAttribute), inherit))
                        output.Add(type);
                }
           

            return output;
        }

       
    }
}
