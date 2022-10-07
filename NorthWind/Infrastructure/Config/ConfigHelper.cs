using MV.Framework.providers;

namespace NorthWind.Infrastructure.Config
{
    public static class ConfigHelper
    {
        public static MongoDBContext GetMongoContext(WsConfig config)
        {
            var mongosettings = config.GetClassObject<MongoSettings>("Mongo");

            return new MongoDBContext(mongosettings);
        }
    }
}
