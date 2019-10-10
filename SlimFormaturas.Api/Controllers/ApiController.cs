using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlimFormaturas.Api.Controllers {
    public class ApiController : ControllerBase {
        protected readonly NotificationHandler _notifications;
        protected ApiController(NotificationHandler notifications ) {
            _notifications = notifications;
        }

        protected bool IsValidOperation() {
            return !_notifications.HasNotifications;
        }

        protected new ActionResult Response(object result = null) {
            if (IsValidOperation()) {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.Notifications.GroupBy(m => m.PropertyName).Select(a => a.ToArray())
            });
        }

        //protected void AddIdentityErrors(IdentityResult result) {
        //    foreach (var error in result.Errors) {
        //       new Notification(result.ToString(), error.Description);
        //    }
        //}
    }
}
