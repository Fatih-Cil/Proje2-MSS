using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ServiceIOC
    {
        public static void AddBusinessIOC(this IServiceCollection services)
        {

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeDal, EfEmployeeDal>();
            services.AddScoped<IAuthorityService, AuthorityManager>();
            services.AddScoped<IAuthorityDal, EfAuthorityDal>();
            services.AddScoped<IShopService, ShopManager>();
            services.AddScoped<IShopDal, EfShopDal>();
            services.AddScoped<IShiftService, ShiftManager>();
            services.AddScoped<IShiftDal, EfShiftDal>();
            services.AddScoped<ICampaignService, CampaignManager>();
            services.AddScoped<ICampaignDal, EfCampaignDal>();
            services.AddScoped<IFinanceService, FinanceManager>();
            services.AddScoped<IFinanceDal, EfFinanceDal>();
            services.AddScoped<IShowCaseService, ShowCaseManager>();
            services.AddScoped<IShowCaseDal, EfShowCaseDal>();
            services.AddScoped<IAssignService, AssignManager>();
            services.AddScoped<IShopCampaignService, ShopCampaignManager>();
            services.AddScoped<IEmployeeShopDal, EfEmployeeShopDal>();
            services.AddScoped<IShopCampaignDal, EfShopCampaignDal>();
            services.AddScoped<IVisitorEventService, VisitorEventManager>();
            services.AddScoped<IVisitorEventDal, EfVisitorEventDal>();

        }
    }
}
