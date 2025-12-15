using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation; 

namespace WebApplication1.Models
{
    public class Reservation : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Proszę podać miasto.")]
        public string City { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Proszę podać adres.")]
        public string Address { get; set; }

        [Display(Name = "Numer/Nazwa pokoju")]
        [Required(ErrorMessage = "Proszę podać numer pokoju.")]
        public string RoomName { get; set; }

        [Display(Name = "Właściciel rezerwacji")]
        [Required(ErrorMessage = "Proszę podać nazwisko właściciela.")]
        [MinLength(3, ErrorMessage = "Nazwisko musi mieć co najmniej 3 znaki.")]
        public string Owner { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Proszę podać cenę.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cena musi być większa od 0.")]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        [Display(Name = "Data rezerwacji")]
        [Required(ErrorMessage = "Data jest wymagana.")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Date.HasValue && Date.Value < DateTime.Today)
            {
                yield return new ValidationResult(
                    "Rezerwacja musi dotyczyć daty w przyszłości.",
                    new[] { nameof(Date) });
            }
        }
    }
}