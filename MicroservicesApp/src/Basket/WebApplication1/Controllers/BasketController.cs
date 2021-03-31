using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("äpi/v1/[Controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(BasketCart),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCart>> GetBasket(string userName)
        {
            var basket = await _repository.GetBasket(userName);
            return Ok(basket?? new BasketCart(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCart>> UpdateCart([FromBody]BasketCart basket)
        {
            return Ok(await _repository.UpdateBasket(basket));
            
        }


        [HttpDelete("{userName}", Name = "DeleteCart")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task DeleteCart(string userName)
        {
             await _repository.DeleteBasket(userName);

        }
    }
}
