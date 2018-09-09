using System;
using System.IO;
using ClArc.Builder;
using Domain.Domain.Users;
using InMemoryInfrastructure.Users;
using Microsoft.Extensions.DependencyInjection;
using MockInteractor.Users;
using NrsLib.SequentiallyJsonDataLoader;
using UseCase.Users.Create;
using UseCase.Users.GetList;
using WebApplication.Presenters;

namespace WebApplication.Configs.DI {
    public class TestDILauncher : IDILauncher {
        public void Launch(IServiceCollection services) {
            services.AddTransient<IUserRepository, InMemoryUserRepository>();

            var nonActionPresenter = new NonActionPresenter();
            services.AddSingleton<IUserCreatePresenter>(nonActionPresenter);
            var debugDataDirectory = Path.Combine(Environment.CurrentDirectory, "bin", "Debug", "netcoreapp2.0", "Data");
            var jsonsLoader = new JsonsLoader(debugDataDirectory);
            services.AddSingleton(jsonsLoader);

            var busBuilder = new SyncUseCaseBusBuilder(services);
            busBuilder.RegisterUseCase<UserCreateRequest, MockUserCreateInteractor>();
            busBuilder.RegisterUseCase<UserGetListRequest, MockUserGetListInteractor>();

            var usecaseBus = busBuilder.Build();
            services.AddSingleton(usecaseBus);
        }
    }
}