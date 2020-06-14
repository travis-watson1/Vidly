﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public ViewResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }


        public IActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }


        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id = 1, Name = "John Smith" },
                new Customer{Id = 2, Name = "John Bob Billy" }
            };
        }
    }
}