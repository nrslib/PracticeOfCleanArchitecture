using System.Collections.Generic;
using UseCase.Users.Create;

namespace Domain.Tests.Users
{
    public class UserCreateCollector : IUserCreatePresenter
    {
        public List<int> Percentages { get; } = new List<int>();
        public UserCreateResponse Response { get; private set; }

        public void Progress(int percentage) {
            Percentages.Add(percentage);
        }

        public void Complete(UserCreateResponse response) {
            Response = response;
        }
    }
}
