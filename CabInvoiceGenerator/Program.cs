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
            double totalFare = invoiceGenerator.CalculateFare(rides);
            Console.WriteLine("\nTotal Fare Of Journey for multiple rides : " + totalFare);
        }
    }
}
