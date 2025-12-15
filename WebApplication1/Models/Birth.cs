using System;

namespace WebApplication1.Models
{
    public class Birth
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        
        public int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - BirthDate.Year;

            if (BirthDate.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && BirthDate < DateTime.Now;
        }
    }
}