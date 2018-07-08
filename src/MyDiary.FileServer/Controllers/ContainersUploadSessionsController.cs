using MyDiary.FileServer.Application.Services.UploadSession.Contract;
using MyDiary.FileServer.Domain.Models;
using MyDiary.FileServer.Domain.Models.UploadSessons;
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
    public class ContainersUploadSessionsController : ODataController
    {

        private readonly IUploadSessionService _uploadSessionService;

        public ContainersUploadSessionsController(IUploadSessionService uploadSessionService)
        {
            if (uploadSessionService == null)
            {
                throw new NotImplementedException("UploadSessionservice");
            }

            _uploadSessionService = uploadSessionService;
        }

        [HttpGet]
        [ODataRoute("UploadSessions")]
        public IHttpActionResult Get([FromODataUri]string containerName)
        {
            var uploadSessions = new List<UploadSession>
            { 
                 new UploadSession
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = "file 1",
                     Length =1000

                 },
                  new UploadSession
                  {
                       Id = Guid.NewGuid().ToString() ,
                       Name = "file 2",
                       Length =2000
                  }
            };

            return this.Ok(uploadSessions);
        }

        [HttpGet]
        [ODataRoute("UploadSessions({uploadSessionId})")]
        public IHttpActionResult GetUploadSession([FromODataUri]string containerName)
        {
            return this.Ok(new UploadSession
            {
                Id = Guid.NewGuid().ToString(),
                Name = "file 1",
                Length = 1000

            });
        }

        [HttpGet]
        [ODataRoute("UploadSessions({uploadSessionId})/get.name()")]
        public async Task<IHttpActionResult> Get([FromODataUri]string containerName, [FromODataUri]string uploadSessionId)
        {
            if (containerName == null)
            {
                return this.NotFound();
            }

            if (uploadSessionId == null)
            {
                return this.NotFound();
            }

            return this.Ok(await _uploadSessionService.GetNameAsync(containerName,uploadSessionId).ConfigureAwait(false));
        }
    }
}
