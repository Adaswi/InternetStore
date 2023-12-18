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

namespace InternetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
          if (_unitOfWork.Items == null)
          {
              return NotFound();
          }
            var items = await _unitOfWork.Items.GetAllVisibleAsync();
            return Ok(items);
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(ItemDTO itemDTO)
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

            return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }
    }
}
