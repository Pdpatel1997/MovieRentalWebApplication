using MovieRentalWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieRentalWebApplication.Dtos;
using AutoMapper;
using System.Collections.Specialized;

namespace MovieRentalWebApplication.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private VideoRentalDbContext db;

        public CustomersController()
        {
            db = new VideoRentalDbContext();
        }
        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return db.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        // GET /api/customers/id

        public IHttpActionResult GetCustomer(int id)
        {
            var cust = db.Customers.SingleOrDefault(s => s.CustomerId == id);
            if (cust == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>(cust));
        }

        //POST /api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto cust)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(cust);
            db.Customers.Add(customer);
            db.SaveChanges();

            cust.CustomerId = customer.CustomerId;
            return Created(new Uri(Request.RequestUri+"/"+customer.CustomerId),cust);
        }

        //PUT /api/customers/id
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto cust)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = db.Customers.SingleOrDefault(s => s.CustomerId == id);
             
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(cust, customer);
          

            db.SaveChanges();
        }

        //Delete api/customers/delete/id

            [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(s => s.CustomerId == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Customers.Remove(customer);
            db.SaveChanges();
        }
    }
}
