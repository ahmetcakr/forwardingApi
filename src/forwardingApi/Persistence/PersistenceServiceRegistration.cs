using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:BaseDb"]));

        // Google cloud mssql connection string
        // services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:AzureSql"]));

        


        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICommercialDetailRepository, CommercialDetailRepository>();
        services.AddScoped<ICommercialTypeRepository, CommercialTypeRepository>();
        services.AddScoped<ICommercialDetailRepository, CommercialDetailRepository>();
        services.AddScoped<ICommercialTypeRepository, CommercialTypeRepository>();
        services.AddScoped<ICustomerCommercialDetailRepository, CustomerCommercialDetailRepository>();
        services.AddScoped<ICustomerCommercialTypeRepository, CustomerCommercialTypeRepository>();
        services.AddScoped<ICustomerEBillRepository, CustomerEBillRepository>();
        services.AddScoped<ICustomerEBillRepository, CustomerEBillRepository>();
        services.AddScoped<ICustomerFirmTypeRepository, CustomerFirmTypeRepository>();
        services.AddScoped<ICustomerFirmTypeRepository, CustomerFirmTypeRepository>();
        services.AddScoped<ICustomerGroupRepository, CustomerGroupRepository>();
        services.AddScoped<ICustomerSectorRepository, CustomerSectorRepository>();
        services.AddScoped<IEBillRepository, EBillRepository>();
        services.AddScoped<IFirmTypeRepository, FirmTypeRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<ISectorRepository, SectorRepository>();
        services.AddScoped<IDemurrageRepository, DemurrageRepository>();
        services.AddScoped<IDetentionRepository, DetentionRepository>();
        services.AddScoped<IFeederRepository, FeederRepository>();
        services.AddScoped<IBookingTypeRepository, BookingTypeRepository>();
        services.AddScoped<IConsigneRepository, ConsigneRepository>();
        services.AddScoped<IFreeDayRepository, FreeDayRepository>();
        services.AddScoped<IPodRepository, PodRepository>();
        services.AddScoped<IPolRepository, PolRepository>();
        services.AddScoped<IRouteRepository, RouteRepository>();
        services.AddScoped<IShipRepository, ShipRepository>();
        services.AddScoped<ITotalFeeRepository, TotalFeeRepository>();
        services.AddScoped<IVoyageRepository, VoyageRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IBookingTypeRepository, BookingTypeRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IPortRepository, PortRepository>();
        return services;
    }
}
