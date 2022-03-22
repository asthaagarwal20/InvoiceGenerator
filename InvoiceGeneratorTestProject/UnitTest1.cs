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
            invoiceGenerator.AddRide(2, 5);
            invoiceGenerator.AddRide(12, 15);
            var fair = invoiceGenerator.CalculateAggregate();
            Assert.AreEqual(160, fair.totalFare);
        }
        [Test]
        public void CheckForNoOfRides()
        {
            invoiceGenerator.AddRide(2, 5);
            invoiceGenerator.AddRide(12, 15);
            var fair= invoiceGenerator.CalculateAggregate();
            Assert.AreEqual(2, fair.no_of_rides);
        }
        [Test]
        public void CheckForAvgFare()
        {
            invoiceGenerator.AddRide(2, 5);
            invoiceGenerator.AddRide(12, 15);
            var fair = invoiceGenerator.CalculateAggregate();
            Assert.AreEqual(80, fair.avgFare);
        }
    }
}