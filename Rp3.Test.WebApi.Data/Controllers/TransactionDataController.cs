using Rp3.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rp3.Test.WebApi.Data.Controllers
{
    public class TransactionDataController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int IdLogin)
        {            
            List<Rp3.Test.Common.Models.TransactionView> commonModel = new List<Common.Models.TransactionView>();

            using (DataService service = new DataService())
            {
                IEnumerable<Rp3.Test.Data.Models.Transaction> 
                    dataModel = service.Transactions.Get(p => p.IdLogin == IdLogin,
                    includeProperties: "Category,TransactionType", 
                    orderBy: p=> p.OrderByDescending(o=>o.RegisterDate) );

                //Para incluir una condición, puede usar el primer parametro de Get
                /*
                 * Ejemplo
                 IEnumerable<Rp3.Test.Data.Models.Transaction>
                    dataModel = service.Transactions.Get(p=> p.TransactionId > 0
                    includeProperties: "Category,TransactionType",
                    orderBy: p => p.OrderByDescending(o => o.RegisterDate));

                 */

                commonModel = dataModel.Select(p => new Common.Models.TransactionView()
                {
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    Notes = p.Notes,
                    Amount = p.Amount,
                    RegisterDate = p.RegisterDate,
                    ShortDescription = p.ShortDescription,
                    TransactionId = p.TransactionId,
                    TransactionType = p.TransactionType.Name,
                    TransactionTypeId = p.TransactionTypeId,
                    IdLogin = p.IdLogin
                }).ToList();
            }

            return Ok(commonModel);
        }

        [HttpGet]
        public IHttpActionResult GetBalance(int IdLogin)
        {
            List<Rp3.Test.Common.Models.Balance> commonModel = new List<Common.Models.Balance>();

            using (DataService service = new DataService())
            {
                IEnumerable<Rp3.Test.Data.Models.Balance>
                    dataModel = service.Transactions.GetBalance(IdLogin);

                commonModel = dataModel.Select(p => new Common.Models.Balance()
                {
                    Category = p.Category,
                    Amount = p.Amount
                }).ToList();
            }

            return Ok(commonModel);
        }

        [HttpGet]
        public IHttpActionResult GetById(int IdLogin, int TransactionId)
        {
            List<Rp3.Test.Common.Models.Transaction> commonModel = new List<Rp3.Test.Common.Models.Transaction>();

            using (DataService service = new DataService())
            {
                var query = service.Transactions.GetQueryable();

                query = query.Where(p => p.IdLogin == IdLogin && p.TransactionId == TransactionId);

                commonModel = query.Select(p => new Common.Models.Transaction()
                {
                    TransactionId = p.TransactionId,
                    TransactionTypeId = p.TransactionTypeId,
                    CategoryId = p.CategoryId,
                    RegisterDate = p.RegisterDate,
                    ShortDescription = p.ShortDescription,
                    Amount = p.Amount,
                    Notes = p.Notes
                }).ToList();
            }
            return Ok(commonModel[0]);
        }

        public IHttpActionResult Insert(Rp3.Test.Common.Models.Transaction transaction)
        {
            //Complete the code
            using (DataService service = new DataService())
            {
                Rp3.Test.Data.Models.Transaction model = new Test.Data.Models.Transaction();

                model.TransactionId = service.Transactions.GetMaxValue<int>(p => p.TransactionId, 0) + 1;
                model.Amount = transaction.Amount;
                model.CategoryId = transaction.CategoryId;
                model.TransactionTypeId = transaction.TransactionTypeId;
                model.Notes = transaction.Notes;
                model.RegisterDate = transaction.RegisterDate;
                model.ShortDescription = transaction.ShortDescription;
                model.IdLogin = transaction.IdLogin;

                service.Transactions.Insert(model);
                service.SaveChanges();
            }

            return Ok(true);
        }


        [HttpPost]
        public IHttpActionResult Update(Rp3.Test.Common.Models.Transaction transaction)
        {
            using (DataService service = new DataService())
            {
                Rp3.Test.Data.Models.Transaction model = service.Transactions.GetByID(transaction.TransactionId);

                model.Amount = transaction.Amount;
                model.CategoryId = transaction.CategoryId;
                model.TransactionTypeId = transaction.TransactionTypeId;
                model.Notes = transaction.Notes;
                model.RegisterDate = transaction.RegisterDate;
                model.ShortDescription = transaction.ShortDescription;
                model.IdLogin = transaction.IdLogin;

                service.Transactions.Update(model);
                service.SaveChanges();
            }

            return Ok(true);
        }
    }
}
