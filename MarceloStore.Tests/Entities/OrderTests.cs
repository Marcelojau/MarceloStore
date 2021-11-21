using MarceloStore.Domain.StoreContext.Entities;
using MarceloStore.Domain.StoreContext.Enums;
using MarceloStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarceloStore.Tests.ValueObjects
{
    [TestClass]
    public class OrderTests
    {
        private Customer _customer;
        private Order _order;
        private Product _mouse;
        private Product _keyBoard;
        private Product _chair;
        private Product _monitor;
        public OrderTests()
        {
            var name = new Name("Andre", "Baltieri");
            var document = new Document("38946145870");
            var email = new Email("marcelon18@yahoo.com.br");
            _customer = new Customer(name, document, email, "5514998085577");
            _order = new Order(_customer);
            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyBoard = new Product("Teclado Gamer", "Teclado Gamer", "teclado.jpg", 100M, 10);
            _chair = new Product("Cadeira Gamer", "Cadeira Gamer", "cadeira.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Gamer", "monitor.jpg", 100M, 10);
        }

        // Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // Ao criar o pedido, o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreateWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        // Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }


        // Ao confirmar pedido, deve gerar um número
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }



        // Ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }


        // Dado 10 produtos, devem haver duas entregas

        [TestMethod]
        public void ShouldTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);

            _order.Ship(); 

            Assert.AreEqual(2, _order.Deliveries.Count);

            
        }


        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceldWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);

            _order.Ship();

            _order.Cancel();

            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }


    }
}
