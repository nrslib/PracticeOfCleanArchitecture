using ClArc.Builder;
using Domain.Application.Users;
using Domain.Domain.Users;
using InMemoryInfrastructure.Users;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Users.Create;
using UseCase.Users.GetList;
using WebApplication.Presenters;

namespace WebApplication.Configs.DI
{
    /// <summary>
    /// Interactor は Product 用でデータはインメモリで動作
    /// </summary>
    public class LocalDILauncher : IDILauncher {
        public void Launch(IServiceCollection services) {
            services.AddSingleton<IUserRepository, InMemoryUserRepository>();
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
