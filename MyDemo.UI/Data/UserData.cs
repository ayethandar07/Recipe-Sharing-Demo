using MyDemo.UI.Models;
using Newtonsoft.Json;

namespace MyDemo.UI.Data
{
    public class UserData
    {
        public List<User> Users { get; set; }

        public UserData() 
        {
            string jsonData = @"[
                {
                    ""Id"": ""1"",
                    ""Email"": ""user1@gmail.com"",
                    ""Password"": ""$2b$12$rLvU0ZiXz8aMz7G.8B8KQO9Z7ZcqoQ/xcD91yCMQAm/gIB/yFGqg6""
                },
                {
                    ""Id"": ""2"",
                    ""Email"": ""user2@gmail.com"",
                    ""Password"": ""$2b$12$XkBLkIRbEfT4U5EJ7zOZGOOSMN48mc81P0HyOr50ZqJW9rTatvJ9K""
                }
            ]";

            Users = JsonConvert.DeserializeObject<List<User>>(jsonData);
        }
    }
}
