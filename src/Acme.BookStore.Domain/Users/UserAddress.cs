using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Users
{
    public class UserAddress : AuditedAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        //NAVIGATION    

        public Guid? UserId { get; set; }//FK
        public virtual TestUser? User { get; set; }

    }
}
