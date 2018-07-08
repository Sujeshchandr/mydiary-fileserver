using MyDiary.FileServer.Domain.Models.FactoryPattern;
using Ninject.Modules;
using NLog;

namespace Configuration.Ioc
{
    public class ApplicationConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            //1. Application
           Bind<ILogger>().ToMethod(context => LogManager.GetLogger("default")).InSingletonScope();
           Bind<MyDiary.FileServer.Application.Services.UploadSession.Contract.IUploadSessionService>().To<MyDiary.FileServer.Application.Services.UploadSession.UploadSessionService>().InSingletonScope();
           Bind<MyDiary.FileServer.Application.Services.File.Core.Contract.IFileService>().To<MyDiary.FileServer.Application.Services.File.Core.FileService>().InSingletonScope();
           Bind<MyDiary.FileServer.Application.Services.Version.Contract.IFileVersionService>().To<MyDiary.FileServer.Application.Services.Version.FileVersionService>().InSingletonScope();
           Bind<MyDiary.FileServer.Application.Services.ReadLink.Contract.IReadLinkService>().To<MyDiary.FileServer.Application.Services.ReadLink.ReadLinkService>().InSingletonScope();

            //[Contextual Binding]

            //2. StoredObjectNameProvider CHAIN OF RESPONSIBILITIES
           Bind<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>()
               .To<MyDiary.FileServer.Application.Providers.UploadSession.UploadSessionNameProvider>()
               .InSingletonScope(); // Required in the first part of the chain - determines the scope of the whole chain.

           Bind<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>()
                .To<MyDiary.FileServer.Application.Providers.File.FileNameProvider>()
                .WhenInjectedInto<MyDiary.FileServer.Application.Providers.UploadSession.UploadSessionNameProvider>();

           Bind<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>()
                .To<MyDiary.FileServer.Application.Providers.FileVersion.FileVersionNameProvider>()
                .WhenInjectedInto<MyDiary.FileServer.Application.Providers.File.FileNameProvider>()
                .WithConstructorArgument<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>(null); // Required in the last part of the chain.

            //3. Simple constrained resolution: Named bindings ( we need to specify {name} as  [Ninject.Named({name})] in the constructor)
            ////kernel.Bind<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>()
            ////   .To<MyDiary.FileServer.Application.Providers.UploadSession.UploadSessionNameProvider>()
            ////   .Named("uploadSessionNameProvider");

            ////kernel.Bind<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>()
            ////   .To<MyDiary.FileServer.Application.Providers.File.FileNameProvider>()
            ////   .Named("fileNameProvider");

            ////kernel.Bind<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>()
            ////   .To<MyDiary.FileServer.Application.Providers.FileVersion.FileVersionNameProvider>()
            ////   .Named("fileVersionNameProvider");

            //4. Specifying constraints on the type binding using the built-in attribute-based helpers
            //kernel.Bind<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>()
            //   .To<MyDiary.FileServer.Application.Providers.UploadSession.UploadSessionNameProvider>()
            //   .WhenInjectedInto(typeof(MyDiary.FileServer.Application.Services.UploadSession.UploadSessionService));

            //kernel.Bind<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>()
            //   .To<MyDiary.FileServer.Application.Providers.File.FileNameProvider>()
            //   .WhenInjectedInto(typeof(MyDiary.FileServer.Application.Services.File.FileService));

            //kernel.Bind<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>()
            //   .To<MyDiary.FileServer.Application.Providers.FileVersion.FileVersionNameProvider>()
            //  .WhenInjectedInto(typeof(MyDiary.FileServer.Application.Services.FileVersion.FileVersionService));

            ////kernel.Bind<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>()
            ////  .To<MyDiary.FileServer.Application.Providers.UploadSession.UploadSessionNameProvider>()
            ////  .WhenInjectedInto<MyDiary.FileServer.Application.Services.UploadSession.UploadSessionService>();

            ////kernel.Bind<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>()
            ////   .To<MyDiary.FileServer.Application.Providers.File.FileNameProvider>()
            ////   .WhenInjectedInto<MyDiary.FileServer.Application.Services.File.FileService>();

            ////kernel.Bind<MyDiary.FileServer.Application.Providers.Contract.IStoredObjectNameProvider>()
            ////   .To<MyDiary.FileServer.Application.Providers.FileVersion.FileVersionNameProvider>()
            ////  .WhenInjectedInto<MyDiary.FileServer.Application.Services.FileVersion.FileVersionService>();

            // Common
            Bind<IRepository>().To<Repository>().InSingletonScope();
            Bind<IRepositoryFactory>().To<RepositoryFactory>().InSingletonScope();
            //Bind<IRepositoryProvider>().To<RepositoryCrossrefImplementation>().Named("CROSSREF");
            //Bind<IRepositoryProvider>().To<RepositoryDoajImplementation>().Named("DOAJ");
            Bind<IRepositoryProvider>().To<RepositoryFTPImplementation>().InTransientScope().Named("FTP");
        }

        ////public override void Unload()
        ////{
        ////    var a = (base.Kernel == null); 
        ////    base.Unload();
        ////}
    }
}
