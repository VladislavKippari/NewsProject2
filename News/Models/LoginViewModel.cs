using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(100, ErrorMessage = " {0} должен быть от {2} до {1} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
