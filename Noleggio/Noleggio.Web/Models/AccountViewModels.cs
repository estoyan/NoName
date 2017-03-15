﻿using Microsoft.AspNet.Identity;
using Noleggio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Noleggio.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
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
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(NoleggioConstants.UserFirstNameMaximumLenght, ErrorMessage ="{0} трябва да бъде между {2} и {1} символа!", MinimumLength=NoleggioConstants.UserClassMinimumStringLenght)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(NoleggioConstants.UserLastNameMaximumLenght, ErrorMessage = "{0} трябва да бъде между {2} и {1} символа!!", MinimumLength = NoleggioConstants.UserClassMinimumStringLenght)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата на Раждане")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [StringLength(NoleggioConstants.UserCityMaximumLength, ErrorMessage = "{0} трябва да бъде между {2} и {1} символа!!", MinimumLength = NoleggioConstants.UserClassMinimumStringLenght)]
        [Display(Name = "Град")]
        public string City { get; set; }


        [Required]
        [StringLength(NoleggioConstants.UserAddressMaximumLength, ErrorMessage = "{0} трябва да бъде между {2} и {1} символа!!", MinimumLength = NoleggioConstants.UserClassMinimumStringLenght)]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
