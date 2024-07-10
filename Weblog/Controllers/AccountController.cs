using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Weblog.Controllers
{
    public class AccountController : Controller
    {
        WeblogContext ctx = new WeblogContext();
        IUserRepo UserRepo;
        public AccountController()
        {
            UserRepo = new UserRepo(ctx);
        }

        // GET: Account
        [Authorize]
        public ActionResult Index()
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null)
                {
                    var userRole = authTicket.UserData;
                    User UserInfo = UserRepo.GetUserByEmail(authTicket.Name);
                    ViewBag.UserName = UserInfo.Name;
                    ViewBag.UserFamily = UserInfo.Family;
                    ViewBag.UserEmail = UserInfo.Email;
                    ViewBag.UserRole = userRole;
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel user, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {

                var User = UserRepo.GetAllUsers().SingleOrDefault(u=> u.Email == user.Email && u.Password == user.Password);

                if (User != null)
                {
                    FormsAuthentication.SetAuthCookie(User.Email, true);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, User.Email,DateTime.Now,DateTime.Now.AddMinutes(30),false,User.Role.RoleName,FormsAuthentication.FormsCookiePath);

                    string EncTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,EncTicket);
                    Response.Cookies.Add(cookie);

                    if (Url.IsLocalUrl(ReturnUrl) && ReturnUrl.Length > 1 && ReturnUrl.StartsWith("/", StringComparison.OrdinalIgnoreCase) && !ReturnUrl.StartsWith("//", StringComparison.OrdinalIgnoreCase) && !ReturnUrl.StartsWith("/\\", StringComparison.OrdinalIgnoreCase))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Email or Password is Incorrect");
                    ModelState.AddModelError("Password", "Email or Password is Incorrect");
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public void Dispose()
        {
            ctx.Dispose();
            UserRepo.Dispose();
        }
    }
}