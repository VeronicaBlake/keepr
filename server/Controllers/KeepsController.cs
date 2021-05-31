using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeepsController : ControllerBase
    {
        //just write line 11 and control .
        private readonly KeepsService _kservice;

        public KeepsController(KeepsService kservice)
        {
            _kservice = kservice;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Keep>> GetAllKeeps()
        {
            try
            {
                IEnumerable<Keep> keeps = _kservice.GetAll();
                return Ok(keeps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Keep> GetKeepById(int id)
        {
            try
            {
                Keep keep = _kservice.GetById(id);
                return Ok(keep);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult<Keep> CreateKeep([FromBody] Keep newKeep)
        {
            try
            {
                Keep keep = _kservice.Create(newKeep);
                return Ok(keep);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPut("{id}")]

        public async Task<ActionResult<Keep>> UpdateKeep(int id, [FromBody] Keep k)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                k.Id = id;
                Keep newK = _kservice.Update(k, userInfo.Id);
                newK.Creator = userInfo;
                return Ok(newK);

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpDelete("{id}")]

        public async Task<ActionResult<string>> RemoveKeep(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _kservice.Remove(id, userInfo.Id);
                return Ok("Successfully Removed");

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

