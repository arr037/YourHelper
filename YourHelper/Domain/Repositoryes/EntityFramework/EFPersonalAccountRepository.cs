using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using YourHelper.Domain.Repositoryes.Abstract;
using YourHelper.Models;

namespace YourHelper.Domain.Repositoryes.EntityFramework
{
    public class EfPersonalAccountRepository:IPersonalAccount
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EfPersonalAccountRepository(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<Guid> SavePersonalAccount(PersonalAccount personalAccount)
        {
            _appDbContext.Entry(personalAccount).State = personalAccount.Id == default ? EntityState.Added : EntityState.Modified;

            await _appDbContext.SaveChangesAsync();
            return personalAccount.Id;
        }

        public async Task DeletePersonalAccount(Guid accountId)
        {
            _appDbContext.PersonalAccounts.Remove(new PersonalAccount { Id = accountId });
            await _appDbContext.SaveChangesAsync();
        }


        public IEnumerable<PersonalAccount> GetAccounts(string userId) =>
            _appDbContext.PersonalAccounts.Where(account => account.AppUserId == userId);

        public async Task<PersonalAccount> GetAccount(Guid accountId)
        {
            return await _appDbContext.PersonalAccounts.FirstOrDefaultAsync(account => account.Id == accountId);
        }
    }
}
