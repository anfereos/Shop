namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;
        private Random random;

        public SeedDb(DataContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userManager.FindByEmailAsync("anfereos@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Andres",
                    LastName = "Restrepo",
                    Email = "anfereos@gmail.com",
                    UserName = "anfereos@gmail.com",
                    PhoneNumber = "3148129955"
                };

                var result = await this.userManager.CreateAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se creo el usuario en el seeder");
                }
            }

            if (!this.context.Products.Any())
            {
                this.AddProduct("Apple Watch", user);
                this.AddProduct("MacBookPro", user);
                this.AddProduct("MacBookAir", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(50),
                User = user
            });
        }
    }
}
