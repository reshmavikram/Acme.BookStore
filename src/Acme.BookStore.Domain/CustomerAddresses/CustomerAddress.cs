using Acme.BookStore.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.CustomersAddresses
{
    public class CustomerAddress : AuditedAggregateRoot<Guid>
    {
       
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        //NAVIGATION    

      public Guid? CustomerId { get; set; }//FK
       public virtual Customer? Customer { get; set; }

    }
}
