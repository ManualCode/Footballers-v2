using System.ComponentModel.DataAnnotations;

namespace Footballers_v2.Models
{
    public class Footballer
    {
        [Key]
        public required Guid Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Необходимо заполнить Имя")]
        public required string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Необходимо заполнить Фамилия")]
        public required string LastName { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Необходимо выбрать пол")]
        public required string Gender { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Необходимо указать дату")]
        public required DateOnly? Birthday { get; set; }

        [Display(Name = "Команда")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public required string TeamName { get; set; }

        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public required string Country { get; set; }
    }
}
