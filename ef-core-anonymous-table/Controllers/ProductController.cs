using AutoMapper;
using ef_core_anonymous_table.Data;
using ef_core_anonymous_table.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ef_core_anonymous_table.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(ProductDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }
        [HttpGet]
        public ActionResult getAllProducts()
        {
            var a = _context.Products.ToList();
            //var a = _context.PriceUpdateViews.ToList();
            return Ok(a);
        }
        [HttpPost]
        public ActionResult createPrducts(List<Product> products)
        {
            foreach (var product in products)
            {
                _context.Products.Add(product);
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("updatePrice")]
        public ActionResult upadteProductPrice(List<UpdateProductPriceReq> ListOfReq)
        {
            //method 01 - bulk update method 

            //foreach (var req in ListOfReq)
            //{
            //    var p = _context.Products.FirstOrDefault(c => c.Id == req.ID);
            //    if (p != null)
            //    {
            //        p.Price = req.Price;
            //    }
            //}
            //_context.SaveChanges();

            // method 02 - update using update keyword 

            //foreach (var req in ListOfReq)
            //{
            //    var p = _context.Products.FirstOrDefault(c => c.Id == req.ID);
            //    if (p != null)
            //    {
            //        p.Price = req.Price;
            //    }
            //    _context.Products.Update(p);
            //}
            //_context.SaveChanges();

            // method 03 - update using views  - we can not proceed because Ef core Doesn't support update views 
           
            //foreach (var req in ListOfReq)
            //{
            //    var p = _context.PriceUpdateViews.FirstOrDefault(c => c.Id == req.ID);
            //    if (p != null)
            //    {
            //        p.Price = req.Price;
            //        _context.PriceUpdateViews.Update(p);
            //    }
            //}
            //_context.SaveChanges();

            //method 04 - update using automapper method 

            foreach(var req in ListOfReq)
            {
                var p = _context.Products.FirstOrDefault(p=>p.Id == req.ID);
                if(p != null)
                {
                    var result = _mapper.Map<Product>(p);
                    _context.Products.Update(result);    
                }
                
            }
            _context.SaveChanges();


            return Ok();
        }
    }

    public class UpdateProductPriceReq
    {
        public int ID { get; set; }
        public double Price { get; set; }
    }
}
