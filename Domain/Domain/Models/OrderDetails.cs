using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    [BsonIgnoreExtraElements]
    public class OrderDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id {get; set;}
        public string _changed { get; set; } = "";
        public string _created {get; set;} = "";
        public string _createdby {get; set;} = "";
        public int _version {get; set;} 
        public int Discount {get; set;} 
        public int OrderID {get; set;} 
        public int ProductID {get; set;} 
        public int Quantity {get; set;} 
        public int UnitPrice {get; set;} 

    }
}
