using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrøveEksamenRESTAPI.Models;

namespace PrøveEksamenRESTAPI.Manager
{
    public class TestSitesManager
    {
        private static int nextId = 1;

        private static List<TestSite> data = new List<TestSite>()
        {
            new TestSite() {Id = nextId++, Name = "Roskilde Kongrescenter", WaitingTime = 5},
            new TestSite() {Id = nextId++, Name = "Høje Taastrup", WaitingTime = 30},
            new TestSite() {Id = nextId++, Name = "Alberslund", WaitingTime = 10},
            new TestSite() {Id = nextId++, Name = "København Rådhus", WaitingTime = 60}
        };

        public List<TestSite> GetAll(string? nameFilter, int? waitingTimeFilter)
        {
            List<TestSite> result = new List<TestSite>(data);

            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                result = result.FindAll(filterTestSites =>
                    filterTestSites.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase));
            }

            if (waitingTimeFilter != null)
            {
                result = result.FindAll(filterTestSites =>
                    filterTestSites.WaitingTime == waitingTimeFilter);
            }

            return result;
        }

        public TestSite AddTestSite(TestSite newTestSite)
        {
            newTestSite.Id = nextId++;
            data.Add(newTestSite);
            return newTestSite;
        }

        public TestSite DeleteTestSite(int Id)
        {
            TestSite testSiteData = data.Find(testSiteData => testSiteData.Id == Id);
            data.Remove(testSiteData);
            return testSiteData;
        }

        public TestSite Update(int Id, TestSite updates)
        {
            TestSite test = data.Find(test => test.Id == Id);
            if (test == null) return null;
            test.Name = updates.Name;
            test.WaitingTime = updates.WaitingTime;
            return test;
        }

        public TestSite GetById(int id)
        {
            return data.Find(TestSite => TestSite.Id == id);
        }
    }
}
