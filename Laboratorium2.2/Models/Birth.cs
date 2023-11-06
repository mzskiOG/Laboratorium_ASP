using System;

namespace Laboratorium2._2.Models
{
    public class Birth
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && BirthDate < DateTime.Now;
        }

        public void CalculateAge()
        {
            if (IsValid())
            {
                int age = DateTime.Now.Year - BirthDate.Year;
                if (BirthDate.Date > DateTime.Now.AddYears(-age)) age--;

                Message = $"Cześć {Name}, masz {age} lat(a).";
            }
            else
            {
                Error = "Nieprawidłowe dane. Proszę wprowadzić poprawne imię i datę urodzenia.";
            }
        }
    }
}
