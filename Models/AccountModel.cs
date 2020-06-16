using Models.framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Models
{
    public class AccountModel
    {
        private BloggerDbContext context = null;
        public AccountModel()
        {
            context = new BloggerDbContext();
        }
        public bool Login(string username, string password)
        {
            //thu thuat truyen 2 tham so vao 
            object[] sqlParams =
            {
                new SqlParameter("@UserName",username),
                new SqlParameter("@Password",password),
            };
            var res =
                context.Database.SqlQuery<bool>("sp_Account_Login @UserName,@Password", sqlParams).SingleOrDefault();
            return res;
        }

    }

    }
