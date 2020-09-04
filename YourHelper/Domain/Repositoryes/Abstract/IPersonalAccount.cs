using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourHelper.Models;

namespace YourHelper.Domain.Repositoryes.Abstract
{
    public interface IPersonalAccount
    {
        /// <summary>
        /// Сохранить услугу
        /// </summary>
        /// <param name="personalAccount"></param>
        /// <returns></returns>
        Task<Guid> SavePersonalAccount(PersonalAccount personalAccount);
        /// <summary>
        /// Удалить услугу
        /// </summary>
        /// <param name="id">id услуги</param>
        /// <returns></returns>
        Task DeletePersonalAccount(Guid id);
        /// <summary>
        /// Получить список услуг пользователя
        /// </summary>
        /// <param name="userId">id пользователя</param>
        /// <returns></returns>
        IEnumerable<PersonalAccount> GetAccounts(string userId);
        /// <summary>
        /// Получить услугу по идентификатору
        /// </summary>
        /// <param name="accountId">Идентификатор услуги</param>
        /// <returns></returns>
        Task<PersonalAccount> GetAccount(Guid accountId);
    }
}
