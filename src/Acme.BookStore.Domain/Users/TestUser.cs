using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Users
{
    public class TestUser: AuditedAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
   
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        //Navigation
        public virtual UserAddress? Address { get; set; }

    }
}
