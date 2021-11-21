using MarceloStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MarceloStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using MarceloStore.Domain.StoreContext.Entities;
using MarceloStore.Domain.StoreContext.Handlers;
using MarceloStore.Domain.StoreContext.Queries;
using MarceloStore.Domain.StoreContext.Repositories;
using MarceloStore.Domain.StoreContext.ValueObjects;
using MarceloStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarceloStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepositorie _repository;
        private readonly CustomerHandler _handler;
        public CustomerController(ICustomerRepositorie repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }
        [HttpGet]
        [Route("customers")]
        [ResponseCache(Duration = 60)]
        // Cache-Control: public, max-age=60
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);
            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new { message = "Cliente Removido com sucesso!" };
        }
    }
}
