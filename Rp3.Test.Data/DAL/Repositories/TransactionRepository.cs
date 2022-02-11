using Rp3.Test.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3.Test.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>
    {
        public TransactionRepository(DbContext context) : base(context)
        {
        }
        
        //JNB
        public List<Balance> GetBalance(int IdLogin)
        {
            return this.DataBase.SqlQuery<Balance>("EXEC dbo.spGetBalance @IdLogin = {0}", IdLogin).ToList();
        }

        
    }
}
