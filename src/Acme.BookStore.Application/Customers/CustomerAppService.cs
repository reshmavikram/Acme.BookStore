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
    public class CustomerAppService :CrudAppService<Customer,CustomerDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateCustomerDto>,ICustomerAppService
    {
        IRepository<Customer> _customerRepository;
        IRepository<CustomerAddress> _customerAddressRespository;
        public CustomerAppService(IRepository<Customer, Guid> repository, IRepository<CustomerAddress, Guid> _customerAddressRespository) : base(repository)
        {
            this._customerRepository = repository;
            this._customerAddressRespository = _customerAddressRespository;
        }
        //Built in APIs

        public override Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task<CustomerDto> UpdateAsync(Guid id, CreateUpdateCustomerDto input)
        {
            return base.UpdateAsync(id, input);
        }
        protected override Task DeleteByIdAsync(Guid id)
        {
            return base.DeleteByIdAsync(id);
        }


        //custom APIs
        public async Task<CustomerDto> GETTestDocument(CreateUpdateCustomerDto input)
        {
            try
            {
                var customerDto = await base.CreateAsync(input);
                var newCustomer = ObjectMapper.Map<CreateUpdateCustomerDto, Customer>(input);
                var customer = await _customerRepository.InsertAsync(newCustomer, true);

                if (input.Addresses != null)
                {
                    var addressObj = ObjectMapper.Map<CreateUpdateCustomerAddressDto, CustomerAddress>(input.Addresses);
                    var address = await _customerAddressRespository.InsertAsync(addressObj, true);
                    input.Addresses = ObjectMapper.Map<CustomerAddress, CreateUpdateCustomerAddressDto>(address);//
                }

                var resultDto = ObjectMapper.Map<CreateUpdateCustomerDto, CustomerDto>(input);
                var resultObj = await Task.FromResult(resultDto);
                return resultObj;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
