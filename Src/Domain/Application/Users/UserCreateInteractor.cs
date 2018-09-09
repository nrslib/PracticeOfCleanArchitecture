using System;
using Domain.Domain.Users;
using UseCase.Users.Create;

namespace Domain.Application.Users {
    public class UserCreateInteractor : IUserCreateUseCase {
        private readonly IUserRepository userRepository;
        private readonly IUserCreatePresenter presenter;

        public UserCreateInteractor(
            IUserRepository userRepository,
            IUserCreatePresenter presenter
        ) {
            this.userRepository = userRepository;
            this.presenter = presenter;
        }

        public UserCreateResponse Handle(UserCreateRequest request) {
            presenter.Progress(10); // 10% 経過

            var username = request.UserName;
            var duplicateUser = userRepository.FindByUserName(username);

            presenter.Progress(30); // 30% 経過

            if (duplicateUser != null) {
                throw new Exception("duplicated");
            }

            presenter.Progress(50); // 50% 経過

            var user = new User(username);

            presenter.Progress(80); // 80% 経過

            userRepository.Save(user);

            var response = new UserCreateResponse(user.Id);
            presenter.Complete(response);

            return response; // 同じレスポンスを
        }
    }
}
