using System.Linq;
using Hstar.FinanceSteward.IBLL;
using Hstar.FinanceSteward.Model;

namespace Hstar.FinanceSteward.BLL
{
    public class HomeBll : IHomeBll
    {
        private readonly FinanceStewardDbContext db=new FinanceStewardDbContext();
        public UsersEntity IsLoginSucceed(UsersEntity user)
        {
            return db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.UserPass == user.UserPass);
        }
    }
}