namespace Domain.Models
{
    public class Products
    {
        public string _id {get; set;} 
        public string _changed {get; set;} 
        public string _created {get; set;} 
        public string _createdby {get; set;} 
        public int _version {get; set;} 
        public int CategoryID {get; set;} 
        public int Discontinued {get; set;} 
        public int ProductID {get; set;} 
        public string ProductName {get; set;} 
        public string QuantityPerUnit {get; set;} 
        public int ReorderLevel {get; set;} 
        public int SupplierID {get; set;} 
        public int UnitPrice {get; set;} 
        public int UnitsInStock {get; set;} 
        public int UnitsOnOrder {get; set;} 

    }
}
