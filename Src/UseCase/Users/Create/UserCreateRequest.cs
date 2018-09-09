using ClArc.Sync.Core;

namespace UseCase.Users.Create
{
    public class UserCreateRequest : IRequest<UserCreateResponse>
    {
        public UserCreateRequest(string userName) {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
