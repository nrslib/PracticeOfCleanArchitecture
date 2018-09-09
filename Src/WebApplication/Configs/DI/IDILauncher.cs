using Microsoft.Extensions.DependencyInjection;

namespace WebApplication.Configs.DI
{
    public interface IDILauncher
    {
        void Launch(IServiceCollection services);
    }
}
