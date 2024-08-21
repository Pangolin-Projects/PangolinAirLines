namespace PangolimAirLines.Api.Models
{
    public class Flights
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string AirCraft { get; set; }

        public int AvailableSits { get; set; }
        public string TakeOff { get; set; }
        public string Landing { get; set; }
    }
}
