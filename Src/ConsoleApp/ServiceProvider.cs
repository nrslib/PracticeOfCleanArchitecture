using System;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp {
    public static class ServiceProvider {
        private static readonly IServiceCollection services = new ServiceCollection();
        private static IServiceProvider provider;
        private static bool built;

        public static IServiceCollection ServiceCollection => services;

        public static void Build() {
            if (built) {
                throw new Exception("already built");
            }
            built = true;
            provider = services.BuildServiceProvider();
        }

        public static T GetService<T>() {
            return provider.GetService<T>();
        }
    }
}
