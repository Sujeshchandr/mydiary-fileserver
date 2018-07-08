using MyDiary.FileServer.Domain.Models.FactoryPattern;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace MyDiary.FileServer.Controllers
{
    [ODataRoutePrefix("containers")]
    public class ContainersController : ODataController
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public ContainersController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            IReadOnlyList<string> containers = new List<string>()
            {
                "articles",
                "researchTopics",
                "eventAbstracts"
            };

            return this.Ok(containers);
        }

        [HttpGet]
        [ODataRoute("({containerName})")]
        public  IHttpActionResult GetByName([FromODataUri]string containerName)
        {
            var rep1 = new Repository()
            {
                Name = "FTP 1",
                Type = "FTP"
            };

            var rep2 = new Repository()
            {
                Name = "FTP 2",
                Type = "FTP"
            };

            var repositoryImplementations =  _repositoryFactory.CreateInstance(rep1);
            var repName =  repositoryImplementations.Deposit();

            var repositoryImplementations1 = _repositoryFactory.CreateInstance(rep2);
            var repName1 = repositoryImplementations1.Deposit();

            IReadOnlyList<string> containers = new List<string>()
            {
                "articles",
                "researchTopics",
                "eventAbstracts"
            };

            return this.Ok(containers.Where(x => x.ToString() == containerName).FirstOrDefault());
        }
    }
}
