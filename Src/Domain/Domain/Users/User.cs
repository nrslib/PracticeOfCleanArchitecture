using System;

namespace Domain.Domain.Users
{
    public class User
    {
        public User(string id, string userName) {
            Id = id;
            userName = UserName;
        }

        public User(string userName) {
            Id = Guid.NewGuid().ToString();
            UserName = userName;
        }

        public string Id { get; }
        public string UserName { get; }
    }
}
