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
      

        public  async Task<CustomerDto> getTEST(CreateUpdateCustomerDto input)
        {
            var customerDto2 = await base.CreateAsync(input);
            var customerId = customerDto2.Id;
            var customer = await _customerRepository
                .InsertAsync(
                new Customer { FirstName = input.FirstName, MiddleName = input.MiddleName, LastName = input.LastName },

                true);


            var customerAddress = await _customerAddressRespository
                .InsertAsync(new CustomerAddress { 
                    CustomerId = customerId,
                    AddressLine1 = "vdgs12", 
                    AddressLine2 = "df12121212", 
                    City = "d1212f", 
                    Country = "df1212" 
                },true);

           // var customerAddressDto = ObjectMapper.Map<CustomerAddress, CustomerAddressDto>(customerAddress);
           // customerDto2.Address = customerAddressDto;
            var x = await Task.FromResult(customerDto2);
            return x;
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
