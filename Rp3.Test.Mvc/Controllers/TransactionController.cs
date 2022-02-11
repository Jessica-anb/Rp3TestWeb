using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rp3.Test.Mvc.Controllers
{
    public class TransactionController : Controller
    {

        public ActionResult Index()
        {
            Proxies.Proxy proxy = new Proxies.Proxy();

            //JNB
            int idlogin = 0;
            if (System.Web.HttpContext.Current.Session["IdLogin"] != null)
                idlogin = Int32.Parse(System.Web.HttpContext.Current.Session["IdLogin"].ToString());

            var data = proxy.GetTransactions(idlogin);

            List<Rp3.Test.Mvc.Models.TransactionViewModel> model = new List<Models.TransactionViewModel>();

            foreach(var item in data)
            {
                model.Add(new Models.TransactionViewModel()
                {
                    Amount = item.Amount,
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,
                    Notes = item.Notes,
                    RegisterDate = item.RegisterDate,
                    ShortDescription = item.ShortDescription,
                    TransactionId = item.TransactionId,
                    TransactionType = item.TransactionType,
                    TransactionTypeId = item.TransactionTypeId                    
                });
            }
            
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Edit(Rp3.Test.Mvc.Models.TransactionEditModel editModel)
        {
            Rp3.Test.Proxies.Proxy proxy = new Proxies.Proxy();

            Rp3.Test.Common.Models.Transaction commonModel = new Common.Models.Transaction();

            int idlogin = 0;
            if (System.Web.HttpContext.Current.Session["IdLogin"] != null)
                idlogin = Int32.Parse(System.Web.HttpContext.Current.Session["IdLogin"].ToString());
            
            commonModel.TransactionId = editModel.TransactionId;
            commonModel.Amount = editModel.Amount;
            commonModel.CategoryId = editModel.CategoryId;
            commonModel.TransactionTypeId = editModel.TransactionTypeId;
            commonModel.Notes = editModel.Notes;
            commonModel.RegisterDate = editModel.RegisterDate;
            commonModel.ShortDescription = editModel.ShortDescription;
            commonModel.IdLogin = idlogin;

            bool respondeOk = proxy.UpdateTransaction(commonModel);

            if (respondeOk)
                return RedirectToAction("Index");
            else
                return View(commonModel);
        }

        public ActionResult Edit(int TransactionId)
        {
            Rp3.Test.Proxies.Proxy proxy = new Proxies.Proxy();

            Rp3.Test.Mvc.Models.TransactionEditModel editModel = new Models.TransactionEditModel();

            int idlogin = 0;
            if (System.Web.HttpContext.Current.Session["IdLogin"] != null)
                idlogin = Int32.Parse(System.Web.HttpContext.Current.Session["IdLogin"].ToString());

            var commonModel = proxy.GetTransactions(idlogin, TransactionId);

            editModel.TransactionId = commonModel.TransactionId;
            editModel.TransactionTypeId = commonModel.TransactionTypeId;
            editModel.CategoryId = commonModel.CategoryId;
            editModel.RegisterDate = commonModel.RegisterDate;
            editModel.ShortDescription = commonModel.ShortDescription;
            editModel.Amount = commonModel.Amount;
            editModel.Notes = commonModel.Notes;
            editModel.CategorySelectList = GetCategory();
            editModel.TransactionTypeSelectList = GetTransactionType();

            return View("Edit", editModel);
        }

        private IEnumerable<SelectListItem> GetCategory()
        {
            Rp3.Test.Proxies.Proxy proxy = new Proxies.Proxy();

            List<Rp3.Test.Mvc.Models.CategoryViewModel> categories = proxy.GetCategories().
                Select(p => new Models.CategoryViewModel()
                {
                    Active = p.Active,
                    CategoryId = p.CategoryId,
                    Name = p.Name
                }).ToList();
            
            return new SelectList(categories, "CategoryId", "Name");
        }

        private IEnumerable<SelectListItem> GetTransactionType()
        {
            Rp3.Test.Proxies.Proxy proxy = new Proxies.Proxy();

            List<Rp3.Test.Common.Models.TransactionType> transactionType = proxy.GetTransactionTypes().
                Select(p => new Rp3.Test.Common.Models.TransactionType()
                {
                    TransactionTypeId = p.TransactionTypeId,
                    Name = p.Name
                }).ToList();

            return new SelectList(transactionType, "TransactionTypeId", "Name");
        }

        public ActionResult Create()
        {
            Rp3.Test.Proxies.Proxy proxy = new Proxies.Proxy();

            Rp3.Test.Mvc.Models.TransactionEditModel editModel = new Models.TransactionEditModel();
            
            editModel.RegisterDate = DateTime.Now;
            editModel.CategorySelectList = GetCategory();
            editModel.TransactionTypeSelectList = GetTransactionType();

            return View("Edit", editModel);
        }

        [HttpPost]
        public ActionResult Create(Rp3.Test.Mvc.Models.TransactionEditModel editModel)
        {
            Rp3.Test.Proxies.Proxy proxy = new Proxies.Proxy();

            Rp3.Test.Common.Models.Transaction commonModel = new Common.Models.Transaction();

            int idlogin = 0;
            if (System.Web.HttpContext.Current.Session["IdLogin"] != null)
                idlogin = Int32.Parse(System.Web.HttpContext.Current.Session["IdLogin"].ToString());

            commonModel.TransactionId = editModel.TransactionId;
            commonModel.Amount = editModel.Amount;
            commonModel.CategoryId = editModel.CategoryId;
            commonModel.TransactionTypeId = editModel.TransactionTypeId;
            commonModel.Notes = editModel.Notes;
            commonModel.RegisterDate = editModel.RegisterDate;
            commonModel.ShortDescription = editModel.ShortDescription;
            commonModel.IdLogin = idlogin;

            bool respondeOk =  proxy.InsertTransaction(commonModel);

            if (respondeOk)
                return RedirectToAction("Index");
            else
                return View(commonModel);
        }

        public ActionResult Balance()
        {
            Proxies.Proxy proxy = new Proxies.Proxy();

            //JNB
            int idlogin = 0;
            if (System.Web.HttpContext.Current.Session["IdLogin"] != null)
                idlogin = Int32.Parse(System.Web.HttpContext.Current.Session["IdLogin"].ToString());

            var data = proxy.GetBalance(idlogin);

            List<Rp3.Test.Mvc.Models.BalanceViewModel> model = new List<Models.BalanceViewModel>();

            foreach (var item in data)
            {
                model.Add(new Models.BalanceViewModel()
                {
                    Amount = item.Amount,
                    Category = item.Category
                });
            }

            return View(model);
        }

    }
}
