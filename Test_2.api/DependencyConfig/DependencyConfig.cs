
using App.BLL.Implementations;
using App.BLL.Interface;
using App.DAL.Implementations;
using App.DAL.Interface;
using TFU.BLL.Implements;
using TFU.BLL.Interfaces;
using TFU.DAL.Implements;
using TFU.DAL.Interfaces;
using TFU.Services;

namespace App.EcommerceAPI.DependencyConfig
{
    public class DependencyConfig
    {
        public static void Register(IServiceCollection services)
        {
            //TFU Service
            services.AddTransient<IEmailSender, EmailSender>();

            //BLL
            services.AddTransient<IIdentityBizLogic, IdentityBizLogic>();
            services.AddTransient<ITFUBizLogic, TFUBizLogic>();
			   services.AddTransient<ICustomerBizLogic, CustomerBizLogic>();

			   //DAL
			   services.AddTransient<IIdentityRepository, IdentityRepository>();
            services.AddTransient<ITFURepository, TFURepository>();
			   services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
