using AddressBook.Common.Interfaces;
using AddressBook.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.Infrastructure;
public static class DependencyInjectionExtensions
{
    public static void AddInfrastructureModules(this IServiceCollection services)
    {
        services.AddSingleton<IContactsRepository, ContactsRepository>();
    }
}
