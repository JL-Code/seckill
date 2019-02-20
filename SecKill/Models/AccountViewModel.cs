using System.ComponentModel.DataAnnotations;

namespace SecKill.Models
{
    public class AccountViewModel
    {
        [Required(ErrorMessage ="账号必填")]
        public string Account { get; set; }

        [Required(ErrorMessage ="密码必填")]
        public string Password { get; set; }
    }
}
