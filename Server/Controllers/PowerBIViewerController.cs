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
using Microsoft.Identity.Client;
using System.Threading.Tasks;
using Oqtane.Repository;
using Oqtane.Models;
using System.Linq;
using System;
using Microsoft.PowerBI.Api.Models;
using Microsoft.PowerBI.Api;
using Microsoft.Rest;

namespace Oqtane.PowerBIViewer.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class PowerBIViewerController : ModuleControllerBase
    {
        private readonly IPowerBIViewerRepository _PowerBIViewerRepository;
        private readonly ISettingRepository _SettingRepository;
        public PowerBIViewerController(
            IPowerBIViewerRepository PowerBIViewerRepository,
            ILogManager logger,
            IHttpContextAccessor accessor,
            ISettingRepository setting) : base(logger, accessor)
        {
            _PowerBIViewerRepository = PowerBIViewerRepository;
            _SettingRepository = setting;
        }

        // GET api/<controller>?authmoduleid=x
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.PowerBIViewer Get(string authmoduleid)
        {
            Models.PowerBIViewer PowerBIViewer = new Models.PowerBIViewer();
            int ModuleId = 0;

            if (int.TryParse(authmoduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                if (ModuleId > 0)
                {
                    List<Setting> ModuleSettings = _SettingRepository.GetSettings(EntityNames.Module, ModuleId).ToList();

                    var ApplicationId = ModuleSettings.Where(x => x.SettingName == "ApplicationId").FirstOrDefault();
                    var ApplicationSecret = ModuleSettings.Where(x => x.SettingName == "ApplicationSecret").FirstOrDefault();
                    var TenantId = ModuleSettings.Where(x => x.SettingName == "TenantId").FirstOrDefault();
                    var WorkspaceId = ModuleSettings.Where(x => x.SettingName == "WorkspaceId").FirstOrDefault();
                    var ReportId = ModuleSettings.Where(x => x.SettingName == "ReportId").FirstOrDefault();

                    var PowerBIAccessToken = GetPowerBIAccessToken(ApplicationId.SettingValue, ApplicationSecret.SettingValue, TenantId.SettingValue);

                    PowerBIViewer = new Models.PowerBIViewer();

                    PowerBIViewer.AuthToken = PowerBIAccessToken;

                    if (PowerBIAccessToken != "")
                    {
                        var tokenCredentials =
                            new TokenCredentials(PowerBIAccessToken, "Bearer");

                        using (var client = new PowerBIClient(
                            new Uri("https://api.powerbi.com/"), tokenCredentials))
                        {
                            var report =
                                 client.Reports.GetReportInGroupAsync(
                                    new Guid(WorkspaceId.SettingValue),
                                    new Guid(ReportId.SettingValue));

                            var generateTokenRequestParameters =
                                new GenerateTokenRequest(accessLevel: "view");

                            var tokenResponse =
                                client.Reports.GenerateTokenAsync(
                                    new Guid(WorkspaceId.SettingValue),
                                    new Guid(ReportId.SettingValue),
                                    generateTokenRequestParameters);

                            PowerBIViewer.EmbedToken = tokenResponse.Result;
                            PowerBIViewer.EmbedUrl = report.Result.EmbedUrl;
                        }
                    }
                }
                else
                {
                    _logger.Log(Oqtane.Shared.LogLevel.Error, this, LogFunction.Security, "Unauthorized PowerBIViewer Get Attempt {PowerBIViewerId}");
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    return null;
                }
            }

            return PowerBIViewer;
        }

        private const string AuthorityFormat = "https://login.microsoftonline.com/{0}/v2.0";
        private const string MSGraphScope = "https://analysis.windows.net/powerbi/api/.default";

        private string GetPowerBIAccessToken(string ClientId, string ClientSecret, string TenantId)
        {
            string AccessToken = string.Empty;
            try
            {
                IConfidentialClientApplication daemonClient;

                daemonClient = ConfidentialClientApplicationBuilder.Create(ClientId)
                    .WithAuthority(string.Format(AuthorityFormat, TenantId))
                    .WithClientSecret(ClientSecret)
                    .Build();

                AuthenticationResult authResult = daemonClient.AcquireTokenForClient(new[] { MSGraphScope }).ExecuteAsync().Result;

                AccessToken = authResult.AccessToken;
            }
            catch
            {

            }

            return AccessToken;
        }
    }
}
