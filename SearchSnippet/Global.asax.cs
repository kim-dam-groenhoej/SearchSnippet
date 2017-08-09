using SearchSnippet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SearchSnippet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (SearchContext db = new SearchContext())
            {
                if (db.Categories.FirstOrDefault(c => c.Name == "Køkken") == null)
                {
                    var category1 = new Category()
                    {
                        Name = "Køkken"
                    };
                    db.Categories.Add(category1);

                    var product1 = new Product()
                    {
                        Name = "Pande",
                        Amount = 50,
                        Price = 150,
                        Description = "Test pande",
                        Category = category1
                    };

                    var product2 = new Product()
                    {
                        Name = "Kniv",
                        Amount = 100,
                        Price = 250,
                        Description = "Designer kniv",
                        Category = category1
                    };

                    var product3 = new Product()
                    {
                        Name = "Grillkniv",
                        Amount = 100,
                        Price = 250,
                        Description = "Grill designer kniv",
                        Category = category1
                    };

                    db.Products.Add(product1);
                    db.Products.Add(product2);
                    db.Products.Add(product3);
                }

                if (db.Categories.FirstOrDefault(c => c.Name == "Værktøj") == null)
                {
                    var category2 = new Category()
                    {
                        Name = "Værktøj"
                    };
                    db.Categories.Add(category2);

                    var product3 = new Product()
                    {
                        Name = "Hammer",
                        Amount = 20,
                        Price = 50,
                        Description = "Vild hammer",
                        Category = category2
                    };

                    db.Products.Add(product3);
                }
               
                db.SaveChanges();
            }
        }
    }
}
