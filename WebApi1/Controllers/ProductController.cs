using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Data.DAL;
using WebApi1.Data.Entity;

namespace WebApi1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }
        public static List<Product> products = new List<Product> {
            new Product { Id = 1, Name = "Product1", Price = 50 },
            new Product { Id = 2, Name = "PRODUCT2", Price = 20 } };

        [HttpGet]
        public List<Product> Get()
        {
            return products;
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOne(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return StatusCode(404);
            return StatusCode(200,product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {


            _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {

            Product dbproduct = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (dbproduct == null)
            {
                return NotFound();
            }
            dbproduct.Name = product.Name;
            dbproduct.Price = product.Price;
            _context.SaveChanges();
            return StatusCode(200);


        }
    }
}
