using Acme.BookStore.CustomersAddresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Customers
{
    public class Customer: AuditedAggregateRoot<Guid>
    {
       
        public string FirstName { get; set; }
   
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        //Navigation
      public virtual CustomerAddress? Address { get; set; }

    }
}
