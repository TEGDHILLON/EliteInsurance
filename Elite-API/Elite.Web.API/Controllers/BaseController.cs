using Elite.Web.API.Business.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Elite.Web.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/base")]
    public class BaseController : ControllerBase
    {
        private readonly BaseManager _baseManager;
        public BaseController(BaseManager baseManager)
        {
            _baseManager = baseManager;
        }

        [HttpGet("regions")]
        public IActionResult GetAllRegions()
        {
            var result = _baseManager.GetAllRegions();
            return Ok(result);
        }

        [HttpGet("companies/{regionId}")]
        public IActionResult GetAllCompaniesByRegionId(int regionId)
        {
            var result = _baseManager.GetAllCompaniesByRegionId(regionId);
            return Ok(result);
        }

        [HttpGet("makes")]
        public IActionResult GetAllMakes()
        {
            var result = _baseManager.GetAllMakes();
            return Ok(result);
        }

        [HttpGet("models/{makeId}")]
        public IActionResult GetAllModels(int makeId)
        {
            var result = _baseManager.GetAllModels(makeId);
            return Ok(result);
        }
    }
}
