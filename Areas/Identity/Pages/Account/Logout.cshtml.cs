using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BakeryProj.Data;
using BakeryProj.Models;
using BakeryProj.Helpers;
using Microsoft.AspNetCore.Http;

namespace Bakery.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
    private readonly UserManager<IdentityUser> _userManager;

    private readonly SignInManager<IdentityUser> _signInManager;
    public LogoutModel(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager, BakeryContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
      public async Task<IActionResult> OnPost(string returnUrl = null)
        {   
            String user = HttpContext.Session.GetString("username");
            var usercart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, user);
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("account");
            SessionHelper.SetObjectAsJson(HttpContext.Session, user,usercart);
            await _signInManager.SignOutAsync();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction(returnUrl);
            }
        }
    }
}
