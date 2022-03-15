using Acme.BookStore.CustomerAddresses;
using Acme.BookStore.CustomersAddresses;
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
        IRepository<Customer> _customerRepository;
        IRepository<CustomerAddress> _customerAddressRespository;
        public CustomerAppService(IRepository<Customer, Guid> repository, IRepository<CustomerAddress, Guid> _customerAddressRespository) : base(repository)
        {
            this._customerRepository = repository;
            this._customerAddressRespository = _customerAddressRespository;
        }
      

        public override async Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input)
        {
            var customer = await _customerRepository.InsertAsync(new Customer { FirstName = input.FirstName, MiddleName = input.MiddleName, LastName = input.LastName });
            var customerAddress = await _customerAddressRespository.InsertAsync(new CustomerAddress {CustomerId=customer.Id, AddressLine1="vdgs",AddressLine2="df",City="df",Country="df"});
            var customerDto = ObjectMapper.Map<Customer, CustomerDto>(customer);
            return await Task.FromResult(customerDto);
        }
        /*
          public async override Task<CustomerAddressDto> CreateAsync(CreateUpdateCustomerAddressDto input)
        {
           
            var userAddress= await _customerAddressRepository.InsertAsync(new CustomerAddress { AddressLine1 = input.AddressLine1, AddressLine2 = input.AddressLine2, City = input.City, Country = input.Country } );
            
          //  await uow.CompleteAsync();
            var customerAddressDto = ObjectMapper.Map<CustomerAddress, CustomerAddressDto>(userAddress);
            return customerAddressDto;
        }
         */
    }
}
