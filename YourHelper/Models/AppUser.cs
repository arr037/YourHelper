using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace YourHelper.Models
{
    public class AppUser:IdentityUser
    {
        public List<PersonalAccount> PersonalAccounts { get; set; }
    }
}
