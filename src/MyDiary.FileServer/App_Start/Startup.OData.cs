using MyDiary.FileServer.Domain.Models;
using MyDiary.FileServer.Domain.Models.Core;
using MyDiary.FileServer.Domain.Models.ReadLinks;
using MyDiary.FileServer.Domain.Models.UploadSessons;
using System;
using System.Text;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;

namespace MyDiary.FileServer.App_Start
{
    public partial class Startup
    {
        public class OData
        {
            private static string DefaultTypeNameSpace = "type";
            private static string DefaultActionNameSpace = "action";

            public static HttpConfiguration InitRoutes(HttpConfiguration config)
            {
                var pathHandler = new DefaultODataPathHandler();
                var routingConventions = ODataRoutingConventions.CreateDefault();
                var batchHandler = new DefaultODataBatchHandler(new HttpServer(config));

                config.MapODataServiceRoute(
                       routeName: "FileServer",
                       routePrefix: "v1",
                       model: GetEdmModel(),
                       pathHandler: pathHandler,
                       routingConventions: routingConventions,
                       batchHandler: batchHandler);

                return config;
             }

            public static Microsoft.OData.Edm.IEdmModel GetEdmModel()
            {
                var modelBuilder = new System.Web.OData.Builder.ODataConventionModelBuilder();
                modelBuilder.ContainerName = "fileServerApi";
                modelBuilder.Namespace = "container";

                #region ENTITY SETS

                var containerEntitySet = modelBuilder.EntitySet<Container>("containers");

                #endregion

                #region ENTITY TYPES

                var containerEntityType = modelBuilder.EntityType<Container>();
                containerEntityType.Name = Camelize(containerEntityType.Name);
                containerEntityType.Namespace = DefaultTypeNameSpace;
                containerEntityType.HasKey(x => x.ContainerName);
                containerEntityType.HasMany(c => c.UploadSessions).Contained().CascadeOnDelete();
                containerEntityType.HasMany(c => c.Files).Contained().CascadeOnDelete();
                containerEntityType.HasMany(c => c.ReadLinks).Contained().CascadeOnDelete();

                var storedObject = modelBuilder.EntityType<StoredObject>();
                storedObject.Name = Camelize(storedObject.Name);
                storedObject.Namespace = DefaultTypeNameSpace;
                storedObject.Property(x => x.ContainerName).IsRequired();
                storedObject.Property(x => x.MediaContentType).IsRequired();
                storedObject.Property(x => x.MediaContentLength).IsRequired();


                var uploadSessionEntityType = modelBuilder.EntityType<UploadSession>();
                uploadSessionEntityType.Name = Camelize(uploadSessionEntityType.Name);
                uploadSessionEntityType.Namespace = DefaultTypeNameSpace;
                uploadSessionEntityType.HasKey(x => x.Id);
                uploadSessionEntityType.Property(x => x.Name).IsRequired();
                uploadSessionEntityType.Property(x => x.Length).IsRequired();

                var fileEntityType = modelBuilder.EntityType<File>();
                fileEntityType.Name = Camelize(fileEntityType.Name);
                fileEntityType.Namespace = DefaultTypeNameSpace;
                fileEntityType.HasKey(x => x.Id);
                fileEntityType.Property(x => x.Name).IsRequired();
                fileEntityType.Property(x => x.MediaContentType).IsRequired();
                fileEntityType.Property(x => x.MediaContentLength).IsRequired();
                fileEntityType.HasMany(c => c.Versions).Contained().CascadeOnDelete();

                var fileVersionEntityType = modelBuilder.EntityType<FileVersion>();
                fileVersionEntityType.Name = Camelize(fileVersionEntityType.Name);
                fileVersionEntityType.Namespace = DefaultTypeNameSpace;
                fileVersionEntityType.HasKey(x => x.Id);
                fileVersionEntityType.Property(x => x.VersionNumber).IsRequired();
                fileVersionEntityType.Property(x => x.Name).IsRequired();
                fileVersionEntityType.Property(x => x.MediaContentType).IsRequired();
                fileVersionEntityType.Property(x => x.MediaContentLength).IsRequired();

                var readLinkEntityType = modelBuilder.EntityType<ReadLink>();
                readLinkEntityType.Name = Camelize(readLinkEntityType.Name);
                readLinkEntityType.Namespace = DefaultTypeNameSpace;
                readLinkEntityType.HasKey(x => x.Id);
                readLinkEntityType.HasMany(c => c.StoredObject).Contained().CascadeOnDelete();

                #endregion

                #region FUNCTIONS

                var uploadSessiongetNameFunction = uploadSessionEntityType.Function("name");
                uploadSessiongetNameFunction.Namespace = "get";
                uploadSessiongetNameFunction.Returns<string>().OptionalReturn = false;

                var filegetNameFunction = fileEntityType.Function("name");
                filegetNameFunction.Namespace = "get";
                filegetNameFunction.Returns<string>().OptionalReturn = false;

                var fileVersiongetNameFunction = fileVersionEntityType.Function("name");
                fileVersiongetNameFunction.Namespace = "get";
                fileVersiongetNameFunction.Returns<string>().OptionalReturn = false;

                var readLinkgetUploadSessionNameFunction = readLinkEntityType.Function("uploadSessionName");
                readLinkgetUploadSessionNameFunction.Namespace = "get";
                readLinkgetUploadSessionNameFunction.Parameter<string>("uploadSessionId").OptionalParameter = false;
                readLinkgetUploadSessionNameFunction.Returns<string>().OptionalReturn = false;

                var readLinkgetfileNameFunction = readLinkEntityType.Function("fileName");
                readLinkgetfileNameFunction.Namespace = "get";
                readLinkgetfileNameFunction.Parameter<string>("fileId").OptionalParameter = false;
                readLinkgetfileNameFunction.Returns<string>().OptionalReturn = false;

                var readLinkgetfileVersionNameFunction = readLinkEntityType.Function("fileVersionName");
                readLinkgetfileVersionNameFunction.Namespace = "get";
                readLinkgetfileVersionNameFunction.Parameter<string>("fileId").OptionalParameter = false;
                readLinkgetfileVersionNameFunction.Parameter<string>("version").OptionalParameter = false;
                readLinkgetfileVersionNameFunction.Returns<string>().OptionalReturn = false;

                #endregion

                return modelBuilder.GetEdmModel();
            }

            private static string Camelize(string text)
            {
                if (text == null)
                {
                    throw new ArgumentNullException("text");
                }

                if (text.Length == 0)
                {
                    return text;
                }

                var stringBuilder = new StringBuilder(text);
                stringBuilder[0] = char.ToLowerInvariant(text[0]);

                return stringBuilder.ToString();
            }
        }
    }
}