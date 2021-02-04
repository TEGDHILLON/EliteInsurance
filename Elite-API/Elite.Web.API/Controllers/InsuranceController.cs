using System;
using Elite.Web.API.Business.Managers;
using Elite.Web.API.Others.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Elite.Web.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/insurance")]
    public class InsuranceController : ControllerBase
    {
        private readonly InsuranceManager _insuranceManager;
        public InsuranceController(InsuranceManager insuranceManager)
        {
            _insuranceManager = insuranceManager;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = _insuranceManager.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _insuranceManager.GetById(id);
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult Create(InsuranceDTO insurance)
        {
            try
            {
                var result = _insuranceManager.Create(insurance);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public IActionResult Update(InsuranceDTO insurance)
        {
            if (insurance.Id == 0)
            {
                return BadRequest("Invalid Id");
            }
            try
            {
                var result = _insuranceManager.Update(insurance);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid Id");
            }
            try
            {
                var result = _insuranceManager.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
