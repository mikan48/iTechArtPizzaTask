using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Infrastructure.Context;
using iTechArtPizzaTask.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace iTechArtPizzaTask.Core.Tests
{
    //WIP
    public class CartTests
    {
        private readonly PizzaDeliveryContext _context;

        [Fact]
        public void AddPizzaInCartAsync_PizzaAlreadyInCart_()
        {
            // Arrange
            var pizza = new Pizza
            {
                Id = Guid.NewGuid()
            };

            var order = new Order
            {
                Id = Guid.NewGuid(),
                Status = OrderStatuses.INCOMPLETE
            };

            var orderedPizza = new OrderedPizza
            {
                Id = Guid.NewGuid(),
                PizzaId = pizza.Id,
                OrderId = order.Id,
                Quantity = 1
            };

            var options = new DbContextOptionsBuilder<PizzaDeliveryContext>()
                .UseInMemoryDatabase(databaseName: "pizzadeliverydb")
                .Options;

            using (var context = new PizzaDeliveryContext(options))
            {
                context.Pizzas.Add(pizza);
                context.Orders.Add(order);
                context.OrderedPizzas.Add(orderedPizza);
                context.SaveChanges();
            }

            var testRepo = new OrderedPizzasRepository(_context);

            // Act
            var newPizza = new OrderedPizza
            {
                PizzaId = pizza.Id,
                OrderId = order.Id,
                Quantity = 1
            };
            testRepo.AddAsync(newPizza).GetAwaiter().GetResult();

            // Assert

            /////////////////////////
        }


        [Fact]
        public void EditPizzasInCartAsync_DontHavePizzaInCart_()
        {
            // Arrange
            var pizza = new Pizza
            {
                Id = Guid.NewGuid()
            };

            var order = new Order
            {
                Id = Guid.NewGuid(),
                Status = OrderStatuses.INCOMPLETE
            };

            var orderedPizza = new OrderedPizza
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Quantity = 1
            };

            var options = new DbContextOptionsBuilder<PizzaDeliveryContext>()
                .UseInMemoryDatabase(databaseName: "pizzadeliverydb")
                .Options;

            using (var context = new PizzaDeliveryContext(options))
            {
                context.Orders.Add(order);
                context.OrderedPizzas.Add(orderedPizza);
                context.SaveChanges();
            }

            var testRepo = new OrderedPizzasRepository(_context);

            // Act
            var orderedPizzas = testRepo.FindItemsById(order.Id);
            OrderedPizza editedPizza = null;
            foreach(OrderedPizza ordered in orderedPizzas)
            {
                if (ordered.PizzaId == pizza.Id)
                {
                    editedPizza = ordered;
                }
            }

            // Assert
            Assert.Null(editedPizza);
        }


        [Fact]
        public void DeletePizzaFromCartAsync_DontHavePizzaInCart_()
        {
            // Arrange
            var pizza = new Pizza
            {
                Id = Guid.NewGuid()
            };

            var order = new Order
            {
                Id = Guid.NewGuid(),
                Status = OrderStatuses.INCOMPLETE
            };

            var orderedPizza = new OrderedPizza
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Quantity = 1
            };

            var options = new DbContextOptionsBuilder<PizzaDeliveryContext>()
                .UseInMemoryDatabase(databaseName: "pizzadeliverydb")
                .Options;

            using (var context = new PizzaDeliveryContext(options))
            {
                context.Pizzas.Add(pizza);
                context.Orders.Add(order);
                context.OrderedPizzas.Add(orderedPizza);
                context.SaveChanges();
            }

            var testRepo = new OrderedPizzasRepository(_context);

            // Act
            var orderedPizzas = testRepo.FindItemsById(order.Id);
            OrderedPizza editedPizza = null;
            foreach (OrderedPizza ordered in orderedPizzas)
            {
                if (ordered.PizzaId == pizza.Id)
                {
                    editedPizza = ordered;
                }
            }

            // Assert
            Assert.Null(editedPizza);
        }
    }
}
