using Hstar.FinanceSteward.Model;

namespace Hstar.FinanceSteward.IBLL
{
    public interface IHomeBll
    {
        UsersEntity IsLoginSucceed(UsersEntity user);
    }
}