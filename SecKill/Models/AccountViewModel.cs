using System.ComponentModel.DataAnnotations;

namespace SecKill.Models
{
    public class AccountViewModel
    {
        [Required(ErrorMessage ="用户名必填")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="密码必填")]
        public string Password { get; set; }
    }
}
