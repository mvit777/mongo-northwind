using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [BsonIgnoreExtraElements]
    public class Orders
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ? _id { get; set; }
        public string CustomerID { get; set; } = "";
        public int EmployeeID { get; set; } 
        public double Freight { get; set; }
        public string OrderDate { get; set; } = "";
        public int OrderID { get; set; }
        public string RequiredDate { get; set; } = "";
        public string ShipAddress { get; set; } = "";
        public string ShipCity { get; set; } = "";
        public string ShipCountry { get; set; } = "";
        public string ShipName { get; set; } = "";
        public string ShippedDate { get; set; } = "";
        public int ShipPostalCode { get; set; } 
        public string ShipRegion { get; set; } = "";
        public string ShipVia { get; set; } = "";
        public string Status { get; set; } = string.Empty;
    }
}
