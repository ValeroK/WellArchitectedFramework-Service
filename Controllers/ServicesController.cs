using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WellArchitectedServices.Data;
using WellArchitectedServices.MySQL;

namespace WellArchitectedServices.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {

        [HttpGet()]
        public async Task<IActionResult> Services()
        {
            using (var db = new AppDb())
            {
                await db.Connection.OpenAsync();
                var query = new ServicesQuery(db);
                var services = await query.FindAll();
                return new OkObjectResult(services.ToArray());
            }
        }
    }
}
