using InvoiceGenerator;
using NUnit.Framework;

namespace InvoiceGeneratorTestProject
{
    public class Tests
    {
        public CabInvoiceGenerator invoiceGenerator;
       [SetUp]
        public void Setup()
        {
            invoiceGenerator = new CabInvoiceGenerator();
        }

        [Test]
        public void Test1()
        {
            double fair = invoiceGenerator.CalculateFair(2, 5);
            Assert.AreEqual(25,fair);
        }
        [Test]
        public void CheckForMinimumFairAsFive()
        {
            double fair = invoiceGenerator.CalculateFair(0, 0);
            Assert.AreEqual(5, fair);
        }
        [Test]
        public void CheckForTotalFare()
        {

            invoiceGenerator.AddRide("Astha", 2, 5);
            invoiceGenerator.AddRide("Asita", 12, 15);
            var fair = invoiceGenerator.CalculateAggregate("Asita");
            Assert.AreEqual(135, fair.totalFare);
        }
        [Test]
        public void CheckForNoOfRides()
        {
            invoiceGenerator.AddRide("Astha",2, 5);
            invoiceGenerator.AddRide("Asita",12, 15);
            var fair= invoiceGenerator.CalculateAggregate("Astha");
            Assert.AreEqual(1, fair.no_of_rides);
        }
        [Test]
        public void CheckForAvgFare()
        {
            invoiceGenerator.AddRide("Astha", 2, 5);
            invoiceGenerator.AddRide("Asita", 12, 15);
            var fair=invoiceGenerator.CalculateAggregate("Astha");
            Assert.AreEqual(25, fair.avgFare);
        }
    }
}