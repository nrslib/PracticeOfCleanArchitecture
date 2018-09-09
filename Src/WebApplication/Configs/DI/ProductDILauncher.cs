using ClArc.Builder;
using Domain.Application.Users;
using Domain.Domain.Users;
using Microsoft.Extensions.DependencyInjection;
using MySqlInfrastructure.Users;
using UseCase.Users.Create;
using UseCase.Users.GetList;
using WebApplication.Presenters;

namespace WebApplication.Configs.DI {
    public class ProductDILauncher : IDILauncher {
        public void Launch(IServiceCollection services) {
            services.AddSingleton<IUserRepository, UserRepository>();
            var nonActionPresenter = new NonActionPresenter();
            services.AddSingleton<IUserCreatePresenter>(nonActionPresenter);

            var busBuilder = new SyncUseCaseBusBuilder(services);
            busBuilder.RegisterUseCase<UserCreateRequest, UserCreateInteractor>();
            busBuilder.RegisterUseCase<UserGetListRequest, UserGetListInteractor>();

            var usecaseBus = busBuilder.Build();
            services.AddSingleton(usecaseBus);
        }
    }
}
