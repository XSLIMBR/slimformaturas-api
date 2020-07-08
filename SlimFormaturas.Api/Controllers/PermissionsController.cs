using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SlimFormaturas.Api.Controllers {
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ApiController {

        readonly IPermissionsService _permissionsService;
       
        public PermissionsController(NotificationHandler notifications, IPermissionsService permissionsService ) : base (notifications) {
            _permissionsService = permissionsService;
        }

        [HttpGet]
        public ActionResult<Permission> Get() {

            //var teste = teste2.GetPermissionsToDisplay(typeof(Permissions));

            return Response(_permissionsService.GetPermissionsToDisplay());
        }
    }
}
