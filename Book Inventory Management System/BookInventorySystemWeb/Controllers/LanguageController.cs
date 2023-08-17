using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BookInventorySystemWeb.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        
        public ActionResult ChangeLanguage(string selectedLanguage)
        {
            if (selectedLanguage != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
                var cookie = new HttpCookie("Language");
                cookie.Value = selectedLanguage;
                Response.Cookies.Add(cookie);
            }
            if (Request.UrlReferrer != null)
            {
                string[] segments = Request.UrlReferrer.Segments;
                if (segments.Length >= 3)
                {
                    string controller = segments[segments.Length - 2].Trim('/');
                    string action = segments[segments.Length - 1].Trim('/');
                    return RedirectToAction(action, controller);
                }
            }
            return RedirectToAction("Index", "Book");
        }
    }
}