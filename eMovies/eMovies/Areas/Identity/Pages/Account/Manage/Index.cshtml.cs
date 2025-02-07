// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using eMovies.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace eMovies.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public ChangePasswordInputModel ChangePasswordInput { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Username")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Full name is required")]
            [StringLength(50, ErrorMessage = "Full name cannot exceed 50 symbols", MinimumLength = 3)]
            [Display(Name = "Full Name")]
            public string FullName { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Country is required")]
            [StringLength(50, ErrorMessage = "Country cannot exceed 50 symbols", MinimumLength = 3)]
            [Display(Name = "Country")]
            public string Country { get; set; }

            [Required(ErrorMessage = "City is required")]
            [StringLength(50, ErrorMessage = "City cannot exceed 50 symbols", MinimumLength = 3)]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required(ErrorMessage = "State is required")]
            [StringLength(50, ErrorMessage = "State cannot exceed 50 symbols", MinimumLength = 3)]
            [Display(Name = "State")]
            public string State { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }

            [RegularExpression(@"^\d{4,9}$", ErrorMessage = "Zip code must be between 4 and 9 digits.")]
            [Display(Name = "Zip code")]
            public string Zip { get; set; }

            [Required(ErrorMessage = "Date of birth is required")]
            [DataType(DataType.Date)]
            [Display(Name = "Date of Birth")]
            public DateTime DateOfBirth { get; set; }
        }

        public class ChangePasswordInputModel
        {
            [DataType(DataType.Password)]
            [Display(Name = "Current password")]
            public string OldPassword { get; set; }

            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var userEmail = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                UserName = userName,
                Email = user.Email,
                PhoneNumber = phoneNumber,
                FullName = user.FullName,
                Country = user.Country,
                City = user.City,
                State = user.State,
                Address = user.Address,
                Zip = user.Zip,
                DateOfBirth = user.DateOfBirth
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            // Update the user's profile
            if (Input.FullName != user.FullName)
            {
                user.FullName = Input.FullName;
            }
            if (Input.Country != user.Country)
            {
                user.Country = Input.Country;
            }
            if (Input.City != user.City)
            {
                user.City = Input.City;
            }
            if (Input.State != user.State)
            {
                user.State = Input.State;
            }
            if (Input.Address != user.Address)
            {
                user.Address = Input.Address;
            }
            if (Input.Zip != user.Zip)
            {
                user.Zip = Input.Zip;
            }
            if (Input.DateOfBirth != user.DateOfBirth)
            {
                user.DateOfBirth = Input.DateOfBirth;
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                StatusMessage = "Unexpected error when trying to update profile.";
                return RedirectToPage();
            }

            // Change password
            if (!string.IsNullOrEmpty(ChangePasswordInput.OldPassword) && !string.IsNullOrEmpty(ChangePasswordInput.NewPassword))
            {
                var changePasswordResult = await _userManager.ChangePasswordAsync(user, ChangePasswordInput.OldPassword, ChangePasswordInput.NewPassword);
                if (!changePasswordResult.Succeeded)
                {
                    foreach (var error in changePasswordResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    await LoadAsync(user);
                    return Page();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated.";
            return RedirectToPage();
        }
    }
}
