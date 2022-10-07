using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    [BsonIgnoreExtraElements]
    public class Shippers
    {
        public string _id {get; set;} 
        public string CompanyName {get; set;} 
        public string Phone {get; set;} 
        public int ShipperID {get; set;} 

    }
}
