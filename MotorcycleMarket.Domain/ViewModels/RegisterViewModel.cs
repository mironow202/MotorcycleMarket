using System.ComponentModel.DataAnnotations;

namespace MotorcycleMarket.Domain.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Укажите имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина имени должна быть от 3 до 40 символов")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина имени должна быть от 3 до 40 символов")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина имени должна быть от 3 до 40 символов")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordComfirm { get; set; }
    }
}
