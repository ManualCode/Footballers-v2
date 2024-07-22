using System.ComponentModel.DataAnnotations;

namespace Footballers_v2.Models
{
    public class Footballer
    {
        [Key]
        public required Guid Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public required string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public required string LastName { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public required string Gender { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public required DateOnly Birthday { get; set; }

        [Display(Name = "Команда")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public required string TeamName { get; set; }

        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public required string Country { get; set; }
    }
}
