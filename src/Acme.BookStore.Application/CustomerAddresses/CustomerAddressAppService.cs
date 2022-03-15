using Acme.BookStore.Books;
using Acme.BookStore.CustomerAddresses;
using Acme.BookStore.Customers;
using Microsoft.AspNetCore.Mvc;
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
        IRepository<CustomerAddress> _customerAddressRepository;    
        public CustomerAddressAppService(IRepository<CustomerAddress, Guid> repository) : base(repository)
        {
           this._customerAddressRepository = repository;
        }

       public async override Task<CustomerAddressDto> CreateAsync(CreateUpdateCustomerAddressDto input)
        {
           
            var userAddress= await _customerAddressRepository.InsertAsync(new CustomerAddress { AddressLine1 = input.AddressLine1, AddressLine2 = input.AddressLine2, City = input.City, Country = input.Country } );
            
          //  await uow.CompleteAsync();
            var customerAddressDto = ObjectMapper.Map<CustomerAddress, CustomerAddressDto>(userAddress);
            return customerAddressDto;
        }

        public override Task<CustomerAddressDto> UpdateAsync(Guid id, CreateUpdateCustomerAddressDto input)
        {
            return base.UpdateAsync(id, input);
        }
        /*  [HttpPost]
       public async Task<CustomerAddressDto> AddUserWithAddress(CreateUpdateCustomerAddressDto customer)
       {




         customer.Id = Guid.NewGuid();
           customer.Address.Id = Guid.NewGuid();//pk
            customer.Address.Id = customer.Id;
            _customerAddressRepository.Customer.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);


    }*/
    }
}
/* public class UserGroupService : AgencyPlatformCrudAppService<UserGroup, UserGroupDto, Guid, CreateUserGroupDto, UpdateUserGroupDto, UserGroupListDto>
    {
        private readonly IRepository<UserProfileGroup, Guid> userProfileGroupRepo;
        private readonly IRepository<UserProfile, Guid> userProfileRepo;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<UserGroup, Guid> userGroupRepo;
        public UserGroupService(IRepository<UserGroup, Guid> repository, IRepository<UserProfileGroup, Guid> userProfileGroupRepo, IRepository<UserProfile, Guid> userProfileRepo, IUnitOfWorkManager unitOfWorkManager, IRepository<UserGroup, Guid> userGroupRepo)
            : base(repository)

        {
            GetPolicyName = MasterPermissions.UserGroups.Default;
            GetListPolicyName = MasterPermissions.UserGroups.Default;
            CreatePolicyName = MasterPermissions.UserGroups.Create;
            UpdatePolicyName = MasterPermissions.UserGroups.Update;
            DeletePolicyName = MasterPermissions.UserGroups.Delete;
            this.userProfileGroupRepo = userProfileGroupRepo;
            this.userProfileRepo = userProfileRepo;
            _unitOfWorkManager = unitOfWorkManager;
            this.userGroupRepo = userGroupRepo;
        }
        public async override Task<UserGroupDto> CreateAsync(CreateUserGroupDto input)
        {
            using var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: false);

            var userProfile = await userProfileRepo.InsertAsync(new UserProfile { Name = input.Name, UserType = UserConsts.UserTypeGroup, Active = true });

            var userGroup = await userGroupRepo.InsertAsync(new UserGroup { Name = input.Name, Active = input.Active, UserProfileId = userProfile.Id });

            foreach (var item in input.UserProfilesIds)
            {
                await userProfileGroupRepo.InsertAsync(new UserProfileGroup { UserGroupId = userGroup.Id, UserProfileId = item, });
            }
            await uow.CompleteAsync();
            var userGroupDto = ObjectMapper.Map<UserGroup, UserGroupDto>(userGroup);
            return await Task.FromResult(userGroupDto);
        }

        public override IEnumerable<UserGroupDto> GetExpand(Guid id)
        {
            var enumerable = base.GetExpand(id);
            foreach (var item in enumerable)
            {
                var userProfile = userProfileRepo.AsQueryable();
                var users = userProfileGroupRepo.AsQueryable().Where(w => w.UserGroupId == id).Join(userProfile, x => x.UserProfileId, y => y.Id, (x, y) => y);
                item.UserProfilesIds = users.Select(s => s.Id).ToList();
                item.InternalUserProfile = ObjectMapper.Map<List<UserProfile>, List<InternalUserProfileDto>>(users.Select(s => s).ToList());
            }
            return enumerable;
        }

        public async override Task<UserGroupDto> UpdateAsync(Guid id, UpdateUserGroupDto input)
        {
            using var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: false);

            var userGroupDto = await base.UpdateAsync(id, input);
            var userProfile = await userProfileRepo.GetAsync(userGroupDto.UserProfileId);
            userProfile.Name = userGroupDto.Name;
            await userProfileRepo.UpdateAsync(userProfile);

            var oldCustomerTypeIds = userProfileGroupRepo.Where(w => w.UserGroupId == id);
            foreach (var item in oldCustomerTypeIds)
            {
                await userProfileGroupRepo.DeleteAsync(item);
            }

            foreach (var item in input.UserProfilesIds)
            {
                await userProfileGroupRepo.InsertAsync(new UserProfileGroup { UserGroupId = id, UserProfileId = item });
            }
            await uow.CompleteAsync();
            return userGroupDto;
        }

        public async override Task DeleteAsync(Guid id)
        {
            var userGroupDto = await base.GetAsync(id);
            var userProfile = await userProfileRepo.GetAsync(userGroupDto.UserProfileId);
            userProfile.Active = false;

            await userProfileRepo.UpdateAsync(userProfile);

            await base.DeleteAsync(id);
        }
    }
}
*/