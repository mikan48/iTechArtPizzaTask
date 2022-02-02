using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Infrastructure.Context;
using iTechArtPizzaTask.Infrastructure.Repositories;
using iTechArtPizzaTask.WebUI.Controllers;
using iTechArtPizzaTask.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace iTechArtPizzaTask.Core.Tests
{
    //WIP
    public class CartControllerTests
    {
        private readonly Mock<ICartService> _mockService;
        private readonly CartController _controller;

        public CartControllerTests()
        {
            _mockService = new Mock<ICartService>();
            _controller = new CartController(_mockService.Object);
        }

        [Fact]
        public void GetAllPizzasInCartAsync_ActionExecutes_ReturnsAllPizzasInCart()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            List<PizzaViewModel> pizzas = new List<PizzaViewModel>()
            {
                new PizzaViewModel(),
                new PizzaViewModel()
            };
            _mockService.Setup(s => s.GetAllPizzasInCartAsync(id))
                .ReturnsAsync(pizzas);

            // Act
            var result = _controller.GetAllPizzasInCartAsync(id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddPizzaInCartAsync_ActionExecutes_PizzaAdded()
        {
            // Arrange
            var pizza = new Pizza
            {
                Id = Guid.NewGuid(),
                PizzaName = "Name"
            };

            var order = new Order
            {
                Id = Guid.NewGuid(),
                Status = OrderStatuses.INCOMPLETE
            };

            _mockService.Setup(r => r.AddPizzaInCartAsync(pizza.PizzaName, 1, order.Id))
                .Returns(new Task<bool>(() => true));

            // Act
            var res = _controller.AddPizzaInCartAsync(pizza.PizzaName, 1, order.Id);

            // Assert
            Assert.NotNull(res);
        }


        [Fact]
        public void EditPizzasInCartAsync_ActionExecutes_PizzaEdited()
        {
            // Arrange
            var pizza = new Pizza
            {
                Id = Guid.NewGuid(),
                PizzaName = "Name"
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

            _mockService.Setup(r => r.EditPizzasInCartAsync(pizza.PizzaName, 1, order.Id))
                .Returns(new Task<bool>(() => true));

            // Act
            var res = _controller.EditPizzasInCartAsync(pizza.PizzaName, 1, order.Id);

            // Assert
            Assert.NotNull(res);
        }


        [Fact]
        public void DeletePizzaFromCartAsync_ActionExecutes_PizzaDeleted()
        {
            // Arrange
            var pizza = new Pizza
            {
                Id = Guid.NewGuid(),
                PizzaName = "Name"
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

            _mockService.Setup(r => r.DeletePizzaFromCartAsync(pizza.PizzaName, order.Id))
                .Returns(new Task<bool>(() => true));

            // Act
            var res = _controller.DeletePizzaFromCartAsync(pizza.PizzaName, order.Id);

            // Assert
            Assert.NotNull(res);
        }
    }
}
