using System.ComponentModel.DataAnnotations;

namespace Footballers_v2.Models
{
    public class Footballer
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string? FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string? LastName { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string? Gender { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public DateOnly Birthday { get; set; }

        [Display(Name = "Команда")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string? TeamName { get; set; }

        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string? Country { get; set; }
    }
}
