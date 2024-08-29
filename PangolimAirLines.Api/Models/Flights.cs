using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PangolimAirLines.Api.Models
{
    public class Flights
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string AirCraft { get; set; }
        public int AvailableSits { get; set; }
        public string TakeOff { get; set; }
        public string Landing { get; set; }
    }
}
