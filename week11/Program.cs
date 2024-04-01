using System;
using System.Linq;
using week11.Models.Entities;

namespace Week10.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new MMABooksContext())
            {
                // Query all customers using LINQ
                var customers = dbContext.Customers.ToList();

                // Print header
                Console.WriteLine("==== List of Customers ====");

                // Check the number of entries
                int totalEntries = customers.Count;
                Console.WriteLine($"Total Entries: {totalEntries}");

                // If more than 20 entries, ask whether to show all or page by page
                if (totalEntries > 20)
                {
                    Console.WriteLine("There are more than 20 entries.");
                    Console.WriteLine("Do you want to see all entries or page by page? (Type 'all' or 'page')");
                    string userInput = Console.ReadLine();

                    if (userInput.ToLower() == "all")
                    {
                        PrintCustomers(customers);
                    }
                    else if (userInput.ToLower() == "page")
                    {
                        // Print customers page by page (20 entries per page)
                        int currentPage = 1;
                        while (true)
                        {
                            Console.WriteLine($"==== Page {currentPage} ====");
                            var customersOnPage = customers.Skip((currentPage - 1) * 20).Take(20);
                            PrintCustomers(customersOnPage.ToList());

                            Console.WriteLine("Press Enter to view the next page or type 'exit' to quit.");
                            string nextPage = Console.ReadLine();
                            if (nextPage.ToLower() == "exit")
                                break;

                            currentPage++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Exiting...");
                    }
                }
                else
                {
                    // Print all customers
                    PrintCustomers(customers);
                }
            }
        }

        // Method to print customers
        static void PrintCustomers(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Name}");
            }
        }
    }
}
