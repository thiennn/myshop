using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyShop.Backend.Data;
using MyShop.Backend.Models;
using MyShop.Backend.Services;
using MyShop.ViewModels;

namespace MyShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStorageService _storageService;
        private readonly ILogger _logger;
        private static readonly ActivitySource DemoSource = new ActivitySource("OTel.Demo");

        public ProductsController(ApplicationDbContext context, IStorageService storageService, ILogger<ProductsController> logger)
        {
            _context = context;
            _storageService = storageService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductVm>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var productVm = new ProductVm
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            productVm.ThumbnailImageUrl = _storageService.GetFileUrl(product.ImageFileName);
            _logger.LogInformation("get product");

            return productVm;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProduct()
        {
            var products = await _context.Products.Select(x =>
                new
                {
                    x.Id,
                    x.Name,
                    x.Price,
                    x.Description,
                    x.ImageFileName
                }).ToListAsync();

            var productVms = products.Select(x => 
                new ProductVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    ThumbnailImageUrl = _storageService.GetFileUrl(x.ImageFileName)
                }).ToList();

            _logger.LogInformation("get products");
            using (var activity = DemoSource.StartActivity("This is sample activity"))
            {
                _logger.LogInformation("Hello, World!aaaaaaaaaaa");
            }

            return productVms;
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromForm]ProductCreateRequest productCreateRequest)
        {
            var product = new Product
            {
                Name = productCreateRequest.Name,
                Description = productCreateRequest.Description,
                Price = productCreateRequest.Price,
                BrandId = productCreateRequest.BrandId
            };

            if(productCreateRequest.ThumbnailImage != null)
            {
                product.ImageFileName = await SaveFile(productCreateRequest.ThumbnailImage);
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, null);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
