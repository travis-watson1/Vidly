using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Microsoft.AspNetCore.Mvc.Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        //GET /api/customers
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            var customers =_context.Customers.Include(c => c.MembershipType).ToList();

            return customers;
        }

        //GET /api/customers/1
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        //POST /api/customers
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult CreateCustomer([Microsoft.AspNetCore.Mvc.FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Ok(customer);
        }


        // PUT /api/customers/1
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, [Microsoft.AspNetCore.Mvc.FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (customer.Id == 0)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }

        //DELETE /api/customers/1
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute]int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }
    }
}
