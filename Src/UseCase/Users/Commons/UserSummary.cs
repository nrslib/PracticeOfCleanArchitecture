namespace UseCase.Users.Commons
{
    public class UserSummary
    {
        public UserSummary(string id, string userName) {
            Id = id;
            UserName = userName;
        }

        public string Id { get; }
        public string UserName { get; }
    }
}
