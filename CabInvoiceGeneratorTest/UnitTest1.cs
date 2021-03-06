using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }
        [Test]
        public void GivenMultipleRideShouldReturnAggergateFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(4.0, 5), new Ride(3.0, 5) };
            double AggergateFare = invoiceGenerator.GetMultipleRideFare(rides);
            double expected = 40.0;
            Assert.AreEqual(expected , AggergateFare);
        }
        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 3) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenUserFound_ShouldReturnInvoiceSummary() 
        {
                invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
                string userId = "shivam896satpute@gmail.com"; 
                Ride[] rides = { new Ride(3, 5), new Ride(4, 5) }; 
               InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
               InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);
               Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }
    }
}
