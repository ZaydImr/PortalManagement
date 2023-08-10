using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Services.HRAPI.Data;
using Portal.Services.HRAPI.Model;

namespace Portal.Services.HRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrAPIController : ControllerBase
    {
        private readonly AppDbContext _db;

        public HrAPIController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<HumanResource> objList = _db.HumanResource.ToList();
                return Ok(objList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
