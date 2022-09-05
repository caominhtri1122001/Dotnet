using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Services;

namespace ProductManager.Controllers
{
    public class ProductController : Controller
    {
        // private readonly DataContext _context;
        // public ProductController(DataContext context)
        // {
        //     _context = context;
        // }

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            // var products = _context.Products.ToList();
            var products = _productService.GetProduct();
            return View(products);
        }

        public IActionResult Create()
        {
            var categories = _productService.GetCategories();
            return View(categories);
        }

        public IActionResult Update(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return RedirectToAction("Create");
            var categories = _productService.GetCategories();
            ViewBag.Categories = categories;
            return View(product);
        }

        public IActionResult Save(Product product)
        {
            _productService.CreateProduct(product);
            return RedirectToAction("Index");
        }
    }
}