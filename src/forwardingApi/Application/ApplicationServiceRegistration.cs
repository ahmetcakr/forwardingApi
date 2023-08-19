using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.ElasticSearch;
using Core.Mailing;
using Core.Mailing.MailKitImplementations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services.Customers;
using Application.Services.CommercialDetails;
using Application.Services.CommercialTypes;
using Application.Services.CustomerCommercialDetails;
using Application.Services.CustomerCommercialTypes;
using Application.Services.CustomerEBills;
using Application.Services.CustomerFirmTypes;
using Application.Services.CustomerGroups;
using Application.Services.CustomerSectors;
using Application.Services.EBills;
using Application.Services.FirmTypes;
using Application.Services.Groups;
using Application.Services.Sectors;
using Application.Services.Demurrages;
using Application.Services.Detentions;
using Application.Services.Feeders;
using Application.Services.BookingTypes;
using Application.Services.Consignes;
using Application.Services.FreeDays;
using Application.Services.Pods;
using Application.Services.Pols;
using Application.Services.Routes;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddScoped<ICustomersService, CustomersManager>();
        services.AddScoped<ICommercialDetailsService, CommercialDetailsManager>();
        services.AddScoped<ICommercialTypesService, CommercialTypesManager>();
        services.AddScoped<ICommercialDetailsService, CommercialDetailsManager>();
        services.AddScoped<ICommercialTypesService, CommercialTypesManager>();
        services.AddScoped<ICustomerCommercialDetailsService, CustomerCommercialDetailsManager>();
        services.AddScoped<ICustomerCommercialTypesService, CustomerCommercialTypesManager>();
        services.AddScoped<ICustomerEBillsService, CustomerEBillsManager>();
        services.AddScoped<ICustomerEBillsService, CustomerEBillsManager>();
        services.AddScoped<ICustomerFirmTypesService, CustomerFirmTypesManager>();
        services.AddScoped<ICustomerFirmTypesService, CustomerFirmTypesManager>();
        services.AddScoped<ICustomerGroupsService, CustomerGroupsManager>();
        services.AddScoped<ICustomerSectorsService, CustomerSectorsManager>();
        services.AddScoped<IEBillsService, EBillsManager>();
        services.AddScoped<IFirmTypesService, FirmTypesManager>();
        services.AddScoped<IGroupsService, GroupsManager>();
        services.AddScoped<ISectorsService, SectorsManager>();
        services.AddScoped<IDemurragesService, DemurragesManager>();
        services.AddScoped<IDetentionsService, DetentionsManager>();
        services.AddScoped<IFeedersService, FeedersManager>();
        services.AddScoped<IBookingTypesService, BookingTypesManager>();
        services.AddScoped<IConsignesService, ConsignesManager>();
        services.AddScoped<IFreeDaysService, FreeDaysManager>();
        services.AddScoped<IPodsService, PodsManager>();
        services.AddScoped<IPolsService, PolsManager>();
        services.AddScoped<IRoutesService, RoutesManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
