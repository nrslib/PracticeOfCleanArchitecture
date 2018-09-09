namespace WebApplication.Models
{
    public class UserSummaryViewModel
    {
        public UserSummaryViewModel(string id, string username)
        {
            Id = id;
            UserName = username;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
    }
}
