using Microsoft.AspNet.Identity;
using Noleggio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Noleggio.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "{0}ът е задължителен")]
        [Display(Name = "Имейл")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "{0}ът е задължителен")]
        [Display(Name = "Имейл")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0}ът е задължителен")]
        [Display(Name = "Имейл")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}та е задължителна")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage ="{0}ът е задължителен")]
        [EmailAddress(ErrorMessage = "Въвели сте не коректен {0}!")]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}то е задължителено")]
        [StringLength(NoleggioConstants.UserFirstNameMaximumLenght, ErrorMessage ="{0} трябва да бъде между {2} и {1} символа!", MinimumLength=NoleggioConstants.UserClassMinimumStringLenght)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0}та е задължителна")]
        [StringLength(NoleggioConstants.UserLastNameMaximumLenght, ErrorMessage = "{0} трябва да бъде между {2} и {1} символа!", MinimumLength = NoleggioConstants.UserClassMinimumStringLenght)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата на Раждане")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "{0}ът е задължителен")]
        [StringLength(NoleggioConstants.UserCityMaximumLength, ErrorMessage = "{0} трябва да бъде между {2} и {1} символа!", MinimumLength = NoleggioConstants.UserClassMinimumStringLenght)]
        [Display(Name = "Град")]
        public string City { get; set; }


        [Required(ErrorMessage = "{0}ът е задължителен")]
        [StringLength(NoleggioConstants.UserAddressMaximumLength, ErrorMessage = "{0} трябва да бъде между {2} и {1} символа!", MinimumLength = NoleggioConstants.UserClassMinimumStringLenght)]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0}та е задължителна")]
        [StringLength(100, ErrorMessage = "{0}та трябва да бъде поне {2} символа дълга.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърдете Паролата")]
        [Compare("Password", ErrorMessage = "Паролата и въведената за потвърждение не съвпадат!")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "{0}ът е задължителен")]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}та е задължителна")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърдете Паролата")]
        [Compare("Password", ErrorMessage = "Паролата и въведената за потвърждение не съвпадат!")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "{0}ът е задължителен")]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; }
    }
}
