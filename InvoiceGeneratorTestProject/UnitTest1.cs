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
    }
}