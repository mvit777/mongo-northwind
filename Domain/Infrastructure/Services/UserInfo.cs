using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Infrastructure.services
{
    public class UserInfo
    {
        [BsonId]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string ShoppingBehavior { get; set; }
        public string AboutMe { get; set; }
        public string Role { get; set; }
    }
}