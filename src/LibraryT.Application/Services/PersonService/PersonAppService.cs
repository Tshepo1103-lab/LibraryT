using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using LibraryT.Authorization.Users;
using LibraryT.Domain;
using LibraryT.Services.PersonService.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.PersonService
{
    public class PersonAppService : AsyncCrudAppService<Person, PersonDto, Guid>
    {
        private readonly IRepository<Person,Guid> _personRepository;
        private readonly UserManager _userManager;
        public PersonAppService(IRepository<Person, Guid> repository,UserManager userManager) : base(repository)
        {
            _personRepository = repository;
            _userManager = userManager;
        }
        private async Task<User> CreateUser(PersonDto input)
        {
            var user = ObjectMapper.Map<User>(input);
            ObjectMapper.Map(input, user);
            if (!string.IsNullOrEmpty(user.NormalizedUserName) && !string.IsNullOrEmpty(user.NormalizedEmailAddress))
                user.SetNormalizedNames();
            user.TenantId = AbpSession.TenantId;
            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.Password));
            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));
            }
            CurrentUnitOfWork.SaveChanges();
            return user;
        }

        public override async Task<PersonDto> CreateAsync(PersonDto input)
        {

            var person = ObjectMapper.Map<Person>(input);
            person.User = await CreateUser(input);
            return ObjectMapper.Map<PersonDto>(
                await _personRepository.InsertAsync(person));
        }
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
