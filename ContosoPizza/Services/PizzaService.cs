using System;
using ContosoPizza.Models;
using System.Collections.Generic;
using System.Linq;
using ContosoPizza.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;

        static PizzaContext db;

        static PizzaService()
        {
            db = new PizzaContext();

        }

        public static List<Pizza> GetAll() =>
            db.pizzas.OrderBy(p => p.Id).ToList();

        public static Pizza Get(int id) =>
            db.pizzas.FirstOrDefault(p => p.Id == id);

        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            db.pizzas.AddAsync(pizza);
            db.SaveChanges();
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);

            if (pizza != null)
                db.pizzas.Remove(pizza);
            db.SaveChanges();
        }

        public static void Update(Pizza pizza)
        {
            var dbPizza = db.pizzas.Where(p => p.Id == pizza.Id).First();

            if (dbPizza is null) return;
            db.pizzas.Remove(db.pizzas.Where(p => p.Id == pizza.Id).First());
            db.pizzas.Add(pizza);

            db.SaveChanges();
        }
    }
}
