/*********************************************************
 * CreateBy：Hstar
 * CreateOn：14/06/07 18:29:58
 * Description：
 * *******************************************************/

using System.Data.Entity;

namespace Hstar.FinanceSteward.Model
{
    public class FinanceStewardDbContext : DbContext
    {
        public FinanceStewardDbContext()
            : this("DefaultConnection")
        {
        }

        public FinanceStewardDbContext(string connectionStringName)
            : base(connectionStringName)
        {
            Database.SetInitializer(new NullDatabaseInitializer<FinanceStewardDbContext>());
        }

        /// <summary>
        /// 用户信息表
        /// </summary>
        public IDbSet<UsersEntity> Users { get; set; }
    }
}