using MarceloStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarceloStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("", "Baltieri");
            Assert.AreEqual(false, name.IsValid);
            Assert.AreEqual(1, name.Notifications.Count);
        }

    }
}
