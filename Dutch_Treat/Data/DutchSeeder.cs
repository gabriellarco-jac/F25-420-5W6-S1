using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Dutch_Treat.Data
{
    public class DutchSeeder
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hosting;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public DutchSeeder(ApplicationDbContext context, 
            IWebHostEnvironment hosting, 
            RoleManager<IdentityRole<int>> roleManager)
        {
            _db = context;
            _hosting = hosting;     //will be used to find the full path of the project 
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            //Verify that the database exists. Hover over the method and read the documentation. 
            _db.Database.EnsureCreated();

            if (!_roleManager.Roles.Any()) 
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Supervisor"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Default"));
            }

            //If there are no products then create the sample data from art.json
            if (!_db.Products.Any())
            {
                //ContentRootPath is refering to the folders not related to wwwroot
                var file = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(file);

                //Deserialise the json file into the List of Product class
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);

                //Add the new list of products to the database
                _db.Products.AddRange(products);

                //Create a sample order 
                var order = new Order()
                {
                    OrderDate = DateTime.Today,
                    OrderNumber = "10000",
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    }
                };

                _db.Orders.Add(order);

                _db.SaveChanges();  //commit changes to the database (make permanent) 
            }
        }
    }
}
