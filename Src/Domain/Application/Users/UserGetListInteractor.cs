using System.Linq;
using Domain.Domain.Users;
using UseCase.Users.Commons;
using UseCase.Users.GetList;

namespace Domain.Application.Users {
    public class UserGetListInteractor : IUserGerListUseCase {
        private readonly IUserRepository userRepository;

        public UserGetListInteractor(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public UserGetListResponse Handle(UserGetListRequest request) {
            var users = userRepository.FindAll();
            return new UserGetListResponse(
                users.Select(x => new UserSummary(x.Id, x.UserName)).ToList()
            );
        }
    }
}
