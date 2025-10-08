namespace FoodTime.ValueObjects
{
    public record Email
    {
        public string Address { get; }

        private Email(string address)
        {
            Address = address;
        }

        public static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("O email não pode ser nulo ou vazio.", nameof(email));
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new FormatException("O formato do email é inválido.");
            }

            return new Email(email.ToLower().Trim()); // Normaliza o valor
        }
    }
}
