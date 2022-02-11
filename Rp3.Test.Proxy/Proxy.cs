using Newtonsoft.Json;
using Rp3.Test.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace Rp3.Test.Proxies
{
    public class Proxy : BaseProxy
    {
        //JNB Servicios para la pantalla de Login
        private const string UriGetintoLogin = "api/loginData/getinto";

        private const string UriGetCategory = "api/categoryData/get?active={0}";
        private const string UriGetCategoryById = "api/categoryData/getById?categoryId={0}";
        private const string UriInsertCategory = "api/categoryData/insert";
        private const string UriUpdateCategory = "api/categoryData/update";

        private const string UriGetTransactionType = "api/transactionTypeData/get";

        private const string UriGetTransactions = "api/transactionData/get?idLogin={0}"; //JNB
        private const string UriGetTransactionsById = "api/transactionData/getById?idLogin={0}&transactionId={1}"; //JNB
        private const string UriInsertTransaction = "api/transactionData/insert"; //JNB
        private const string UriUpdateTransaction = "api/transactionData/update"; //JNB
        private const string UriGetBalance = "api/transactionData/getBalance?idLogin={0}"; //JNB

        //JNB Servicios para la pantalla de Login
        #region Login Services

        /// <summary>
        /// Obtiene el Id Login segun login ingresado
        /// </summary>
        /// <param name="Login"></param>
        /// <returns></returns>
        public Login GetintoLogin(Rp3.Test.Common.Models.Login login)
        {
            //return HttpGet<Login>(UriGetintoLogin, login);
            return HttpPostAsJson<Login>(UriGetintoLogin, login);
        }

        #endregion

        /// <summary>
        /// Obtiene el Listado de Tipos de Transacción
        /// </summary>
        /// <returns></returns>
        public List<TransactionType> GetTransactionTypes()
        {
            return HttpGet<List<TransactionType>>(UriGetTransactionType);
        }

        #region Category Services

        /// <summary>
        /// Obtiene el Listado de Categorías
        /// </summary>
        /// <param name="active">especifica si la consulta es sobre categorías activas o Inactivas</param>
        /// <returns></returns>
        public List<Category> GetCategories(bool? active = null)
        {
            return HttpGet<List<Category>>(UriGetCategory, active);
        }

        /// <summary>
        /// Obtiene una Categoría por Id
        /// </summary>
        /// <param name="categoryId">Id de la Categoría</param>
        /// <returns></returns>
        public Category GetCategory(int categoryId)
        {
            return HttpGet<Category>(UriGetCategoryById, categoryId);
        }

        /// <summary>
        /// Método para Insertar Categorías
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool InsertCategory(Rp3.Test.Common.Models.Category category)
        {
            return HttpPostAsJson<bool>(UriInsertCategory, category);
        }

        public bool UpdateCategory(Rp3.Test.Common.Models.Category category)
        {
            return HttpPostAsJson<bool>(UriUpdateCategory, category);
        }

        #endregion

        #region Transaction Services

        /// <summary>
        /// Obtiene el Listado de Transacciones
        /// </summary>
        /// <returns></returns>
        public List<Balance> GetBalance(int IdLogin)
        {
            return HttpGet<List<Balance>>(UriGetBalance, IdLogin);
        }

        /// <summary>
        /// Obtiene el Listado de Transacciones
        /// </summary>
        /// <returns></returns>
        public List<TransactionView> GetTransactions(int IdLogin)
        {
            return HttpGet<List<TransactionView>>(UriGetTransactions, IdLogin);
        }

        /// <summary>
        /// Obtiene Transaccion por ID
        /// </summary>
        /// <returns></returns>
        public Transaction GetTransactions(int IdLogin, int TransactionId)
        {
            return HttpGet<Transaction>(UriGetTransactionsById, IdLogin, TransactionId);
        }

        /// <summary>
        /// Insertar Transaccion
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool InsertTransaction(Rp3.Test.Common.Models.Transaction transaction)
        {
            return HttpPostAsJson<bool>(UriInsertTransaction, transaction);
        }

        /// <summary>
        /// Modificar transaccion
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool UpdateTransaction(Rp3.Test.Common.Models.Transaction transaction)
        {
            return HttpPostAsJson<bool>(UriUpdateTransaction, transaction);
        }

        #endregion


    }
}