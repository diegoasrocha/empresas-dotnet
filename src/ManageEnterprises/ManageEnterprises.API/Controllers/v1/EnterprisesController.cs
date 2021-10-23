using ManageEnterprises.Application.Contexts.Enterprises.AllEnterprises;
using ManageEnterprises.Application.Contexts.Enterprises.EnterpriseByFilters;
using ManageEnterprises.Application.Contexts.Enterprises.EnterprisesById;
using ManageEnterprises.Application.DTOs;
using ManageEnterprises.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManageEnterprises.API.Controllers.v1
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnterprisesController : ControllerBase
    {
        private readonly IMediator mediator;

        public EnterprisesController(IMediator mediator)
        {
            this.mediator = mediator;
        } 

        [HttpGet("{index}")]
        public ActionResult Get([FromRoute] string index)
        {
            long id;
            long.TryParse(index, out id);

            EnterpriseDTO result = this.mediator.Send(new EnterpriseByIdQuery(id)).Result;

            if (result != null)
                return Ok(new { enterprise = result, sucesso = true});
            else
                return NotFound(new { status = "404", error = "Not Found" });
        }

        [HttpGet] 
        public ActionResult Get([FromQuery] string name = null, [FromQuery] string enterprise_types = null)
        {
            dynamic result;

            long type;
            long.TryParse(enterprise_types, out type);

            EnterpriseTypeEnum? _enum = null;

            if(type > 0)
                _enum = (EnterpriseTypeEnum) type; 

            if (string.IsNullOrEmpty(name) && !_enum.HasValue && string.IsNullOrEmpty(enterprise_types))
            {
                result = this.mediator.Send(new AllEnterprisesQuery()).Result;
            }
            else
            {
                result = this.mediator.Send(new EnterprisesByFiltersQuery(_enum, name)).Result;
            }

            if (result != null)
                return Ok(new { enterprises = result });
            else
                return NotFound(new { status = "404", error = "Not Found" });
        }
    }
}
