using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using DashBoard.Models;

namespace AspNetCoreOData.Service.Controllers
{
    [ODataRoutePrefix("Community")]
    public class ODataCommunityController : ODataController
    {
        private AdminDatabaseContext _db;

        public ODataCommunityController(AdminDatabaseContext DbContext)
        {
            _db = DbContext;
        }

        [ODataRoute]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Get()
        {
            return Ok(_db.Communities.AsQueryable());
        }

        [ODataRoute("({key})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_db.Communities.Find(key));
        }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [ODataRoute("Default.MyFirstFunction")]
        [HttpGet]
        public IActionResult MyFirstFunction()
        {
            return Ok(_db.Communities.Where(t => t.Name.StartsWith("A")));
        }
    }
}