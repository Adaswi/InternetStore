using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternetStore.Context;
using InternetStore.Models;
using InternetStore.Services.Repositories;
using InternetStore.Services.IRepositories;
using InternetStore.Converters;
using InternetStore.DTOs;

namespace InternetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductConverter productConverter = new ProductConverter();
        private readonly SingleProductConverter singleProductConverter = new SingleProductConverter();
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
          if (_unitOfWork.Products == null)
          {
              return NotFound();
          }
            var products = productConverter.Convert(await _unitOfWork.Products.GetAllVisibleAsync());

          return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SingleProductDTO>> GetProduct(decimal id)
        {
          if (_unitOfWork.Products == null)
          {
              return NotFound();
          }
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(singleProductConverter.Convert(product));
        }
    }
}
