using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class CartsService : ICartService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Pizza> pizzaRepository;
        private readonly IRepository<OrderedPizza> orderedPizzaRepository;
        public CartsService(IRepository<Order> orderRepository, IRepository<Pizza> pizzaRepository, 
            IRepository<OrderedPizza> orderedPizzaRepository)
        {
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            this.pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));
            this.orderedPizzaRepository = orderedPizzaRepository ?? throw new ArgumentNullException(nameof(orderedPizzaRepository));
        }

        public async Task AddAsync(Guid userId)
        {
            Order order = new Order
            {
                UserId = userId,
                Status = OrderStatuses.INCOMPLETE
            };
            await orderRepository.AddAsync(order);
        }

        public async Task<List<PizzaViewModel>> GetAllPizzasInCartAsync(Guid cartId)
        {
            Order order = await orderRepository.FindItemByIdAsync(cartId);

            List<OrderedPizza> orderedPizzas = orderedPizzaRepository.FindItemsById(order.Id);
            List<PizzaViewModel> pizzas = new();
            Pizza pizza;
            foreach (OrderedPizza orderedPizza in orderedPizzas)
            {
                pizza = await pizzaRepository.FindItemByIdAsync(orderedPizza.PizzaId);
                pizzas.Add(new PizzaViewModel { PizzaName = pizza.PizzaName, PizzaCost = pizza.PizzaCost });
            }
            return pizzas;
        }

        public async Task AddPizzaInCartAsync(string pizzaName, int quantity, Guid cartId)
        {
            Order order = await orderRepository.FindItemByIdAsync(cartId);
            Pizza pizza = await pizzaRepository.FindItemByNameAsync(pizzaName);
            if (order != null && pizza != null)
            {
                double cost = pizza.PizzaCost * quantity;

                OrderedPizza orderedPizza = new OrderedPizza()
                {
                    PizzaId = pizza.Id,
                    Quantity = quantity,
                    OrderId = order.Id
                };

                await orderedPizzaRepository.AddAsync(orderedPizza);

                List<OrderedPizza> orderedPizzas = new();
                orderedPizzas.Add(orderedPizza);

                order.OrderCost = cost;
                order.OrderedPizzas = orderedPizzas;
                order.Status = OrderStatuses.INCOMPLETE;

                await orderRepository.UpdateAsync(order);
            }
        }

        public async Task EditPizzasInCartAsync(string pizzaName, int quantity, Guid cartId)
        {
            Order order = await orderRepository.FindItemByIdAsync(cartId);
            Pizza pizza = await pizzaRepository.FindItemByNameAsync(pizzaName);
            if (order != null && pizza != null)
            {
                int oldQuantity = 0;

                List<OrderedPizza> orderedPizzas = orderedPizzaRepository.FindItemsById(cartId);
                foreach (OrderedPizza orderedPizza in orderedPizzas)
                {
                    if (orderedPizza.PizzaId == pizza.Id)
                    {
                        oldQuantity = orderedPizza.Quantity;
                        orderedPizza.Quantity = quantity;
                        await orderedPizzaRepository.UpdateAsync(orderedPizza);
                    }
                }

                order.OrderCost += (quantity - oldQuantity) * pizza.PizzaCost;
                await orderRepository.UpdateAsync(order);
            }
        }

        public async Task DeletePizzaFromCartAsync(string pizzaName, Guid cartId)
        {
            Order order = await orderRepository.FindItemByIdAsync(cartId);
            Pizza pizza = await pizzaRepository.FindItemByNameAsync(pizzaName);
            if (order != null && pizza != null)
            {
                int quantity = 0;

                List<OrderedPizza> orderedPizzas = orderedPizzaRepository.FindItemsById(cartId);
                foreach (OrderedPizza orderedPizza in orderedPizzas)
                {
                    if (orderedPizza.PizzaId == pizza.Id)
                    {
                        quantity = orderedPizza.Quantity;
                        await orderedPizzaRepository.DeleteAsync(orderedPizza);
                    }
                }

                order.OrderCost -= quantity * pizza.PizzaCost;

                await orderRepository.UpdateAsync(order);
            }
        }
    }
}
