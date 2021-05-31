using Microsoft.AspNetCore.Mvc;
using server.Services;
using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using server.Models;
using System.Collections.Generic;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _pservice;
        private readonly VaultsService _vservice;
        private readonly KeepsService _kservice;

        public ProfilesController(ProfilesService pservice, VaultsService vservice, KeepsService kservice)
        {
            _pservice = pservice;
            _vservice = vservice;
            _kservice = kservice;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Profile>> Get()
        //we won't need a get all
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_pservice.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> GetProfile(string id)
        {
            try
            {
                Profile p = _pservice.GetProfileById(id);
                return Ok(p);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/vaults")]
        public async Task<ActionResult<List<Vault>>> GetVaultsByProfileId(string id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                IEnumerable<Vault> vaults = _vservice.GetVaultsByProfileId(id);
                return Ok(vaults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/keeps")]
        public async Task<ActionResult<List<Vault>>> GetKeepsByProfileId(string id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                IEnumerable<Keep> keeps = _kservice.GetKeepByProfileId(id, userInfo.Id);
                return Ok(keeps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
//GetById 
