using Application.Features.Voyages.Commands.Create;
using Application.Features.Voyages.Commands.Delete;
using Application.Features.Voyages.Commands.Update;
using Application.Features.Voyages.Queries.GetById;
using Application.Features.Voyages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VoyagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateVoyageCommand createVoyageCommand)
    {
        CreatedVoyageResponse response = await Mediator.Send(createVoyageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateVoyageCommand updateVoyageCommand)
    {
        UpdatedVoyageResponse response = await Mediator.Send(updateVoyageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedVoyageResponse response = await Mediator.Send(new DeleteVoyageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdVoyageResponse response = await Mediator.Send(new GetByIdVoyageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListVoyageQuery getListVoyageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListVoyageListItemDto> response = await Mediator.Send(getListVoyageQuery);
        return Ok(response);
    }
}