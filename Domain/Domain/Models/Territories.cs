using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    [BsonIgnoreExtraElements]
    public class Territories
    {
        public string _id {get; set;} 
        //public string _changed {get; set;} 
        //public string _created {get; set;} 
        //public string _createdby {get; set;} 
        //public int _version {get; set;} 
        public int RegionID {get; set;} 
        public string TerritoryDescription {get; set;} 
        public int TerritoryID {get; set;} 

    }
}
