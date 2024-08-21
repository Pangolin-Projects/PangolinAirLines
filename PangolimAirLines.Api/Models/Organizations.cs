namespace PangolimAirLines.Api.Models
{
    public class Organizations
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
