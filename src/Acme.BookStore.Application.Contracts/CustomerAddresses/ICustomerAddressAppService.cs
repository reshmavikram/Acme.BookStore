using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.CustomerAddresses
{
    public interface ICustomerAddressAppService :
       ICrudAppService< //Defines CRUD methods
           CustomerAddressDto, //Used to show books
           Guid, //Primary key of the book entity
           PagedAndSortedResultRequestDto, //Used for paging/sorting
           CreateUpdateCustomerAddressDto> //Used to create/update a book
    {

    }
}
