using Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Ninject;
using System;
using Hangfire;
using System.Threading;
using Microsoft.Owin;

[assembly: Microsoft.Owin.OwinStartup(typeof(MyDiary.FileServer.App_Start.Startup))]
namespace MyDiary.FileServer.App_Start
{
    public partial class Startup
    {
        //// private readonly Func<IKernel> CreateKernel;

        public Startup()
        {
            //// CreateKernel = NinjectConfig.CreateKernel;
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            try
            {
                if (appBuilder == null)
                {
                    throw new ArgumentNullException(nameof(appBuilder));
                }

                //// a) Load all the modules (bindings of all public ninjectmodules defined inside the dll's that matches the pattern "Ninject.Extensions.*.dll", "Ninject.Web*.dll") 
                ////    into the kernel
                 var kernel = NinjectConfig.CreateKernel();

                Hangfire.GlobalConfiguration.Configuration
                        .UseSqlServerStorage("HangfireConnection");

                appBuilder.UseHangfireDashboard("/hangfire");
                appBuilder.UseHangfireServer();

                //// appBuilder.UseNLog();
                appBuilder.UseNinjectMiddleware(() => kernel);
                appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                
               //// appBuilder.UseNinjectWebApi(WebApi.GetConfig(OData.GetEdmModel()));


                appBuilder.UseNinjectWebApi(WebApi.GetConfig());

                var context = new OwinContext(appBuilder.Properties);
                var token = context.Get<CancellationToken>("host.OnAppDisposing");
                if (token != CancellationToken.None)
                {
                    token.Register(() =>
                    {
                        var loggingService = kernel.Get<NLog.ILogger>();

                        loggingService.Info("trying to dispose kernel");

                        if (!kernel.IsDisposed)
                        {
                            kernel.Dispose();
                            loggingService.Info("kernel disposed");
                        }
                        else
                        {
                            loggingService.Info("kernel already disposed");
                        }

                        loggingService.Info("application stopped");
                    });
                }
            }
            catch (Exception ex)
            {
                var loggingService = NLog.LogManager.GetLogger("defaultApplication");
                loggingService.Error(ex.Message);
            }

        }
    }
}