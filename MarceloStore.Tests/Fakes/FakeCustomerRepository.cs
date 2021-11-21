using MarceloStore.Domain.StoreContext.Entities;
using MarceloStore.Domain.StoreContext.Queries;
using MarceloStore.Domain.StoreContext.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarceloStore.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepositorie
    {

        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
            
        }
    }
}
