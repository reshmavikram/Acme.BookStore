using Acme.BookStore.Books;
using Acme.BookStore.CustomerAddresses;
using Acme.BookStore.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.CustomersAddresses
{
    public class CustomerAddressAppService :
           CrudAppService<
               CustomerAddress, //The Book entity
               CustomerAddressDto, //Used to show books
               Guid, //Primary key of the book entity
               PagedAndSortedResultRequestDto, //Used for paging/sorting
               CreateUpdateCustomerAddressDto>, //Used to create/update a book
           ICustomerAddressAppService //implement the IBookAppService
    {
        public CustomerAddressAppService(IRepository<CustomerAddress, Guid> repository) : base(repository)
        {
        }
    }
}