using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductAndCustomer.Models;
using ProductAndCustomer.DTOs;
using System.Data.Entity;


namespace ProductAndCustomer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ProductAndCustomerEntities1 db = new ProductAndCustomerEntities1();
        // GET: Customer
        public ActionResult CustomerList()
        {
            var customers = db.Customers.ToList();
            return View(customers);
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customer model)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(model);
                db.SaveChanges();
                return RedirectToAction("CustomerList");
            }
            return View(model);
        }

        // GET: Customer/Details/5
        public ActionResult CustomerDetails(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult EditCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Ensure the entity exists before modifying it
                var existingCustomer = db.Customers.Find(customer.CustomerId);
                if (existingCustomer == null)
                {
                    return HttpNotFound(); // Entity not found
                }

                // Update the fields manually
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.Address = customer.Address;
                existingCustomer.DateJoined = customer.DateJoined;

                // Save changes
                db.SaveChanges();

                return RedirectToAction("CustomerList");
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public ActionResult DeleteCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }

    }
}