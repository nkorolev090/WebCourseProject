﻿using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICartService cartService;

        public CartController(ILogger<CarsController> logger, ICartService cartService)
        {
            _logger = logger;
            this.cartService = cartService;
        }

        // GET: api/<CartController>
        [HttpGet(nameof(GetCart))]
        [Authorize(Roles = "client")]
        public async Task<ActionResult<CartDTO?>> GetCart()
        {
            try
            {
                return await cartService.GetUserCartDTO(HttpContext.User);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }
        }

        // PUT: api/<CartController>/AddCartItem
        [HttpPut(nameof(AddCartItem))]
        [Authorize(Roles = "client")]
        public async Task<ActionResult<CartDTO?>> AddCartItem(int slotId, int breakdownId)
        {
            try
            {
                var result = await cartService.AddCartItem(HttpContext.User, slotId, breakdownId);
                if (result == true)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }
        }

        // PUT: api/<CartController>/RemoveCartItem
        [HttpPut(nameof(RemoveCartItem))]
        [Authorize(Roles = "client")]
        public async Task<ActionResult<CartDTO?>> RemoveCartItem(int breakdownId)
        {
            try
            {
                var result = await cartService.RemoveCartItem(HttpContext.User, breakdownId);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }
        }

        // PUT: api/<CartController>/SetPromocode
        [HttpPut(nameof(SetPromocode))]
        [Authorize(Roles = "client")]
        public async Task<ActionResult<CartDTO?>> SetPromocode(string promocode)
        {
            try
            {
                var result = await cartService.SetPromocode(HttpContext.User, promocode);
                if (result == true)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }
        }
    }
}
