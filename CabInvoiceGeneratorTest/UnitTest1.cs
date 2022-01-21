using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        // InvoiceGenerator Reference
        InvoiceGenerator invoiceGenerator = null;

        /// <summary>
        /// TestCase-1 : For Checking Calculate Fare Function.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            // Creating Instance of InvoiceGenerator For Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            // Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            // Asserting Values
            Assert.AreEqual(expected, fare);
        }

        
    }
}