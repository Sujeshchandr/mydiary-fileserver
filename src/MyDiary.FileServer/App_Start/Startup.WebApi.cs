using MyDiary.FileServer.Domain.Models;
using MyDiary.FileServer.Domain.Models.Core;
using MyDiary.FileServer.Domain.Models.ReadLinks;
using MyDiary.FileServer.Domain.Models.UploadSessons;
using System;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData.Batch;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;

namespace MyDiary.FileServer.App_Start
{
    public partial class Startup
    {
        public class WebApi
        {
            public static HttpConfiguration GetConfig()
            {
                var config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();

                var cors = new EnableCorsAttribute("*", "*", "*");
                config.EnableCors(cors);

                var pathHandler = new DefaultODataPathHandler();
                var routingConventions = ODataRoutingConventions.CreateDefault();
                var batchHandler = new DefaultODataBatchHandler(new HttpServer(config));
                    
                config.MapODataServiceRoute(
                       routeName: "FileServer",
                       routePrefix: "v1",
                       model: OData.GetEdmModel());

                config.EnsureInitialized();

                return config;
             }

        }
    }
}