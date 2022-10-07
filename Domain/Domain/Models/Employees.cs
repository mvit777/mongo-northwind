namespace Domain.Models
{
    public class Employees
    {
        
public string ? _id {get; set;}
        public string _changed { get; set; } = ""; 
        public string _created {get; set;} = "";
        public string _createdby {get; set;} = "";
        public int _version {get; set;} 
        public string Address {get; set;} = "";
        public string BirthDate {get; set;} = "";
        public int EmployeeID {get; set;}
        public string FirstName {get; set;} = "";
        public string HireDate {get; set;} = "";
        public string LastName {get; set;} = "";
        public string Title {get; set;} = "";
        public string TitleOfCourtesy {get; set;} = "";

    }
}
