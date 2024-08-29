namespace PangolimAirLines.Api.Data
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string OrganizationCollection { get; set; } = null!;
        public string FlightsCollection { get; set; } = null!;
    }
}