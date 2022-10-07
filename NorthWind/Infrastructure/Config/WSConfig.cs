namespace NorthWind.Infrastructure
{
    public class WsConfig : Domain.Infrastructure.Core.Config
    {
        //public MongoSettings DefaultMongoSettings { get; set; } //moved to BikeDistributor lib for testing purposes
        public WsConfig(string jsonFilePath) : base(jsonFilePath)
        {

        }

        //public string GetMongoServiceIdentity(string serviceName)
        //{
        //    return DefaultMongoSettings.servicesNameSpace + "." + serviceName + ", " + DefaultMongoSettings.servicesDll;
        //}


    }
}
