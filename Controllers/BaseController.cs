using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using UnibelDestekSistemi.Models.DBHandler;

namespace UnibelDestekSistemi.Controllers
{
    public class BaseController : Controller
    {
        public unibeldestekContext _db = new unibeldestekContext();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
             if (filterContext.HttpContext.Request.Path!= "/" && filterContext.HttpContext.Request.Path != "/LoginPage/Login")
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
               
                    string userName = User.Identity.Name;
                    //var sa = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(userName));
                    //var qq = _db.Roller.FirstOrDefault(x => x.RolId.Equals(sa.RolId));
                    
                  //  var rolId = _db.Kullanici.Where(c => c.KullaniciAdi == userName).Select(c => c.FkRolId).SingleOrDefault();
                    ViewBag.TamIsim = _db.Kullanici.Where(a => a.KullaniciAdi == userName).Select(b => b.TamIsim).SingleOrDefault();
                    var kul = _db.Kullanici.ToList();
                    ViewBag.Sirketler = _db.Sirketler.ToList();
                    ViewBag.Oncelik = _db.Oncelik.ToList();
                    ViewBag.Kullanici = _db.Kullanici.ToList();
                    ViewBag.Tip = _db.Tip.ToList();
                    ViewBag.Durum = _db.Durum.ToList();
                    ViewBag.Departman = _db.Departman.ToList();
                    ViewBag.Roller = _db.Roller.ToList();
                  


                    // ViewBag.Rol = _db.Roller.Where(x => (_db.Kullanici ))


                }
                else
                {
                    var url = filterContext.HttpContext.Request.Path;
                    filterContext.Result = new RedirectResult("/");
                    return;
                }
            }
            else
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var url = filterContext.HttpContext.Request.Path;
                    filterContext.Result = new RedirectResult("/Dashboard");
                    return;
                }



            }
        }

        public class HandleExceptionAttribute : ExceptionFilterAttribute
        {
            public override void OnException(ExceptionContext context)
            {
                var result = new ViewResult { ViewName = "Error" };
                var modelMetadata = new EmptyModelMetadataProvider();
                result.ViewData = new ViewDataDictionary(
                modelMetadata, context.ModelState);
                result.ViewData.Add("HandleException",context.Exception);
                context.Result = result;
                context.ExceptionHandled = true;
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

    }
}