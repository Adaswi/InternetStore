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
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ItemConverter _converter = new ItemConverter();

        public ItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Items
        [HttpGet("Cart/{id}")]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItemsByCart(int id)
        {
          if (_unitOfWork.Items == null)
          {
              return NotFound();
          }
            var items = await _unitOfWork.Items.GetAllVisibleByCartAsync(id);
            return Ok(_converter.Convert(items));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItem(int id)
        {
            if (_unitOfWork.Items == null)
            {
                return NotFound();
            }
            var item = await _unitOfWork.Items.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(_converter.Convert(item));
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemDTO>> PostItem(ItemDTO itemDTO)
        {
          if (_unitOfWork.Items == null)
          {
              return Problem("Entity set 'InternetStoreContext.Items'  is null.");
          }
            var item = new Item()
            {
                CartId = itemDTO.CartId,
                ProductId = itemDTO.ProductId,
                OrderId = itemDTO.OrderId,
                OptionId = itemDTO.OptionId,
                ItemQuantity = itemDTO.ItemQuantity,
                ItemPrice = itemDTO.ItemPrice,
                ItemVisible = itemDTO.ItemVisible
            };

            await _unitOfWork.Items.Insert(item);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetItem", new { id = item.ItemId }, _converter.Convert(item));
        }
    }
}
