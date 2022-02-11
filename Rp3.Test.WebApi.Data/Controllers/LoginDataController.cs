using Newtonsoft.Json;
using Rp3.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rp3.Test.WebApi.Data.Controllers
{
    public class LoginDataController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Getinto(Rp3.Test.Common.Models.Login login)
        {
            List<Rp3.Test.Common.Models.Login> commonModel = new List<Rp3.Test.Common.Models.Login>();

            using (DataService service = new DataService())
            {
                var query = service.Login.GetQueryable();

                if (login.User != "" && login.Password != "")
                    query = query.Where(p => p.User == login.User && p.Password == login.Password);

                commonModel = query.Select(p => new Rp3.Test.Common.Models.Login()
                {
                    IdLogin = p.IdLogin,
                    User = p.User,
                    Password = p.Password,
                    FullName = p.Names + " " + p.Surnames                  
                }).ToList();                
            }

            return Ok(commonModel[0]);
        }
    }
}
