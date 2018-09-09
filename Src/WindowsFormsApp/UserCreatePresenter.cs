using System;
using UseCase.Users.Create;

namespace WindowsFormsApp {
    public class UserCreatePresenter : IUserCreatePresenter {
        public event Action<int> Progressed = delegate { };
        public event Action<UserCreateCompleteModel> Completed = delegate { };

        public void Progress(int percentage) {
            var message = new UserCreateProgressedModel(percentage);
            MessageBus.Instance.Send(message);
        }

        public void Complete(UserCreateResponse response) {
            var message = new UserCreateCompleteModel(response.UserId);
            MessageBus.Instance.Send(message);
        }
    }
}
