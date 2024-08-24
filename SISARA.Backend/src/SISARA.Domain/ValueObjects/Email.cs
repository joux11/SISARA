using System.Text.RegularExpressions;

namespace SISARA.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value) 
        {      

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("El email no puede esta vacio o ser null");
            }
            if (!IsValidEmail(value))
            {
                throw new Exception("Email invalido!");
            }
            Value = value;
        }
        public static implicit operator string(Email email) => email.Value;

        public bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return emailRegex.IsMatch(email);
        }
    }
}
