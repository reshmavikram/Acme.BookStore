using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Customers
{
    public class CustomerAppService :
        CrudAppService<
            Customer,
            CustomerDto,
             Guid,
              PagedAndSortedResultRequestDto, //Used for paging/sorting
               CreateUpdateCustomerDto>,
            ICustomerAppService
    {
        public CustomerAppService(IRepository<Customer, Guid> repository) : base(repository)
        {
        }
    }
}
