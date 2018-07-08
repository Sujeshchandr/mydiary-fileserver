using MyDiary.FileServer.Application.Services.Version.Contract;
using MyDiary.FileServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace MyDiary.FileServer.Controllers
{
    [ODataRoutePrefix("containers({containerName})/Files({fileId})/")]
    public class ContainersFileVersionsController : ODataController
    {
        private readonly IFileVersionService _fileVersionService;

        public ContainersFileVersionsController(IFileVersionService fileVersionService)
        {
            if (fileVersionService == null)
            {
                throw new NotImplementedException("fileVersionService");
            }

            _fileVersionService = fileVersionService;
        }

        [HttpGet]
        [ODataRoute("Versions")]
        public IHttpActionResult Get([FromODataUri]string containerName, [FromODataUri]string fileId)
        {
            var files = new List<FileVersion>
            { 
                 new FileVersion
                 {
                     Id = Guid.NewGuid().ToString(),
                VersionNumber =1,
                Name = "file 2",
                MediaContentLength = 2000,
                MediaContentType ="image/tiff"

                 },
                  new FileVersion
                  {
                        Id = Guid.NewGuid().ToString(),
                VersionNumber =1,
                Name = "file 2",
                MediaContentLength = 2000,
                MediaContentType ="image/tiff"
                  }
            };

            return this.Ok(files);
        }

        [HttpGet]
        [ODataRoute("Versions({versionNumber})")]
        public IHttpActionResult GetByVersion([FromODataUri]string containerName, [FromODataUri]string fileId ,[FromODataUri]string versionNumber)
        {
            return this.Ok(new FileVersion
            {
                Id = Guid.NewGuid().ToString(),
                VersionNumber =1,
                Name = "file 2",
                MediaContentLength = 2000,
                MediaContentType = "image/tiff"
            });
        }

        [HttpGet]
        [ODataRoute("Versions({versionNumber})/get.name()")]
        public async Task<IHttpActionResult> GetName([FromODataUri]string containerName, [FromODataUri]string fileId, [FromODataUri]string versionNumber)
        {
            if (containerName == null)
            {
                return this.NotFound();
            }

            if (fileId == null)
            {
                return this.NotFound();
            }

            return this.Ok(await _fileVersionService.GetNameAsync(containerName, fileId, int.Parse(versionNumber)).ConfigureAwait(false));
        }
    }
}
