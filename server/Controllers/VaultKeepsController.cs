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
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vkservice;
        public VaultKeepsController(VaultKeepsService vkservice)
        {
            {
                _vkservice = vkservice;
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VaultKeeps>> CreateVaultKeep([FromBody] VaultKeeps newVaultKeep)
        {
            try
            {
                Profile profile = await HttpContext.GetUserInfoAsync<Profile>();
                newVaultKeep.creatorId = profile.Id;
                return Ok(_vkservice.Create(newVaultKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<VaultKeeps>> GetVaultKeeps(int id)
        {
            try
            {
                return Ok(_vkservice.GetVaultKeeps(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> Remove(int id)
        {
            try
            {
                Profile profile = await HttpContext.GetUserInfoAsync<Profile>();
                _vkservice.DeleteVaultKeeps(id, profile.Id);
                return Ok("Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
