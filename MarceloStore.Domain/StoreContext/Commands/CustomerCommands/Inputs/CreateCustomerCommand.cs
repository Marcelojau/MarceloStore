﻿using FluentValidator;
using FluentValidator.Validation;
using MarceloStore.Shared.Commands;

namespace MarceloStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 3 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter no máximo 3 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O nome deve conter no máximo 3 caracteres")
                .IsEmail(Email,"Email","O E-mail é inválido")
                .HasLen(Document, 11, "Document", "CPF inválido")
            );

            return IsValid;
        }
    }
}
