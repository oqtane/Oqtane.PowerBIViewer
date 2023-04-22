using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.PowerBIViewer.Repository;
using Oqtane.Controllers;
using System.Net;

namespace Oqtane.PowerBIViewer.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class PowerBIViewerController : ModuleControllerBase
    {
        private readonly IPowerBIViewerRepository _PowerBIViewerRepository;

        public PowerBIViewerController(IPowerBIViewerRepository PowerBIViewerRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _PowerBIViewerRepository = PowerBIViewerRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.PowerBIViewer> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _PowerBIViewerRepository.GetPowerBIViewers(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized PowerBIViewer Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.PowerBIViewer Get(int id)
        {
            Models.PowerBIViewer PowerBIViewer = _PowerBIViewerRepository.GetPowerBIViewer(id);
            if (PowerBIViewer != null && IsAuthorizedEntityId(EntityNames.Module, PowerBIViewer.ModuleId))
            {
                return PowerBIViewer;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized PowerBIViewer Get Attempt {PowerBIViewerId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.PowerBIViewer Post([FromBody] Models.PowerBIViewer PowerBIViewer)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, PowerBIViewer.ModuleId))
            {
                PowerBIViewer = _PowerBIViewerRepository.AddPowerBIViewer(PowerBIViewer);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "PowerBIViewer Added {PowerBIViewer}", PowerBIViewer);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized PowerBIViewer Post Attempt {PowerBIViewer}", PowerBIViewer);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                PowerBIViewer = null;
            }
            return PowerBIViewer;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.PowerBIViewer Put(int id, [FromBody] Models.PowerBIViewer PowerBIViewer)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, PowerBIViewer.ModuleId) && _PowerBIViewerRepository.GetPowerBIViewer(PowerBIViewer.PowerBIViewerId, false) != null)
            {
                PowerBIViewer = _PowerBIViewerRepository.UpdatePowerBIViewer(PowerBIViewer);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "PowerBIViewer Updated {PowerBIViewer}", PowerBIViewer);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized PowerBIViewer Put Attempt {PowerBIViewer}", PowerBIViewer);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                PowerBIViewer = null;
            }
            return PowerBIViewer;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.PowerBIViewer PowerBIViewer = _PowerBIViewerRepository.GetPowerBIViewer(id);
            if (PowerBIViewer != null && IsAuthorizedEntityId(EntityNames.Module, PowerBIViewer.ModuleId))
            {
                _PowerBIViewerRepository.DeletePowerBIViewer(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "PowerBIViewer Deleted {PowerBIViewerId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized PowerBIViewer Delete Attempt {PowerBIViewerId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
