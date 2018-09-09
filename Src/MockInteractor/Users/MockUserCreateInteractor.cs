using System;
using System.Threading;
using Domain.Domain.Users;
using UseCase.Users.Create;

namespace MockInteractor.Users
{
    public class MockUserCreateInteractor : IUserCreateUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IUserCreatePresenter presenter;

        public MockUserCreateInteractor(
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

            Thread.Sleep(1000);
            presenter.Progress(30); // 30% 経過

            if (duplicateUser != null) {
                throw new Exception("duplicated");
            }

            Thread.Sleep(1000);
            presenter.Progress(50); // 50% 経過

            var user = new User(username);

            Thread.Sleep(1000);
            presenter.Progress(80); // 80% 経過

            userRepository.Save(user);

            var response = new UserCreateResponse(user.Id);
            presenter.Complete(response);

            return response; // 同じレスポンスを
        }
    }
}
