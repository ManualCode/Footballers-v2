using System.ComponentModel.DataAnnotations;

namespace Footballers_v2.Enums
{
    public enum Country
    {
        [Display(Name = "Россия")]
        Россия,
        [Display(Name = "США")]
        США,
        [Display(Name = "Италия")]
        Италия
    }
}
