using MarceloStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarceloStore.Tests.Commandas
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Marcelo";
            command.LastName = "Gomes";
            command.Document = "38946145870";
            command.Email = "marcelogn2010@hotmail.com";
            command.Phone = "14998086693";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
