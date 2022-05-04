using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmailSender emailSender;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(
            IEmailSender emailSender,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.emailSender = emailSender;
        }
    }
}
