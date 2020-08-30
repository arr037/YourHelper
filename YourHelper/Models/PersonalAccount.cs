using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourHelper.Models
{
    public class PersonalAccount
    {

        public PersonalAccount() => Date = DateTime.UtcNow.AddHours(+6);

        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Лицевой счет")]
        public long AccountId { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
