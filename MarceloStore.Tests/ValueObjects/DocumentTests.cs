using MarceloStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarceloStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;
        
        public DocumentTests()
        {
            validDocument = new Document("38946145870");
            invalidDocument = new Document("1234567891011");
        }
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {

            Assert.AreEqual(false, invalidDocument.IsValid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenDocumentIsValid()
        {

            Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
