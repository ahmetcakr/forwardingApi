using Application.Features.Ships.Commands.Create;
using Application.Features.Ships.Commands.Delete;
using Application.Features.Ships.Commands.Update;
using Application.Features.Ships.Queries.GetById;
using Application.Features.Ships.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShipsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateShipCommand createShipCommand)
    {
        CreatedShipResponse response = await Mediator.Send(createShipCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateShipCommand updateShipCommand)
    {
        UpdatedShipResponse response = await Mediator.Send(updateShipCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedShipResponse response = await Mediator.Send(new DeleteShipCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdShipResponse response = await Mediator.Send(new GetByIdShipQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListShipQuery getListShipQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListShipListItemDto> response = await Mediator.Send(getListShipQuery);
        return Ok(response);
    }
}