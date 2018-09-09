using ClArc.Sync.Core;

namespace UseCase.Users.Create {
    public class UserCreateResponse : IResponse
    {
        public UserCreateResponse(string userId) {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
