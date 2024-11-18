using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductAndCustomer.Models;
using ProductAndCustomer.DTOs;


namespace ProductAndCustomer.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductAndCustomerEntities1 db = new ProductAndCustomerEntities1();

        // List all products
        public ActionResult ProductList()
        {
            var products = db.Products.ToList();
            return View(products);
        }

        // Create a new product
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    Price = dto.Price,
                    StockQuantity = dto.StockQuantity,
                    Category = dto.Category
                };

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }

            return View(dto);
        }

        // Edit an existing product
        public ActionResult EditProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product == null) return HttpNotFound();

            var dto = new ProductDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category
            };

            return View(dto);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                var product = db.Products.Find(dto.ProductId);
                if (product == null) return HttpNotFound();

                product.Name = dto.Name;
                product.Description = dto.Description;
                product.Price = dto.Price;
                product.StockQuantity = dto.StockQuantity;
                product.Category = dto.Category;

                db.SaveChanges();
                return RedirectToAction("ProductList");
            }

            return View(dto);
        }

        // Delete a product
        public ActionResult DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product == null) 
                return HttpNotFound();

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult ProductDetails(int id)
        {
            var product = db.Products.Find(id);
            if (product == null) return HttpNotFound();
            return View(product);
        }
    }
}