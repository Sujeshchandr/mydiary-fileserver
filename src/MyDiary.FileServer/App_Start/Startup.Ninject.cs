using Configuration.Ioc;
using Ninject;
using Ninject.Activation.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDiary.FileServer.App_Start
{
    public partial class Startup
    {
        public class NinjectConfig
        {
            ////public static IKernel ConfiguredKernel { get; set; }

            public static IKernel CreateKernel()
            {
                return new StandardKernel(new ApplicationConfigurationModule(),
                                                new DataAccessConfigurationModule());
                ////kernel.GetModules()
                ////      .Where(m => m is ApplicationConfigurationModules) // only for modules I created
                ////      .Where(m => m is DataAccessConfigurationModules) // only for modules I created
                ////      .ForEach(m => kernel.Unload(m.Name));

                ////kernel.Components.Get<ICache>().Clear();

                ////return ConfiguredKernel;
            }
        }
    }
}