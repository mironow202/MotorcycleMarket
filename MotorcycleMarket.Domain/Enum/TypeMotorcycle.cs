using System.ComponentModel.DataAnnotations;

namespace MotorcycleMarket.Domain.Enum
{
    public enum TypeMotorcycle
    {

        [Display(Name = "Классический байк")]
        Classic = 0,
        [Display(Name = "Спортивный байк")]
        Sport = 1,
        [Display(Name = "Внедорожник байк")]
        Offroad = 2,
        [Display(Name = "Стрит байк")]
        StreetBike = 3,
    }
}
