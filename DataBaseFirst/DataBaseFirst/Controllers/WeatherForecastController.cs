using DataBaseFirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseFirst.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("GetAllCategories")]
        public IEnumerable<Category> GetCategories()
        {
            using (var context = new ShopContext())
            {
                return context.Categories.ToList();
            }
        }

        [HttpGet("GetCategoryById")]
        public IEnumerable<Category> GetCategoryById([FromQuery] int id)
        {
            using (var context = new ShopContext())
            {
                return context.Categories.Where(category => category.CategoryId == id).ToList();
            }
        }

        [HttpPost("AddNewCategory")]
        public IEnumerable<Category> AddCategory()
        {
            using (var context = new ShopContext())
            {
                Category category = new Category();
                category.CategoryName = "Test2";
                context.Categories.Add(category);
                context.SaveChanges();
                return context.Categories.ToList();
            }
        }

        [HttpPut]
        public ActionResult UpdateCategory()
        {
            using (var context = new ShopContext())
            {
                Category category = context.Categories.Where(category => category.CategoryName == "Test").FirstOrDefault();
                category.CategoryName = "MyCategory";

                context.SaveChanges();
                return Ok(category);
            }
        }
        [HttpDelete]
        public ActionResult DeleteCategory()
        {
            using (var context = new ShopContext())
            {
                Category category = context.Categories.Where(category => category.CategoryName == "Test2").FirstOrDefault();
                context.Categories.Remove(category);
                return Ok();
            }
        }
    }
}
