using ClArc.Builder;
using Domain.Domain.Users;
using InMemoryInfrastructure.Users;
using Microsoft.Extensions.DependencyInjection;
using MockInteractor.Users;
using MySqlInfrastructure.Users;
using UseCase.Users.Create;

namespace ConsoleApp {
    public static class Startup {
        public static void Run() {
#if DEBUG
            setupDebug();
#else
            setupProduct();
#endif
            ServiceProvider.Build();
        }

        private static void setupProduct() {
            var services = ServiceProvider.ServiceCollection;
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IUserCreatePresenter, ConsolePresenter>();

            var busBuilder = new SyncUseCaseBusBuilder(services);
            busBuilder.RegisterUseCase<UserCreateRequest, MockUserCreateInteractor>();
            var bus = busBuilder.Build();
            services.AddSingleton(bus);
        }

        private static void setupDebug() {
            var services = ServiceProvider.ServiceCollection;
            services.AddTransient<IUserRepository, InMemoryUserRepository>();

            services.AddTransient<IUserCreatePresenter, ConsolePresenter>();
            // ファイルに出力してみたい場合は↑をコメントアウトして↓のコメントを外す
//            services.AddTransient<IUserCreatePresenter, FilePresenter>();

            var busBuilder = new SyncUseCaseBusBuilder(services);
            busBuilder.RegisterUseCase<UserCreateRequest, MockUserCreateInteractor>();
            var bus = busBuilder.Build();
            services.AddSingleton(bus);
        }
    }
}
