/*********************************************************
 * CreateBy：Hstar
 * CreateOn：14/06/07 18:32:18
 * Description：
 * *******************************************************/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hstar.FinanceSteward.Model
{
    [Table("V3Users")]
    public class UsersEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "请输入账户")]
        [StringLength(16, ErrorMessage = "请输入16位以下账户")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        [StringLength(16, ErrorMessage = "请输入16位以下密码")]
        public string UserPass { get; set; }

        [Required(ErrorMessage = "请输入姓名")]
        public string RealName { get; set; }

        public int UserStatus { get; set; }

        public bool IsManager { get; set; }
    }
}