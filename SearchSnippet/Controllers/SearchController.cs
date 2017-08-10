using SearchSnippet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchSnippet.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string name, decimal? minPrice, decimal? maxPrice)
        {
            // Forbedrelse af variabler til senere
            var success = false;
            var message = string.Empty;
            var foundProducts = new List<Product>();

            // Henter data fra databasen
            try
            {
                var db = new SearchContext();
                foundProducts = db.Products.Where(p => p.Name.ToLower().Contains(name.ToLower()) && 
                                  (minPrice.HasValue ? p.Price >= minPrice : true
                                && maxPrice.HasValue ? p.Price <= maxPrice : true)).ToList();

                success = true;
            } catch (Exception ex)
            {
                message = ex.Message;
            }

            // Laver JSON response
            return Json(new
            {
                success = success,
                message = message,
                // Bruger kun de data jeg har behov for fra produkterne til søgeresultaterne
                products = from fp in foundProducts
                           select new
                           {
                               fp.Name,
                               fp.Description,
                               fp.Price,
                               CategoryName = fp.Category.Name,
                               Link = Url.Action("Details", "Product", new { id = fp.ID })
                           }
            });
        }
    }
}