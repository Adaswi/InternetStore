using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternetStore.Context;
using InternetStore.Models;
using InternetStore.Services.IRepositories;

namespace InternetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(decimal id)
        {
          if (_unitOfWork.Carts == null)
          {
              return NotFound();
          }
            var cart = await _unitOfWork.Carts.GetCartByUserIdAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }
    }
}
