using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
using SlimFormaturas.Domain.Validators;
using MediatR;
using SlimFormaturas.Domain.Notifications;

namespace SlimFormaturas.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GraduateController : ApiController {
        private readonly IGraduateService _graduateService;

        public GraduateController(
            IGraduateService graduateService,
            NotificationHandler notifications) : base (notifications)
        {
            _graduateService = graduateService;
        }

        [HttpPost]
        public async Task<ActionResult<Graduate>> Post(Graduate graduate) {
            await _graduateService.Post<GraduateValidator>(graduate);
            return Response(graduate);
        }

        [HttpPut]
        public async Task<ActionResult<Graduate>> Put(Graduate graduate) {
            await _graduateService.Put<GraduateValidator>(graduate);
            return Response(graduate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id) {
            await _graduateService.Delete(id);
            return Response();
        }

        // GET api/values
        /// <summary>
        /// Get API Value
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        [HttpGet]
        public async Task<ActionResult> Get() {
            return Response(await _graduateService.Get());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id) {
            return Response(await _graduateService.Get(id));
        }
    }
}