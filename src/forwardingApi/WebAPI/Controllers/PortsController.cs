using Application.Features.Ports.Commands.Create;
using Application.Features.Ports.Commands.Delete;
using Application.Features.Ports.Commands.Update;
using Application.Features.Ports.Queries.GetById;
using Application.Features.Ports.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PortsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePortCommand createPortCommand)
    {
        CreatedPortResponse response = await Mediator.Send(createPortCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePortCommand updatePortCommand)
    {
        UpdatedPortResponse response = await Mediator.Send(updatePortCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedPortResponse response = await Mediator.Send(new DeletePortCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdPortResponse response = await Mediator.Send(new GetByIdPortQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPortQuery getListPortQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListPortListItemDto> response = await Mediator.Send(getListPortQuery);
        return Ok(response);
    }
}