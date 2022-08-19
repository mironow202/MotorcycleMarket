using System.ComponentModel.DataAnnotations;

namespace MotorcycleMarket.Domain.ViewModels
{
    public class UserViewModel
    {
        [Display(Name="Id")]
        public long Id { get; set; }
        [Display(Name="Роль")]
        public string Role { get; set; }
        [Display(Name = "Имя")]
        public string UserName { get; set; }
        [Display(Name = "Возраст")]
        public string Age { get; set; }
         
    }
}
