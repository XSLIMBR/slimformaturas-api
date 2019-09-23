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
        public IActionResult Post([FromBody]Graduate graduate) {
            try {
                _graduateService.Post<GraduateValidator>(graduate);
                return new ObjectResult(graduate.GraduateId);
            } catch (ArgumentException ex) {
                return NotFound(ex);
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Graduate graduate) {
            try {
                _graduateService.Put<GraduateValidator>(graduate);
                return new ObjectResult(graduate);
            } catch (ArgumentNullException ex) {
                return NotFound(ex);
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id) {
            try {
                _graduateService.Delete(id);
                return new NoContentResult();
            } catch (ArgumentException ex) {
                return NotFound(ex);
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Get() {
            try {
                return new ObjectResult(_graduateService.Get());
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id) {
            try {
                return new ObjectResult(_graduateService.Get(id));
            } catch (ArgumentException ex) {
                return NotFound(ex);
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }
    }
}