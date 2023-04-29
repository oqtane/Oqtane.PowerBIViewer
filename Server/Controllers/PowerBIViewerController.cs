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

        // GET api/<controller>?authmoduleid=x
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.PowerBIViewer Get(string authmoduleid)
        {
            int ModuleId;
            if (int.TryParse(authmoduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                Models.PowerBIViewer PowerBIViewer = new Models.PowerBIViewer() { AuthToken = "TESTAuthToken" };

                if (PowerBIViewer != null)
                {
                    return PowerBIViewer;
                }
                else
                { 
                    _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized PowerBIViewer Get Attempt {PowerBIViewerId}");
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    return null;
                }
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized PowerBIViewer Get Attempt {PowerBIViewerId}");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }       
    }
}
