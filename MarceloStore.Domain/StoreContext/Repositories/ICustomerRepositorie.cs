using MarceloStore.Domain.StoreContext.Entities;
using MarceloStore.Domain.StoreContext.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarceloStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepositorie
    {
        bool CheckDocument(string document);

        bool CheckEmail(string email);

        void Save(Customer customer);

        CustomerOrdersCountResult GetCustomerOrdersCount(string document);

        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult Get(Guid id);
        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);
    }
}
