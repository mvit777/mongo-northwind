using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Models
{
    [BsonIgnoreExtraElements]
    public class Customers
    {
        public string _id {get; set;}
        public string Address { get; set; } = "";
        public string City {get; set;} = "";
        public string CompanyName {get; set;} = "";
        public string ContactName {get; set;} = "";
        public string ContactTitle {get; set;} = "";
        public string Country {get; set;} = "";
        public string CustomerID {get; set;} = "";
        public string Fax {get; set;} = "";
        public string Phone {get; set;} = "";
        public int PostalCode { get; set; }
        public string Region {get; set;} = "";

    }
}
