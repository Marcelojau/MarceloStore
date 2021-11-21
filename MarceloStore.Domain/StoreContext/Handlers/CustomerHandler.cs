using FluentValidator;
using MarceloStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MarceloStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using MarceloStore.Domain.StoreContext.Entities;
using MarceloStore.Domain.StoreContext.Repositories;
using MarceloStore.Domain.StoreContext.Services;
using MarceloStore.Domain.StoreContext.ValueObjects;
using MarceloStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarceloStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepositorie _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepositorie repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF já existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");
            // Verificar se o E-mail já existe na base
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este E-mail já está em uso");

            // Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar a Entidade
            var customer = new Customer(name, document, email, command.Phone);


            // Valir entidades e VoS
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CommandResult(false, "Por faovr, corrija os campos abaixo", Notifications);

            // Persistir o cliente
            _repository.Save(customer);
            // Enviar um E-mail de boas vindas
            _emailService.Send(email.Address, "hello@balta.io", "Bem vindo", "Seja bem vindo ao Marcelo Store");

            // Retornar o resultado para a tela
            return new CommandResult(true, "Bem vindo ao marcelo store", new { 
                Id = customer.Id,
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
