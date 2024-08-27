namespace PangolimAirLines.Api.Data
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string LoginCollection { get; set; } = null!;
        public string FlightsCollection { get; set; } = null!;
    }
}