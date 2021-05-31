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
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vservice;

        public VaultsController(VaultsService vservice)
        {
            _vservice = vservice;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Vault>> GetAllVaults()
        {
            try
            {
                IEnumerable<Vault> vaults = _vservice.GetAll();
                return Ok(vaults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Vault> GetVaultById(int id)
        {
            try
            {
                Vault vault = _vservice.GetById(id);
                return Ok(vault);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpGet("{id}/vaults")]
        // public ActionResult<Vault> GetKeepsByVaultById(int id)
        // {
        //     try
        //     {
        //         Vault vault = _vservice.GetKeepByVaultId(id);
        //         return Ok(vault);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        [Authorize]
        [HttpPost]
        public ActionResult<Vault> CreateVault([FromBody] Vault newVault)
        {
            try
            {
                Vault vault = _vservice.Create(newVault);
                return Ok(vault);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPut("{id}")]

        public async Task<ActionResult<Vault>> UpdateVault(int id, [FromBody] Vault v)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                v.Id = id;
                Vault newVault = _vservice.Update(v, userInfo.Id);
                newVault.Creator = userInfo;
                return Ok(newVault);

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpDelete("{id}")]

        public async Task<ActionResult<string>> RemoveVault(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _vservice.RemoveVault(id, userInfo.Id);
                return Ok("Successfully Removed");

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
//CreateVault, GetAll, GetVaultById, GetKeepsByVaultId, UpdateVault, RemoveVault