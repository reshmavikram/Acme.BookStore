using Acme.BookStore.CustomerAddresses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.Customers
{
    public class CreateUpdateCustomerDto
    {
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public CreateUpdateCustomerAddressDto? Addresses { get; set; }
    }
}
