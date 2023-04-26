using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebook.Helpers
{
    internal class Validation
    {
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            // Implementarea logicii de validare a numărului de telefon
            // Exemplu simplu: verifică dacă are 10 caractere și conține doar cifre
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }

        public bool IsValidEmailAddress(string emailAddress)
        {
            // Implementarea logicii de validare a adresei de email
            // Exemplu simplu: verifică dacă are un format valid de email
            return !string.IsNullOrEmpty(emailAddress) && new EmailAddressAttribute().IsValid(emailAddress);
        }
    }
}
