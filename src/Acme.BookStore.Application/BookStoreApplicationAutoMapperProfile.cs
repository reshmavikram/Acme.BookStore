using Acme.BookStore.Books;
using Acme.BookStore.CustomerAddresses;
using Acme.BookStore.Customers;
using Acme.BookStore.CustomersAddresses;
using AutoMapper;

namespace Acme.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Customer, CustomerDto>();
        CreateMap<CreateUpdateCustomerDto, Customer>();

        CreateMap<CustomerAddress, CustomerAddressDto>();
        CreateMap<CreateUpdateCustomerAddressDto, CustomerAddress>();
    }
}
