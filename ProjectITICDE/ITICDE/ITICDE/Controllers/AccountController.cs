using AutoMapper;
using ITICDE.Models;
using ITICDE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ITICDE.Controllers
{
    public class AccountController : Controller
	{
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;
		private readonly ILogger _logger;
		private readonly IMapper _mapper;


		public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, ILoggerFactory loggerFactory, IMapper mapper)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_logger = loggerFactory.CreateLogger<AccountController>();
			_mapper = mapper;	
		}


		[HttpGet]
		[AllowAnonymous]
		
		public IActionResult Register ()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public  async Task <IActionResult> Register(UserViewModel model)
		{
			
			var mappedUser = _mapper.Map<User>(model);
			//	var user = new User { UserName = model.Email , Email = model.Email,Name=model.Name};
			var result =await _userManager.CreateAsync(mappedUser, model.Password);
			await _signInManager.SignInAsync(mappedUser, isPersistent: false);
			if (result.Succeeded)
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
			else
			{
				return View();
			}
			
		}



		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login(string returnurl = null)
		{
			ViewData["ReturnUrl"] = returnurl;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AllowAnonymous]
			public async Task<IActionResult> Login(LoginViewModel model, string returnurl = null)
			{
				ViewData["ReturnUrl"] = returnurl;
				returnurl = returnurl ?? Url.Content("~/");
				if (ModelState.IsValid)
				{
				var username = new EmailAddressAttribute().IsValid(model.Email) ? new MailAddress(model.Email).User : model.Email;
				var result = await _signInManager.PasswordSignInAsync(username, model.Password, model.RememberMe, lockoutOnFailure: true);
					if (result.Succeeded)
					{
						return LocalRedirect(returnurl);
					}
					
					if (result.IsLockedOut)
					{
						return View("Lockout");
					}
					else
					{
						ModelState.AddModelError(string.Empty, "Invalid login attempt.");
						return View(model);
					}
					
				}


				return View(model);
			}

		

		public async Task <IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(HomeController.Index), "Home");

		}
	}

}
