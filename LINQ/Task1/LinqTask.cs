﻿using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers is null)
                throw new ArgumentNullException();

            return customers.Select(customer => customer)
                    .Where(customer => customer.Orders
                        .Sum(order => order.Total) > limit);
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers is null || suppliers is null)
                throw new ArgumentNullException();


            return customers.Select(
                customer => (
                    customer: customer,
                    suppliers: suppliers.Where(supplier =>
                        supplier.Country == customer.Country
                            && supplier.City == customer.City)));
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers is null || suppliers is null)
                throw new ArgumentNullException();


            var result = customers.Select(
                customer => (
                    customer: customer,
                    suppliers: suppliers.Where(supplier =>
                        supplier.Country == customer.Country
                            && supplier.City == customer.City)));

            return result;
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers is null)
                throw new ArgumentNullException();

            return from customer in customers
                       let sum = customer.Orders.Sum(order => order.Total)
                            where sum > limit && sum > 0
                                select customer;
                   
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            if (customers is null)
                throw new ArgumentNullException();

            return customers.Where(customer => 
                customer.Orders.Count() > 0)
                .Select(customer => (
                    customer: customer,
                    dateOfEntry: customer.Orders
                        .OrderBy(order => order.OrderDate)
                            .First().OrderDate));
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            var result = Linq4(customers);

            return result.OrderBy(item => item.dateOfEntry.Year)
                    .ThenBy(item => item.dateOfEntry.Month)
                        .ThenByDescending(item => 
                            item.customer.Orders.Sum(order => order.Total))
                        .ThenBy(item => item.customer.CompanyName);
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            if (customers is null)
                throw new ArgumentNullException();

            return customers.Where(customer =>
                customer.PostalCode.Any(character => char.IsLetter(character))
                    || String.IsNullOrEmpty(customer.Region) || 
                        ! customer.Phone.Contains('('));
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            if (products is null)
                throw new ArgumentNullException();

            var groupedProductsByCategory = products.GroupBy(product => product.Category);
            
            return groupedProductsByCategory.Select(group =>
                new Linq7CategoryGroup
                {
                    Category = group.Key,
                    UnitsInStockGroup =
                        group.GroupBy(product => product.UnitsInStock)
                            .Select(unit => new Linq7UnitsInStockGroup
                            {
                                UnitsInStock = unit.Key,
                                Prices = unit.OrderBy(product => product.UnitPrice)
                                    .Select(product => product.UnitPrice)
                            })
                });
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            if (suppliers is null)
                throw new ArgumentNullException();

            return String.Join(
                separator: "", 
                values: suppliers.Select(supplier => supplier.Country)
                    .Distinct()
                        .OrderBy(country => country.Length)
                                .ThenBy(country => country));
        }
    }
}