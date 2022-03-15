using Acme.BookStore.CustomerAddresses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Customers
{
    public class CustomerDto : AuditedEntityDto<Guid>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string? MiddleName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public virtual CustomerAddressDto? Address { get; set; }
    }
}
