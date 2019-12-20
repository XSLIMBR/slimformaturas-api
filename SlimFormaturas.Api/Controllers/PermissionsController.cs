using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlimFormaturas.Domain.Entities;
using SlimFormaturas.Domain.Interfaces.Service;
using SlimFormaturas.Domain.Notifications;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SlimFormaturas.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ApiController
    {

        public PermissionsController(
            NotificationHandler notifications) : base(notifications) {
        }

        //[HttpPost]
        //public async Task<ActionResult<string>> Post(TypeGeneric typeGeneric) {
        //    _ = await _typeGenericService.Insert(typeGeneric);
        //    return Response(typeGeneric.TypeGenericId);
        //}

        //[HttpPut]
        //public async Task<ActionResult<string>> Put(TypeGeneric typeGeneric) {
        //    _ = await _typeGenericService.Update(typeGeneric);
        //    return Response(typeGeneric.TypeGenericId);
        //}

        [HttpGet]
        public ActionResult Get() {
            return Response(claims);
        }

        public static List<Claim> claims = new List<Claim>() {
            new Claim("Graduate", "Incluir"),
            new Claim("Graduate", "Editar"),
            new Claim("Graduate", "Excluir"),
            new Claim("Graduate", "Consultar"),
            new Claim("Address", "Incluir"),
            new Claim("Address", "Editar"),
            new Claim("Address", "Excluir"),
            new Claim("Address", "Consultar"),
            new Claim("Phone", "Incluir"),
            new Claim("Phone", "Editar"),
            new Claim("Phone", "Excluir"),
            new Claim("Phone", "Consultar"),
            new Claim("Type", "Incluir"),
            new Claim("Type", "Editar"),
            new Claim("Type", "Excluir"),
            new Claim("Type", "Consultar")
        };
    }
}
