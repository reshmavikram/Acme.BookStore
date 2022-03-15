using Acme.BookStore.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.CustomerAddresses
{
    public class CustomerAddressDto : AuditedEntityDto<Guid>
    {
        [Required]
        public string? AddressLine1 { get; set; }
        [Required]
        public string? AddressLine2 { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Country { get; set; }
        
        public Guid? CustomerId { get; set; }//FK
        public virtual CustomerDto? Customer { get; set; }
    }
}
