using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculationTests.TestHelpers;

namespace CalculationTests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void Test_FlatRate_Controller()
        {
            TestAPILib TestApLib = new TestAPILib();
            TaxApp.Models.TaxCalculationViewModel ViewModelrequest = new TaxApp.Models.TaxCalculationViewModel();
            ViewModelrequest.PostalCode = "flatrate";
            ViewModelrequest.AnnualIncome = 150000;
            TaxApp.Controllers.TaxCalculationController TaxCalculationController = new TaxApp.Controllers.TaxCalculationController(TestApLib,null);
            Microsoft.AspNetCore.Mvc.ViewResult Res = (Microsoft.AspNetCore.Mvc.ViewResult)TaxCalculationController.TaxCalculation(ViewModelrequest).Result;
            TaxApp.Models.TaxCalculationViewModel ViewModelResponse = (TaxApp.Models.TaxCalculationViewModel)Res.Model;
            Assert.AreEqual(26250, ViewModelResponse.CalculationResult);
        }
        [TestMethod]
        public void Test_FlatValue_Under_Controller()
        {
            TestAPILib TestApLib = new TestAPILib();
            TaxApp.Models.TaxCalculationViewModel ViewModelrequest = new TaxApp.Models.TaxCalculationViewModel();
            ViewModelrequest.PostalCode = "flatvalue";
            ViewModelrequest.AnnualIncome = 150000;
            TaxApp.Controllers.TaxCalculationController TaxCalculationController = new TaxApp.Controllers.TaxCalculationController(TestApLib, null);
            Microsoft.AspNetCore.Mvc.ViewResult Res = (Microsoft.AspNetCore.Mvc.ViewResult)TaxCalculationController.TaxCalculation(ViewModelrequest).Result;
            TaxApp.Models.TaxCalculationViewModel ViewModelResponse = (TaxApp.Models.TaxCalculationViewModel)Res.Model;
            Assert.AreEqual(7500, ViewModelResponse.CalculationResult);
        }
        [TestMethod]
        public void Test_FlatValue_Over_Controller()
        {
            TestAPILib TestApLib = new TestAPILib();
            TaxApp.Models.TaxCalculationViewModel ViewModelrequest = new TaxApp.Models.TaxCalculationViewModel();
            ViewModelrequest.PostalCode = "flatvalue";
            ViewModelrequest.AnnualIncome = 250000;
            TaxApp.Controllers.TaxCalculationController TaxCalculationController = new TaxApp.Controllers.TaxCalculationController(TestApLib, null);
            Microsoft.AspNetCore.Mvc.ViewResult Res = (Microsoft.AspNetCore.Mvc.ViewResult)TaxCalculationController.TaxCalculation(ViewModelrequest).Result;
            TaxApp.Models.TaxCalculationViewModel ViewModelResponse = (TaxApp.Models.TaxCalculationViewModel)Res.Model;
            Assert.AreEqual(10000, ViewModelResponse.CalculationResult);
        }

        [TestMethod]
        public void Test_Progressive_large_Controller()
        {
            TestAPILib TestApLib = new TestAPILib();
            TaxApp.Models.TaxCalculationViewModel ViewModelrequest = new TaxApp.Models.TaxCalculationViewModel();
            ViewModelrequest.PostalCode = "progressive";
            ViewModelrequest.AnnualIncome = 374000;
            TaxApp.Controllers.TaxCalculationController TaxCalculationController = new TaxApp.Controllers.TaxCalculationController(TestApLib, null);
            Microsoft.AspNetCore.Mvc.ViewResult Res = (Microsoft.AspNetCore.Mvc.ViewResult)TaxCalculationController.TaxCalculation(ViewModelrequest).Result;
            TaxApp.Models.TaxCalculationViewModel ViewModelResponse = (TaxApp.Models.TaxCalculationViewModel)Res.Model;
            Assert.AreEqual(108583.50, ViewModelResponse.CalculationResult);
        }

        [TestMethod]
        public void Test_Progressive_Small_Controller()
        {
            TestAPILib TestApLib = new TestAPILib();
            TaxApp.Models.TaxCalculationViewModel ViewModelrequest = new TaxApp.Models.TaxCalculationViewModel();
            ViewModelrequest.PostalCode = "progressive";
            ViewModelrequest.AnnualIncome = 7000;
            TaxApp.Controllers.TaxCalculationController TaxCalculationController = new TaxApp.Controllers.TaxCalculationController(TestApLib, null);
            Microsoft.AspNetCore.Mvc.ViewResult Res = (Microsoft.AspNetCore.Mvc.ViewResult)TaxCalculationController.TaxCalculation(ViewModelrequest).Result;
            TaxApp.Models.TaxCalculationViewModel ViewModelResponse = (TaxApp.Models.TaxCalculationViewModel)Res.Model;
            Assert.AreEqual(700, ViewModelResponse.CalculationResult);
        }
    }
}
