using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project01.Data;
using project01.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace project01.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        
        public ProductController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(Product product, IFormFile productpicture)
        {
            if (ModelState.IsValid)
            {
                if (productpicture != null && productpicture.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await productpicture.CopyToAsync(stream);
                        product.ProductPicture = stream.ToArray();
                    }
                }

                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
    

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile productpicture)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingProduct = await db.Products.FindAsync(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                if (productpicture != null && productpicture.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await productpicture.CopyToAsync(stream);
                        existingProduct.ProductPicture = stream.ToArray();
                    }
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.Quantity = product.Quantity;

                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }


        [HttpGet]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
