using MyDiary.FileServer.Application.Services.File.Core.Contract;
using MyDiary.FileServer.Domain.Models;
using MyDiary.FileServer.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace MyDiary.FileServer.Controllers
{
    [ODataRoutePrefix("containers({containerName})/")]
    public class ContainersFilesController : ODataController
    {
        private readonly IFileService _fileService;

        public ContainersFilesController(IFileService fileService)
        {
            if (fileService == null)
            {
                throw new NotImplementedException("fileService");
            }

            _fileService = fileService;
        }

        [HttpGet]
        [ODataRoute("Files")]
        public IHttpActionResult Get([FromODataUri]string containerName)
        {
            var files = new List<File>
            { 
                 new File
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = "file 1",
                     MediaContentLength =1000,
                     MediaContentType ="image/tiff"

                 },
                  new File
                  {
                       Id = Guid.NewGuid().ToString() ,
                       Name = "file 2",
                       MediaContentLength = 2000,
                       MediaContentType ="image/tiff"
                  }
            };

            return this.Ok(files);
        }

        [HttpGet]
        [ODataRoute("Files({fileId})")]
        public IHttpActionResult GetById([FromODataUri]string containerName, [FromODataUri]string fileId)
        {
            return this.Ok(new File
            {
                Id = Guid.NewGuid().ToString(),
                Name = "file 2",
                MediaContentLength = 2000,
                MediaContentType ="image/tiff"
            });
        }

        [HttpGet]
        [ODataRoute("Files({fileId})/get.name()")]
        public async Task<IHttpActionResult> GetName([FromODataUri]string containerName, [FromODataUri]string fileId)
        {
            if (containerName == null)
            {
                return this.NotFound();
            }

            if (fileId == null)
            {
                return this.NotFound();
            }

            return this.Ok(await _fileService.GetNameAsync(containerName,fileId).ConfigureAwait(false));
        }
    }
}
