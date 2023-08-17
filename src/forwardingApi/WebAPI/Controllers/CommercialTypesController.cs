using Application.Features.CommercialTypes.Commands.Create;
using Application.Features.CommercialTypes.Commands.Delete;
using Application.Features.CommercialTypes.Commands.Update;
using Application.Features.CommercialTypes.Queries.GetById;
using Application.Features.CommercialTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommercialTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCommercialTypeCommand createCommercialTypeCommand)
    {
        CreatedCommercialTypeResponse response = await Mediator.Send(createCommercialTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCommercialTypeCommand updateCommercialTypeCommand)
    {
        UpdatedCommercialTypeResponse response = await Mediator.Send(updateCommercialTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCommercialTypeResponse response = await Mediator.Send(new DeleteCommercialTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCommercialTypeResponse response = await Mediator.Send(new GetByIdCommercialTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCommercialTypeQuery getListCommercialTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCommercialTypeListItemDto> response = await Mediator.Send(getListCommercialTypeQuery);
        return Ok(response);
    }
}