using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rp3.Test.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //JNB
        public ActionResult Login()
        {
            return View();
        }

        //JNB
        [HttpPost]
        public ActionResult Login(Rp3.Test.Mvc.Models.LoginEditModel editModel)
        {
            Rp3.Test.Proxies.Proxy proxy = new Proxies.Proxy();

            Rp3.Test.Mvc.Models.LoginViewModel viewModel = new Models.LoginViewModel();

            Rp3.Test.Common.Models.Login commonModel = new Common.Models.Login();
            commonModel.User = editModel.User;
            commonModel.Password = editModel.Password;

            var sesionModel = proxy.GetintoLogin(commonModel);

            viewModel.IdLogin = sesionModel.IdLogin;
            viewModel.User = sesionModel.User;
            viewModel.FullName = sesionModel.FullName;

            if (viewModel.FullName != "")
            {
                System.Web.HttpContext.Current.Session["Cuenta"] = viewModel.FullName;
                System.Web.HttpContext.Current.Session["IdLogin"] = viewModel.IdLogin;
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Login");
        }
    }
}