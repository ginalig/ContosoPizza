using System;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Contexts
{
    public class PizzaContext : DbContext
    {
        public PizzaContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=contosopizza;Username=ginalig");
        }

        public DbSet<Models.Pizza> pizzas { get; set; }
    }
}
