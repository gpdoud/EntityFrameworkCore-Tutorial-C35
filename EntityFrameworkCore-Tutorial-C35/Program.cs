using EntityFrameworkCore_Tutorial_C35.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore_Tutorial_C35 {

    internal class Program {

        static void Main(string[] args) {

            AppDbContext context = new AppDbContext();

            // delete a customer
            var amazon = context.Customers.SingleOrDefault(c => c.Name == "Amazon");

            if(amazon != null) {
                context.Customers.Remove(amazon);
                context.SaveChanges();
            }

            // update a customer
            //var max = context.Customers.Find(1);

            //max.Sales += 5000;

            //context.SaveChanges();

            // add a new customer
            //var newCustomer = new Customer() {
            //    Id = 0, Name = "Kroger", Active = true,
            //    Sales = 3000000, Updated = new DateTime(2022, 2, 11)
            //};
            //context.Customers.Add(newCustomer);
            //context.SaveChanges();

            // read customer by primary key
            //var customer = context.Customers.Find(2);
            //Console.WriteLine($"{customer.Name} {customer.Sales:c}");

            // read all customers
            var customers = from cust in context.Customers
                            //where cust.Sales < 100000
                            select cust;

            //List<Customer> customers = context.Customers
            //                                    .Where(cust => cust.Sales < 100000)
            //                                    .ToList();

            foreach (var customer in customers) {
                Console.WriteLine($"{customer.Name,-20} {customer.Sales,10:c}");
            }
        }
    }
}
