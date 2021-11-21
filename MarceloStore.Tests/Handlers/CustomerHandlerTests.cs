using MarceloStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MarceloStore.Domain.StoreContext.Handlers;
using MarceloStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarceloStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Andre";
            command.LastName = "Teste";
            command.Document = "38946145870";
            command.Email = "marcelo@teste.com.br";
            command.Phone = "14998778899";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());

            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);

        }
    }
}
