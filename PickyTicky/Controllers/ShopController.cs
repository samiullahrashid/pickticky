using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickyTicky.Models;

namespace PickyTicky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ShopModel>> Get()
        {
            List<ShopModel> shops = new List<ShopModel>();
            for (var i = 0; i < 10; i++)
            {
                shops.Add(new ShopModel()
                {
                    Id = i,
                    Address = "Lahore",
                    CreatedOn = DateTime.Now.AddDays(-i),
                    Latitude = GetRandomNumber(0.0, 99.99),
                    Longtitude = GetRandomNumber(0.0, 99.99),
                    LogoUrl = "../ff/logo.png",
                    Name = "Shop No:" + i,
                    OwnerId = i,
                    Status = true

                });
            }
            return shops;
        }

        [HttpGet("{id}")]
        public ActionResult<ShopModel> Get(int id)
        {
            return new ShopModel()
            {
                Id = id,
                Address = "Lahore",
                CreatedOn = DateTime.Now.AddDays(-id),
                Latitude = GetRandomNumber(0.0, 99.99),
                Longtitude = GetRandomNumber(0.0, 99.99),
                LogoUrl = "../ff/logo.png",
                Name = "Shop No:" + id,
                OwnerId = id,
                Status = true

            };
        }
    }
}