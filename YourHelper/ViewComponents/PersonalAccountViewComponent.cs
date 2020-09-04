using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using YourHelper.Domain.Repositoryes.Abstract;
using YourHelper.Models;

namespace YourHelper.ViewComponents
{
    public class PersonalAccountViewComponent:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPersonalAccount _account;

        public PersonalAccountViewComponent(UserManager<AppUser> userManager, IPersonalAccount account)
        {
            _userManager = userManager;
            _account = account;
        }

        public async Task<IActionResult> InvokeAsync()
        {
            var appUser = await _userManager.GetUserAsync((ClaimsPrincipal)User);
            var accounts = _account.GetAccounts(appUser.Id).ToList();
            return View(accounts);
        }
    }
}
