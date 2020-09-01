using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using AutoMapper;
using Microsoft.Win32;
using MovieRentalWebApplication.Models;


namespace MovieRentalWebApplication.Controllers
{
    public class CustomersController : Controller
    {

        VideoRentalDbContext db = new VideoRentalDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> customers = db.Customers.ToList();

            return View(customers);
        }

        public ActionResult View(int id)
        {
            Customer customer = db.Customers.Where(s => s.CustomerId == id).SingleOrDefault();
            return View(customer);
        }

        public ActionResult Register()
        {
            Customer cust = new Customer();
            List<MembershipType> types = db.MembershipTypes.ToList();
            ViewBag.MembershipTypes = types;
            return View(cust);

        }

        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            db.Customers.Add(cust);

            db.SaveChanges();
            Session["CurrentCustomerName"] = cust.Name;
            Session["CurrentCustomerId"] = Convert.ToInt32(cust.CustomerId);
            return RedirectToAction("Index", "Customers");

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(string Name)
        {
            Customer cust = db.Customers.Where(s => s.Name.Contains(Name)).SingleOrDefault();
            if (cust != null)
            {
                Session["CurrentCustomerName"] = cust.Name;
                Session["CurrentCustomerId"] = cust.CustomerId;
                return RedirectToAction("Index", "Customers");
            }

            return View();
        }

        public ActionResult Edit()
        {
            int id = Convert.ToInt32(Session["CurrentCustomerId"]);
            Customer cust = db.Customers.Where(s => s.CustomerId == id).SingleOrDefault();
            return View(cust);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            int id = Convert.ToInt32(Session["CurrentCustomerId"]);
            Customer cust = db.Customers.Where(s => s.CustomerId == id).SingleOrDefault();
            if (cust != null)
            {
                cust.MembershipTypeId = customer.MembershipTypeId;
                cust.DateOfBirth = customer.DateOfBirth;
                db.SaveChanges();
            }
            return RedirectToAction("Index","Customers");
        }
    }
}