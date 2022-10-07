using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    [BsonIgnoreExtraElements]
    public class Regions
    {
        public string _id {get; set;} 
        public string RegionDescription {get; set;} 
        public int RegionID {get; set;} 

    }
}
