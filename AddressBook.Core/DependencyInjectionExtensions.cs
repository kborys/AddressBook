using AddressBook.Common.Interfaces;
using AddressBook.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.Core;
public static class DependencyInjectionExtensions
{
    public static void AddCoreModules(this IServiceCollection services)
    {
        services.AddScoped<IContactsService, ContactsService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
