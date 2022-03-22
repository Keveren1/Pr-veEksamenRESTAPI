using PrøveEksamenRESTAPI.Manager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrøveEksamenRESTAPI.Models;
using PrøveEksamenRESTAPI.Manager;

namespace PrøveEksamenRESTAPI.Manager.Tests
{
    [TestClass()]
    public class TestSitesManagerTests
    {
        private TestSitesManager _testmanager;
        [TestInitialize()]
        public void SetUp()
        {
            _testmanager = new TestSitesManager();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.IsNotNull(_testmanager);
        }

        [TestMethod()]
        public void AddTestSiteTest()
        {
            var testSite = new TestSite()
            {
                Name = "BingBong",
                WaitingTime = 4
            };
            TestSite test = _testmanager.AddTestSite(testSite);
            Assert.IsNotNull(test);
            Assert.AreEqual(testSite, test);
        }

        [TestMethod()]
        public void DeleteTestSiteTest()
        {
            Assert.IsNotNull(_testmanager.DeleteTestSite(1));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_testmanager.GetById(1));
            Assert.IsNull(_testmanager.GetById(0));

            Assert.AreEqual("Roskilde Kongrescenter", _testmanager.GetById(1).Name);
            Assert.AreEqual(5, _testmanager.GetById(1).WaitingTime);
        }
    }
}