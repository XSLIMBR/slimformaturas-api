using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Service.Validators;

namespace SlimFormaturas.Api.Controllers  {
    [Route("api/[controller]")]
    [ApiController]
    public class GraduateController : ControllerBase {
        private readonly IGraduateService _graduateService;

        public GraduateController(IGraduateService graduateService) {
            _graduateService = graduateService;
        }

        [HttpPost]
        public async Task<ActionResult<Graduate>> Post(Graduate graduate) {
            try {
                await _graduateService.Post<GraduateValidator>(graduate);
                return new ObjectResult(graduate.GraduateId);
            } catch (ArgumentException ex) {
                return NotFound(ex);
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Graduate>> Put(Graduate graduate) {
            try {
                await _graduateService.Put<GraduateValidator>(graduate);
                return new ObjectResult(graduate);
            } catch (ArgumentNullException ex) {
                return NotFound(ex);
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id) {
            try {
                await _graduateService.Delete(id);
                return new NoContentResult();
            } catch (ArgumentException ex) {
                return NotFound(ex);
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get() {
            try {
                return new ObjectResult(await _graduateService.Get());
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(string id) {
            try {
                return new ObjectResult(await _graduateService.Get(id));
            } catch (ArgumentException ex) {
                return NotFound(ex);
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }
    }
}