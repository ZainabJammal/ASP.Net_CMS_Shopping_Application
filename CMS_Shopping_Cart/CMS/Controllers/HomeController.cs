using Common.Infrastructure;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    //[Authorize]
    //public class HomeController : Controller
    //{
    //    private readonly UserManager<AppUser> userManager;
    //    private readonly SignInManager<AppUser> signInManager;
    //    private IPasswordHasher<AppUser> passwordHasher;
    //    private readonly CmsShoppingCartContext context;

    //    public HomeController(UserManager<AppUser> userManager,
    //                             SignInManager<AppUser> signInManager,
    //                             IPasswordHasher<AppUser> passwordHasher,
    //                             CmsShoppingCartContext context)
    //    {
    //        this.userManager = userManager;
    //        this.signInManager = signInManager;
    //        this.passwordHasher = passwordHasher;
    //        this.context = context;
    //    }

    //    [AllowAnonymous]
    //    public IActionResult Index(string returnUrl)
    //    {
    //        if (string.IsNullOrEmpty(returnUrl))
    //        {
    //            returnUrl = "/";
    //        }
    //        Login login = new Login
    //        {
    //            ReturnUrl = returnUrl
    //        };

    //        return View(login);

    //    }

    //    //GET /homw/register
    //    [AllowAnonymous]
    //    public IActionResult Register() => View();

    //    // POST /home/register
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Register(User user)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            AppUser appUser = new AppUser
    //            {
    //                UserName = user.UserName,
    //                Email = user.Email
    //            };

    //            IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
    //            if (result.Succeeded)
    //            {
    //                return RedirectToAction("Login");
    //            }
    //            else
    //            {
    //                foreach (IdentityError error in result.Errors)
    //                {
    //                    ModelState.AddModelError("", error.Description);
    //                }
    //            }
    //        }

    //        return View(user);
    //    }

    //    // GET /home/login
    //    //[AllowAnonymous]
    //    //public IActionResult Login(string returnUrl)
    //    //{
    //    //    if (string.IsNullOrEmpty(returnUrl))
    //    //    {
    //    //        returnUrl = "/";
    //    //    }
    //    //    Login login = new Login
    //    //    {
    //    //        ReturnUrl = returnUrl
    //    //    };

    //    //    return View(login);
    //    //}

    //    // POST /home/login
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Login(Login login)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                AppUser appUser = await userManager.FindByEmailAsync(login.Email);
    //                if (appUser != null)
    //                {
    //                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
    //                    if (result.Succeeded)
    //                        return Redirect(login.ReturnUrl ?? "/");
    //                }
    //                ModelState.AddModelError("", "Login failed, wrong credentials.");
    //            }
    //            catch (Exception ex)
    //            {

    //            }
    //            return View(login);
    //        }
    //        return null;
    //    }

    //    // GET /home/logout
    //    public async Task<IActionResult> Logout()
    //    {
    //        await signInManager.SignOutAsync();

    //        return Redirect("/");
    //    }

    //    // GET /home/edit
    //    public async Task<IActionResult> Edit()
    //    {
    //        AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);
    //        UserEdit user = new UserEdit(appUser);

    //        return View(user);
    //    }


    //    // POST /home/edit
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(UserEdit user)
    //    {
    //        AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);

    //        if (ModelState.IsValid)
    //        {
    //            appUser.Email = user.Email;
    //            if (user.Password != null)
    //            {
    //                appUser.PasswordHash = passwordHasher.HashPassword(appUser, user.Password);
    //            }

    //            IdentityResult result = await userManager.UpdateAsync(appUser);
    //            if (result.Succeeded)
    //                TempData["Success"] = "Your information has been edited!";
    //        }

    //        return View();
    //    }
    //}

    public class HomeController : Controller
    {
        public string Index()
        {
            return "hello";
        }
    }
}
