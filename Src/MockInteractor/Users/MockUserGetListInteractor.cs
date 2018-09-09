using System;
using NrsLib.SequentiallyJsonDataLoader;
using UseCase.Users.GetList;

namespace MockInteractor.Users {
    public class MockUserGetListInteractor : IUserGerListUseCase
    {
        private readonly JsonsLoader jsonsLoader;

        public MockUserGetListInteractor(JsonsLoader jsonsLoader)
        {
            this.jsonsLoader = jsonsLoader;
        }

        public UserGetListResponse Handle(UserGetListRequest request)
        {
            return jsonsLoader.Generate<UserGetListResponse>();
        }
    }
}
