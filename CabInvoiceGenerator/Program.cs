using System;

namespace CabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator");

            // UC1 : Total fare for single drive
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double fare = invoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine($"Fare : {fare}");

            // UC2 : Total fare for multiple drive
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary totalFare = invoiceGenerator.CalculateFare(rides);
            Console.WriteLine("\nTotal Fare Of Journey for multiple rides : " + totalFare);

            //// UC2 : Inhanced Invoice should return 1.Total no of rides, 2.Total Fare, 3.Average Fare Per Rides
            //Ride[] rides1 = { new Ride(2.0, 5), new Ride(0.1, 1) };
            //double totalFare1 = invoiceGenerator.CalculateFare(rides1);
            //Console.WriteLine("\nTotal Fare Of Journey for multiple rides : " + totalFare1);
        }
    }
}
