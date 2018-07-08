using MyDiary.FileServer.Application.Services.ReadLink.Contract;
using MyDiary.FileServer.Domain.Models.ReadLinks;
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
    public class ContainersReadLinksController : ODataController
    {
        private readonly IReadLinkService _readLinkService;

        public ContainersReadLinksController(IReadLinkService readLinkService)
        {
            if (readLinkService == null)
            {
                throw new NotImplementedException("readLinkService");
            }

            _readLinkService = readLinkService;
        }

        [HttpGet]
        [ODataRoute("ReadLinks({readLinkId})/get.uploadSessionName(uploadSessionId={uploadSessionId})")]
        public async Task<IHttpActionResult> GetUploadSessionName([FromODataUri]string containerName, [FromODataUri]string readLinkId, [FromODataUri]string uploadSessionId)
        {
            if (containerName == null)
            {
                return this.NotFound();
            }

            if (readLinkId == null)
            {
                return this.NotFound();
            }

            if (uploadSessionId == null)
            {
                return this.NotFound();
            }

            var readLink = new ReadLink()
            {

            };

            return this.Ok(await _readLinkService.GetUploadSessionNameAsync(containerName, uploadSessionId).ConfigureAwait(false));
        }

        [HttpGet]
        [ODataRoute("ReadLinks({readLinkId})/get.fileName(fileId ={fileId})")]
        public async Task<IHttpActionResult> GetFileName([FromODataUri]string containerName, [FromODataUri]string readLinkId, [FromODataUri]string fileId)
        {
            if (containerName == null)
            {
                return this.NotFound();
            }

            if (readLinkId == null)
            {
                return this.NotFound();
            }

            if (fileId == null)
            {
                return this.NotFound();
            }

            var readLink = new ReadLink()
            {

            };

            return this.Ok(await _readLinkService.GetFileNameAsync(containerName, fileId).ConfigureAwait(false));
        }

        [HttpGet]
        [ODataRoute("ReadLinks({readLinkId})/get.fileVersionName(fileId ={fileId},version = {version})")]
        public async Task<IHttpActionResult> GetFileVersionName([FromODataUri]string containerName,
                                                     [FromODataUri]string readLinkId,
                                                     [FromODataUri]string fileId,
                                                     [FromODataUri]string version)
        {
            if (containerName == null)
            {
                return this.NotFound();
            }

            if (readLinkId == null)
            {
                return this.NotFound();
            }

            if (fileId == null)
            {
                return this.NotFound();
            }

            var readLink = new ReadLink()
            {

            };

            return this.Ok(await _readLinkService.GetFileVersionNameAsync(containerName, fileId, int.Parse(version)).ConfigureAwait(false));
        }
    }
}
