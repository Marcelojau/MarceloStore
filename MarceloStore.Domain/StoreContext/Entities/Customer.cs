using System.Collections.Generic;
using System.Linq;
using MarceloStore.Domain.StoreContext.ValueObjects;
using MarceloStore.Shared.Entities;

namespace MarceloStore.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {
        private readonly IList<Address> _adresses;

        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _adresses = new List<Address>();
        }

        public Name Name {get; private set;}
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _adresses.ToArray(); 

        public void AddAddress(Address address)
        {   
            _adresses.Add(address);   
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}